using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using Timer = System.Windows.Forms.Timer;

namespace CircuitCraft
{
    public enum GameState
    {
        BranchUnlocking,
        Survival
    }
    public partial class GameCanvas : UserControl
    {
        public MainGamePrototype MainGamePrototype { get; set; }
        public struct CircuitElementTemp
        {
            public CircuitElementType CircuitElementType;
            public double Voltage;
            public double Resistance;
        }

        public GameState GameState { get; set; } = GameState.BranchUnlocking;
        public double SourceValueMultiplier { get; set; } = 0.2;
        public double ResistanceValueMultiplier { get; set; } = 2;


        #region Recorded Statistics
        public int RecordedHighestLevel { get; set; } = 0;
        public int RecordedLedBurned { get; set; } = 0;
        public int RecordedLedUnpowered { get; set; } = 0;
        public int RecordedHighestJoule { get; set; } = 0;
        public int RecordedRating { get; set; } = 0;
        public int RecordedDiodeBlocked { get; set; } = 0;
        public int RecordedCircuitOverflowed { get; set; } = 0;
        #endregion

        private int _currentLevel = 1;
        public int CurrentLevel {
            get
            {
                return _currentLevel;
            }
            set
            {
                _currentLevel = value;
                if (LevelLabel == null) { return; }
                LevelLabel.Text = "Level: " + _currentLevel.ToString();
            }
        }
        public int LedBurnedCount { get; set; } = 0;
        public int UnpoweredLedCount { get; set; } = 0;
        public int ReverseDiodeCount { get; set; } = 0;
        public int CircuitOverflowCount { get; set; } = 0;

        public Action ShowChoicesPrompt { get; set; } = null;
        public Action<string> GameOverPrompt { get; set; } = null;

        private int _jouleCurrency;
        public int JouleCurrency {
            get
            {
                return _jouleCurrency;
            }
            set
            {
                _jouleCurrency = value;
                if (JouleCurrencyLabel == null) { return; }
                JouleCurrencyLabel.Text = _jouleCurrency.ToString() + " J";
            }
        }

        public CircuitElementTemp? CurrentCircuitElementHold = null;
        public List<CircuitElement> CircuitSources { get; set; }
        private double _operatingCurrent;
        public double OperatingCurrent
        {
            get
            {
                return _operatingCurrent;
            }
            set
            {
                _operatingCurrent = value;
                if (OperatingCurrentMaxLabel == null) { return; }
                OperatingCurrentMaxLabel.Text = _operatingCurrent.ToString("F3") + " J";
            }
        }
        private double _minimumOperatingCurrent;
        public double MinimumOperatingCurrent
        {
            get
            {
                return _minimumOperatingCurrent;
            }
            set
            {
                _minimumOperatingCurrent = value;
                if (OperatingCurrentMinLabel == null) { return; }
                OperatingCurrentMinLabel.Text = _minimumOperatingCurrent.ToString("F3") + " J";
            }
        }
        public int OperatingCurrentTick { get; set; } = 0;
        public int MinimumOperatingCurrentTick { get; set; } = 0;

        private int _currentBlockIndex = 0;
        public int CurrentBlockIndex { 
            get
            {
                return _currentBlockIndex;
            }
            set
            {
                int previousIndex = _currentBlockIndex;
                if (value >= 0 && value < CircuitBlocks.Count)
                {
                    _currentBlockIndex = value;
                }
                else if (value >= CircuitBlocks.Count)
                {
                    _currentBlockIndex = CircuitBlocks.Count - 1;
                }
                else
                {
                    _currentBlockIndex = 0;
                }


                if (CircuitBlocks.Count > 0)
                {
                    if (CircuitBlocks[_currentBlockIndex].CircuitBlockState == CircuitBlockState.Locked || CircuitBlocks[_currentBlockIndex].CircuitBlockState == CircuitBlockState.Full)
                    {
                        for (int i = 1; i < CircuitBlocks.Count; i++)
                        {
                            if (_currentBlockIndex < previousIndex)
                            {
                                if (_currentBlockIndex - i > -1)
                                {
                                    if (CircuitBlocks[_currentBlockIndex - i].CircuitBlockState != CircuitBlockState.Locked && CircuitBlocks[_currentBlockIndex - i].CircuitBlockState != CircuitBlockState.Full)
                                    {
                                        _currentBlockIndex = _currentBlockIndex - i;
                                        break;
                                    }
                                }
                                else
                                {
                                    _currentBlockIndex = previousIndex;
                                }
                            }
                            else if (_currentBlockIndex > previousIndex)
                            {
                                if (_currentBlockIndex + i < CircuitBlocks.Count)
                                {
                                    if (CircuitBlocks[_currentBlockIndex + i].CircuitBlockState != CircuitBlockState.Locked && CircuitBlocks[_currentBlockIndex + i].CircuitBlockState != CircuitBlockState.Full)
                                    {
                                        _currentBlockIndex = _currentBlockIndex + i;
                                        break;
                                    }
                                }
                                else
                                {
                                    _currentBlockIndex = previousIndex;
                                }
                            }
                        }                  
                    }
                }

                foreach (var block in CircuitBlocks)
                {
                    if (block == CircuitBlocks[_currentBlockIndex])
                    {
                        block.IsSelected = true;
                    }
                    else
                    {
                        block.IsSelected = false;
                    }
                }
            }
        }

        public PictureBox? CurrentCircuitElementDropped { get; set; }

        private int _currentCircuitElementDroppedOrientation = 1; // 0 = normal, 1 = rotated
        public int CurrentCircuitElementDroppedOrientation 
        {
            get
            {
                return _currentCircuitElementDroppedOrientation;
            }
            set
            {
                int newOrientation = (value % 2 == 0) ? 0 : 1;

                if (_currentCircuitElementDroppedOrientation != newOrientation)
                {
                    _currentCircuitElementDroppedOrientation = newOrientation;

                    if (CurrentCircuitElementDropped != null)
                    {
                        CurrentCircuitElementDropped.Image?.Dispose();
                        CurrentCircuitElementDropped.Image = GetOrientedImageClone(
                            CurrentCircuitElementDroppedType,
                            _currentCircuitElementDroppedOrientation);
                    }
                }
            }
        }

        public double CurrentCircuitElementDroppedResistance { get; set; }
        public double CurrentCircuitElementDroppedVoltage { get; set; }
        public CircuitElementType CurrentCircuitElementDroppedType { get; set; }

        public bool WillUseHoldCircuitElement { get; set; } = false;

        private List<CircuitBlock> _circuitBlocks { get; set; } = new List<CircuitBlock>();

        private List<CircuitElementTemp> NextCircuitElements { get; set; } = new List<CircuitElementTemp>();

        private Image _circuitElementSourceSprite5;
        private Image _circuitElementSourceSprite4;
        private Image _circuitElementSourceSprite3;
        private Image _circuitElementSourceSprite2;
        private Image _circuitElementSourceSprite1;

        private Image _circuitElementResistorSprite5;
        private Image _circuitElementResistorSprite4;
        private Image _circuitElementResistorSprite3;
        private Image _circuitElementResistorSprite2;
        private Image _circuitElementResistorSprite1;

        private Image _circuitElementLEDSprite;
        private Image _circuitElementDiodeSprite;

        private PictureBox _holdComponentPbox;
        private BigLabel _holdComponentLabel;

        private PictureBox _nextComponentPbox1;
        private BigLabel _nextComponentLabel1;

        private PictureBox _nextComponentPbox2;
        private BigLabel _nextComponentLabel2;

        private BigLabel _gameMessageLabel;

        private BigLabel _currentValueLabel;

        private BigLabel _initialVoltageSourceLabel;

        private BigLabel _jouleCurrencyLabel;

        private BigLabel _maintainTimerLabel;

        private BigLabel _levelLabel;

        private BigLabel _ratingLabel;

        private BigLabel _warningTimerLabel;

        private LostProgressBar _nextComponentProgressbar;

        private ProgressBar _operatingCurrentProgressBar;
        private BigLabel _operatingCurrentMaxLabel;
        private BigLabel _operatingCurrentMinLabel;

        private LostProgressBar _warningHighProgressBar;
        private LostProgressBar _warningLowProgressBar;

        private Image _lockedCircuitBlockImage;
        private Image _seriesCircuitBlockImage;
        private Image _parallelCircuitBlockImage;
        private Image _trashCircuitBlockImage;

        private Image _playButtonImage;
        private Image _pauseButtonImage;

        #region Circuit Block Cards
        private Image _seriesCircuitBlockCardImage;
        private string _seriesCircuitBlockCardText = "Series Circuit Block";
        private int _seriesCircuitBlockCardCost = 10;

        private Image _parallelCircuitBlockCardImage;
        private string _parallelCircuitBlockCardText = "Parallel Circuit Block";
        private int _parallelCircuitBlockCardCost = 10;

        private Image _trashCircuitBlockCardImage;
        private string _trashCircuitBlockCardText = "Trash Circuit Block";
        private int _trashCircuitBlockCardCost = 10;

        private Image _sourceIncreaseChanceCardImage;
        private string _sourceIncreaseChanceText = "Increase source chance";
        private int _sourceIncreaseChanceCost = 10;

        private Image _resistorIncreaseChanceCardImage;
        private string _resistorIncreaseChanceText = "Increase resistor chance";
        private int _resistorIncreaseChanceCost = 10;

        private Image _diodeIncreaseChanceCardImage;
        private string _diodeIncreaseChanceText = "Increase diode chance";
        private int _diodeIncreaseChanceCost = 10;

        private Image _initialVoltageIncreaseCardImage;
        private string _initialVoltageIncreaseText = "Increase inital voltage";
        private int _initialVoltageIncreaseCost = 10;
        #endregion

        private int _circuitElementSpawnOffsetY = 20;

        public Timer gameTimer = new Timer();
        public Timer gameLedTimer = new Timer();
        public Timer warningTimer = new Timer();
        public Timer holdCooldownTimer = new Timer();
        public Timer nextComponentTimer = new Timer();
        public Timer warningStartTimer = new Timer();
        public Timer roundStartTimer = new Timer();

        public int timeLeftToMaintainInSeconds { get; set; } = 60;

        private BigLabel _holdCooldownLabel;
        private LostProgressBar _holdCooldownProgressBar;

        public GameCanvas()
        {
            InitializeComponent();
            MinimumOperatingCurrent = 0.1;
            OperatingCurrent = 0.2;
            if (_circuitBlocks == null)
            {
                _circuitBlocks = new List<CircuitBlock>();
            }

            gameTimer.Interval = 1;
            gameTimer.Tick += new EventHandler(Timer_Tick);

            warningTimer.Interval = 100;
            warningTimer.Tick += new EventHandler(OperatingCurrentTimer_Tick);

            gameLedTimer.Interval = 1000;
            gameLedTimer.Tick += new EventHandler(GameLedTimer_Tick);

            holdCooldownTimer.Interval = 500;
            holdCooldownTimer.Tick += new EventHandler(HoldCooldownTimer_Tick);

            nextComponentTimer.Interval = 100;
            nextComponentTimer.Tick += new EventHandler(NextComponentTimer_Tick);

            warningStartTimer.Interval = 1000;
            warningStartTimer.Tick += new EventHandler(WarningStartTimer_Tick);

            roundStartTimer.Interval = 1000;
            roundStartTimer.Tick += new EventHandler(RoundStartTimer_Tick);

            DifficultyManager.UpdateImageKeys(new List<Image>()
            {
                CircuitElementSourceSprite1,
                CircuitElementSourceSprite2,
                CircuitElementSourceSprite3,
                CircuitElementSourceSprite4,
                CircuitElementSourceSprite5
            },
            new List<Image>()
            {
                CircuitElementResistorSprite1,
                CircuitElementResistorSprite2,
                CircuitElementResistorSprite3,
                CircuitElementResistorSprite4,
                CircuitElementResistorSprite5
            });
        }

        public void AddJoules()
        {
            JouleCurrency += 30;
        }

        public void StartRound()
        {
            roundStartTimer.Start();
            if (CurrentLevel== 10)
            {
                GameState = GameState.Survival;
            }
            if (GameState == GameState.BranchUnlocking)
            { 
                MaintainTimerLabel.Visible = false;
            }
            if (GameState == GameState.Survival)
            {
                MaintainTimerLabel.Visible = true;
                timeLeftToMaintainInSeconds = 60 + CurrentLevel;
            }

            ClearUpNextComponents();
            DifficultyManager.UpdateDifficulty(new List<Image>()
            {
                CircuitElementSourceSprite1,
                CircuitElementSourceSprite2,
                CircuitElementSourceSprite3,
                CircuitElementSourceSprite4,
                CircuitElementSourceSprite5
            },
            new List<Image>()
            {
                CircuitElementResistorSprite1,
                CircuitElementResistorSprite2,
                CircuitElementResistorSprite3,
                CircuitElementResistorSprite4,
                CircuitElementResistorSprite5
            }, ref _currentLevel, _currentLevel);
            UpdateDifficultyValues();

            FillUpNextComponents();
            SpawnNextComponent();
        }

        public void UpdateDifficultyValues()
        {
            MinimumOperatingCurrent = DifficultyManager.ScaledMinimumOperatingCurrent;
            OperatingCurrent = DifficultyManager.ScaledMaximumOperatingCurrent;
        }


        public void PauseGame()
        {
            gameTimer.Stop();
            gameLedTimer.Stop();
            warningTimer.Stop();
            warningStartTimer.Stop();
            roundStartTimer.Stop();


            holdCooldownTimer.Stop();
            nextComponentTimer.Stop();
        }

        public void ResumeGame()
        {
            if (roundStartTimerTick == 0) gameLedTimer.Start();

            if (warningStartTimerTick == 0 && roundStartTimerTick == 0) warningTimer.Start();
            if (roundStartTimerTick == 0) gameLedTimer.Start();

            if (holdCooldownTick != 0) holdCooldownTimer.Start();
            if (nextComponentTimerTick != 0) nextComponentTimer.Start();
            if (roundStartTimerTick != 0) roundStartTimer.Start();
            if (warningStartTimerTick != 0) warningStartTimer.Start();
        }

        public void ResetGame()
        {
            gameTimer.Stop();
            gameLedTimer.Stop();
            warningTimer.Stop();
            warningStartTimer.Stop();
            WarningTimerLabel.Visible = false;
            GameMessageLabel.Visible = false;

            warningStartTimerTick = 0;

            holdCooldownTimer.Stop();
            nextComponentTimer.Stop();
            roundStartTimer.Stop();

            CurrentBlockIndex = 0;
            foreach (CircuitBlock circuitBlock in CircuitBlocks)
            {
                circuitBlock.Controls.Remove(CurrentCircuitElementDropped);
            }    
            CurrentCircuitElementDropped = null;
            ClearUpNextComponents();
            ClearHoldCircuitElement();


            MinimumOperatingCurrentTick = 0;
            OperatingCurrentTick = 0;

            OperatingCurrentProgressBar.Value = 0;
            WarningHighProgressBar.Progress = 0;
            WarningLowProgressBar.Progress = 0;

            GameState = GameState.BranchUnlocking;

            roundStartTimerTick = 0;

            NextComponentProgressbar.Progress = 100;

            CurrentLevel = 1;
            JouleCurrency = 0;

            for (int i = 0; i < CircuitBlocks.Count; i++)
            {
                if (i == 0 || i == 1 || i == 2)
                {
                    CircuitBlocks[i].CircuitBlockState = CircuitBlockState.Unlocked;
                }
                else
                {
                    CircuitBlocks[i].CircuitBlockState = CircuitBlockState.Locked;
                }
                while (CircuitBlocks[i].CircuitElements.Count > 0)
                {
                    CircuitBlocks[i].RemoveCircuitElement(0);
                }
                UpdateCircuitBlock(CircuitBlocks[i]);
            }
        }

        public void NextRoundReset()
        {
            ClearCircuitElements();
            ClearHoldCircuitElement();

            warningTimer.Stop();
            gameLedTimer.Stop();

            MinimumOperatingCurrentTick = 0;
            OperatingCurrentTick = 0;

            WarningTimerLabel.Visible = false;

            warningStartTimerTick = 0;

            ClearUpNextComponents();

            CircuitBlocks[CurrentBlockIndex].Controls.Remove(CurrentCircuitElementDropped);
            CurrentCircuitElementDropped = null;
        }

        public void ClearCircuitElements()
        {
            for (int i = 0; i < CircuitBlocks.Count; i++)
            {
                while (CircuitBlocks[i].CircuitElements.Count > 0)
                {
                    CircuitBlocks[i].RemoveCircuitElement(0);
                }
                if (CircuitBlocks[i].CircuitBlockState != CircuitBlockState.Locked && CircuitBlocks[i].CircuitBlockState == CircuitBlockState.Full)
                {
                    CircuitBlocks[i].CircuitBlockState = CircuitBlockState.Unlocked;
                }
                UpdateCircuitBlock(CircuitBlocks[i]);
            }
        }


        private int roundStartTimerTick = 0;
        private int roundStartTime = 6000;
        public void RoundStartTimer_Tick(object sender, EventArgs e)
        {
            roundStartTimerTick += 1000;
            GameMessage("ROUND STARTING IN " + ((roundStartTime - roundStartTimerTick)/1000) + "...");

            if (roundStartTimerTick >= roundStartTime)
            {
                GameMessage();
                roundStartTimerTick = 0;
                gameTimer.Start();
                gameLedTimer.Start();
                warningStartTimer.Start();
                roundStartTimer.Stop();
            }
        }

        private int nextComponentTimerTick = 0;
        private int nextComponentCooldown = 3000;
        public void NextComponentTimer_Tick(object sender, EventArgs e)
        {
            nextComponentTimerTick += 100;
            NextComponentProgressbar.Progress = Convert.ToInt32((nextComponentTimerTick / (float)nextComponentCooldown) * 100);

            if (nextComponentTimerTick >= nextComponentCooldown)
            {
                nextComponentTimerTick = 0;
                SpawnNextComponent();
                nextComponentTimer.Stop();
            }
        }

        private int warningStartTimerTick = 0;
        private int warningStartCooldown = 10000; // in ms
        public void WarningStartTimer_Tick(object sender, EventArgs e)
        {
            warningStartTimerTick += 1000;

            WarningTimerLabel.Text = "MEASURING STARTING IN " + (warningStartCooldown - warningStartTimerTick) / 1000 + "...";
            WarningTimerLabel.Visible = true;
            if (warningStartTimerTick >= warningStartCooldown)
            {
                WarningTimerLabel.Visible = false;
                warningStartTimerTick = 0;
                WarningHighProgressBar.Progress = 0;
                WarningLowProgressBar.Progress = 0;
                warningTimer.Start();
                warningStartTimer.Stop();
            }
        }


        public void GameMessage(string message)
        {
            GameMessageLabel.Text = message;
            GameMessageLabel.Visible = true;
            GameMessageLabel.BringToFront();
        }

        public void GameMessage()
        {
            GameMessageLabel.Text = "";
            GameMessageLabel.Visible = false;
        }


        public Dictionary<int, int> LevelJouleRequirements = new Dictionary<int, int>()
        {
            { 1, 50 },
            { 2, 50 },
            { 3, 50 },
            { 4, 50 },
            { 5, 50 },
            { 6, 50 },
            { 7, 50 },
            { 8, 50 },
            { 9, 50 },
            { 10, 50 }
        };

        double joulesAccumulation = 0;
        private bool isTimed = false;
        private void GameLedTimer_Tick(object sender, EventArgs e)
        {
            if (!isTimed) 
            { 
                timeLeftToMaintainInSeconds -= 1;
            }

            if (!double.IsNaN(result.LoadCurrent) && result.LoadCurrent > 0 )
            {
                if (result.LoadCurrent < OperatingCurrent + 1)
                {
                    joulesAccumulation += result.LoadCurrent;
                }
                if (joulesAccumulation > 1)
                {
                    JouleCurrency += Convert.ToInt32(joulesAccumulation);
                    joulesAccumulation = 0;
                }
            }

            if (CurrentLevel < 10)
            {
                if (JouleCurrency > LevelJouleRequirements[CurrentLevel] && GameState == GameState.BranchUnlocking)
                {
                    if (ShowChoicesPrompt != null)
                    {
                        PauseGame();
                        CurrentLevel++;
                        if (GameState == GameState.BranchUnlocking)
                        {
                            JouleCurrency -= LevelJouleRequirements[CurrentLevel];
                        }
                        DifficultyManager.UpdateDifficulty(new List<Image>()
                                {
                                    CircuitElementSourceSprite1,
                                    CircuitElementSourceSprite2,
                                    CircuitElementSourceSprite3,
                                    CircuitElementSourceSprite4,
                                    CircuitElementSourceSprite5
                                },
                        new List<Image>()
                        {
                                    CircuitElementResistorSprite1,
                                    CircuitElementResistorSprite2,
                                    CircuitElementResistorSprite3,
                                    CircuitElementResistorSprite4,
                                    CircuitElementResistorSprite5
                        }, ref _currentLevel, CurrentLevel);
                        UpdateDifficultyValues();
                        ShowChoicesPrompt();
                    }
                }

            }
            if (timeLeftToMaintainInSeconds <= 0 && GameState == GameState.Survival)
            {
                PauseGame();
                CurrentLevel++;
                timeLeftToMaintainInSeconds = 0;
                DifficultyManager.UpdateDifficulty(new List<Image>()
                            {
                                CircuitElementSourceSprite1,
                                CircuitElementSourceSprite2,
                                CircuitElementSourceSprite3,
                                CircuitElementSourceSprite4,
                                CircuitElementSourceSprite5
                            },
                            new List<Image>()
                            {
                                CircuitElementResistorSprite1,
                                CircuitElementResistorSprite2,
                                CircuitElementResistorSprite3,
                                CircuitElementResistorSprite4,
                                CircuitElementResistorSprite5
                            }, ref _currentLevel, CurrentLevel);
                UpdateDifficultyValues();
                ShowChoicesPrompt();
            }
            TimeSpan time = TimeSpan.FromSeconds(timeLeftToMaintainInSeconds);
            MaintainTimerLabel.Text = "Time Left: " + time.ToString(@"mm\:ss") + " s";
        }

        public bool holdOnCooldown = false;
        public int holdCooldownTime = 10000; // in ms
        public int holdCooldownTick = 0;
        private void HoldCooldownTimer_Tick(object sender, EventArgs e)
        {
            holdCooldownTick += 500; 
            HoldCooldownProgressbar.Progress = Convert.ToInt32((holdCooldownTick / (float)holdCooldownTime) * 100);
            if (holdCooldownTick == holdCooldownTime)
            {
                HoldCooldownProgressbar.Progress = 100;
                HoldCooldownLabel.Text = "Ready!";
                HoldCooldownLabel.ForeColor = Color.DarkGreen;
                HoldCooldownProgressbar.ForeColor = Color.DarkGreen;
                holdOnCooldown = false;
                holdCooldownTimer.Stop();
            }
            else
            {
                HoldCooldownLabel.Text = "Cooldown!";
                HoldCooldownProgressbar.ForeColor = Color.Red;
                HoldCooldownLabel.ForeColor = Color.Red;
            }
        }

        public void AddCircuitSource(double voltage)
        {
            CircuitElement circuitElement = new GameSource();
            circuitElement.Voltage = voltage;
            //circuitElement.CircuitElementSprite = CircuitElementSourceSprite;
            CircuitSources.Add(circuitElement);
        }

        public bool UnlockCircuitBlock(Cards cards)
        {
            foreach (CircuitBlock circuitBlock in CircuitBlocks)
            {
                if (circuitBlock.CircuitBlockState == CircuitBlockState.Locked)
                {
                    circuitBlock.CircuitBlockState = CircuitBlockState.Unlocked;
                    switch (cards)
                    {
                        case Cards.SeriesCircuit:
                            circuitBlock.CircuitBlockConnectionType = CircuitBlockConnectionType.Series;
                            circuitBlock.BackgroundImage = null;
                            break;
                        case Cards.ParallelCircuit:
                            circuitBlock.CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel;
                            circuitBlock.BackgroundImage = null;
                            break;
                        case Cards.TrashCircuit:
                            circuitBlock.CircuitBlockConnectionType = CircuitBlockConnectionType.Trash;
                            circuitBlock.BackgroundImage = null;
                            break;
                    }
                    UpdateCircuitBlock(circuitBlock);
                    return true;
                }
            }
            return false;
        }

        public void SpawnNextComponent()
        {
            SpawnCircuitElement(NextCircuitElements[0].CircuitElementType, NextCircuitElements[0].Voltage, NextCircuitElements[0].Resistance);
            if (WillUseHoldCircuitElement && CurrentCircuitElementHold != null) 
            {
                WillUseHoldCircuitElement = false;
                CurrentCircuitElementHold = null;
                return; 
            }
            NextCircuitElements.RemoveAt(0);
            FillUpNextComponents();
        }

        private Image GetOrientedImageClone(CircuitElementType type, int orientation)
        {
            DifficultyManager.UpdateDifficulty(new List<Image>()
            {
                CircuitElementSourceSprite1,
                CircuitElementSourceSprite2,
                CircuitElementSourceSprite3,
                CircuitElementSourceSprite4,
                CircuitElementSourceSprite5
            },
            new List<Image>()
            {
                CircuitElementResistorSprite1,
                CircuitElementResistorSprite2,
                CircuitElementResistorSprite3,
                CircuitElementResistorSprite4,
                CircuitElementResistorSprite5
            }, ref _currentLevel, _currentLevel);
            Image baseImage = null;
            switch (type)
            {
                case CircuitElementType.Resistor:
                    baseImage = DifficultyManager.ResistanceValues[CurrentCircuitElementDroppedResistance];
                    break;
                case CircuitElementType.Source:
                    baseImage = DifficultyManager.VoltageValues[CurrentCircuitElementDroppedVoltage];
                    break;
                case CircuitElementType.Diode:
                    baseImage = this.CircuitElementDiodeSprite;
                    break;
                default:
                    return null; // return a default placeholder image
            }

            if (baseImage == null) return null;

            Image clonedImage = (Image)baseImage.Clone();

            // Apply rotation based on orientation (0 = flipped, 1 = normal)
            if (orientation == 0) 
            {
                clonedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            return clonedImage;
        }

        public void ClearUpNextComponents()
        {
            List<PictureBox> nextComponentsPboxs = new List<PictureBox>() { NextComponentPictureBox1, NextComponentPictureBox2 };
            List<BigLabel> nextComponentsLabels = new List<BigLabel>() { NextComponentLabel1, NextComponentLabel2 };

            for (int i = 0; i < 2; i++)
            {
                nextComponentsPboxs[i].Image = null;
                nextComponentsLabels[i].Text = "";
            }

            NextCircuitElements.Clear();
        }

        public void FillUpNextComponents()
        {
            DifficultyManager.UpdateImageKeys(new List<Image>()
            {
                CircuitElementSourceSprite1,
                CircuitElementSourceSprite2,
                CircuitElementSourceSprite3,
                CircuitElementSourceSprite4,
                CircuitElementSourceSprite5
            },
            new List<Image>()
            {
                CircuitElementResistorSprite1,
                CircuitElementResistorSprite2,
                CircuitElementResistorSprite3,
                CircuitElementResistorSprite4,
                CircuitElementResistorSprite5
            });
            List<PictureBox> nextComponentsPboxs = new List<PictureBox>() { NextComponentPictureBox1, NextComponentPictureBox2};
            List<BigLabel> nextComponentsLabels = new List<BigLabel>() { NextComponentLabel1, NextComponentLabel2 };
            for (int i = 0; i < 2; i++)
            {
                CircuitElementTemp circuitElement = GenerateRandomCircuitComponent();

                if (NextCircuitElements.Count < 2)
                {
                    if (NextCircuitElements.Count == 1 && i == 0) 
                    {
                        switch (NextCircuitElements[0].CircuitElementType)
                        {
                            case CircuitElementType.Resistor:
                                nextComponentsPboxs[i].Image = DifficultyManager.ResistanceValues[NextCircuitElements[i].Resistance];
                                nextComponentsLabels[i].Text = NextCircuitElements[i].Resistance.ToString("F3") + " Ω";
                                break;
                            case CircuitElementType.Source:
                                nextComponentsPboxs[i].Image = DifficultyManager.VoltageValues[NextCircuitElements[i].Voltage];
                                nextComponentsLabels[i].Text = NextCircuitElements[i].Voltage.ToString("F3") + " V";
                                break;
                            case CircuitElementType.Diode:
                                nextComponentsPboxs[i].Image = CircuitElementDiodeSprite;
                                nextComponentsLabels[i].Text = NextCircuitElements[i].Voltage.ToString("F3") + " V";
                                break;
                        }
                        continue; 
                    }
                    NextCircuitElements.Add(circuitElement);

                    switch (circuitElement.CircuitElementType)
                    {
                        case CircuitElementType.Resistor:
                            nextComponentsPboxs[i].Image = DifficultyManager.ResistanceValues[circuitElement.Resistance];
                            nextComponentsLabels[i].Text = circuitElement.Resistance.ToString("F3") + " Ω";
                            break;
                        case CircuitElementType.Source:
                            nextComponentsPboxs[i].Image = DifficultyManager.VoltageValues[circuitElement.Voltage];
                            nextComponentsLabels[i].Text = circuitElement.Voltage.ToString("F3") + " V";
                            break;
                        case CircuitElementType.Diode:
                            nextComponentsPboxs[i].Image = CircuitElementDiodeSprite;
                            nextComponentsLabels[i].Text = circuitElement.Voltage.ToString("F3") + " V";
                            break;
                    }

                }

            }
        }


        private double currentDiodeProbability = 20.0;
        private double currentSourceProbability = 30.0;
        private double currentResistorProbability = 50.0;

        public int DiodeProbability => (int)Math.Round(currentDiodeProbability);
        public int SourceProbability => (int)Math.Round(currentSourceProbability);
        public int ResistorProbability => 100 - DiodeProbability - SourceProbability;

        public void AdjustProbability(CircuitElementType typeToIncrease, double increaseAmount)
        {
            if (increaseAmount <= 0) // Only handle increases here
            {
                Console.WriteLine("Increase amount must be positive.");
                return;
            }

            // References to the probabilities based on the type
            double probToIncrease;
            double probToReduce1, probToReduce2;
            Action<double> setIncreased, setReduced1, setReduced2;

            // Assign references based on the type selected
            switch (typeToIncrease)
            {
                case CircuitElementType.Diode:
                    probToIncrease = currentDiodeProbability;
                    probToReduce1 = currentSourceProbability;
                    probToReduce2 = currentResistorProbability;
                    setIncreased = (v) => currentDiodeProbability = v;
                    setReduced1 = (v) => currentSourceProbability = v;
                    setReduced2 = (v) => currentResistorProbability = v;
                    break;

                case CircuitElementType.Source:
                    probToIncrease = currentSourceProbability;
                    probToReduce1 = currentDiodeProbability;
                    probToReduce2 = currentResistorProbability;
                    setIncreased = (v) => currentSourceProbability = v;
                    setReduced1 = (v) => currentDiodeProbability = v;
                    setReduced2 = (v) => currentResistorProbability = v;
                    break;

                case CircuitElementType.Resistor:
                    probToIncrease = currentResistorProbability;
                    probToReduce1 = currentDiodeProbability;
                    probToReduce2 = currentSourceProbability;
                    setIncreased = (v) => currentResistorProbability = v;
                    setReduced1 = (v) => currentDiodeProbability = v;
                    setReduced2 = (v) => currentSourceProbability = v;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(typeToIncrease), "Invalid component type");
            }

            // 1. Clamp the requested increase: Cannot go above 100%
            increaseAmount = Math.Min(increaseAmount, 100.0 - probToIncrease);
            if (increaseAmount <= 1e-6) // Check if increase is practically zero
            {
                Console.WriteLine("Cannot increase probability further (already at or near 100%).");
                return;
            }

            // 2. Calculate the pool of probability available for reduction
            double reductionPool = probToReduce1 + probToReduce2;

            // 3. Check if reduction is possible
            if (reductionPool <= 1e-6) // Use tolerance for floating point comparison
            {
                Console.WriteLine("Cannot increase probability; other probabilities are already at or near zero.");
                // Even though we clamped increaseAmount before, this handles the case
                // where the target is not 100%, but the *others* are 0%.
                return;
            }

            // 4. Calculate proportional reduction amounts
            double ratio1 = probToReduce1 / reductionPool;
            double ratio2 = probToReduce2 / reductionPool; // Or ratio2 = 1.0 - ratio1;

            double reduction1 = increaseAmount * ratio1;
            double reduction2 = increaseAmount * ratio2;

            // 5. Apply changes (ensure no probability goes below zero)
            double finalIncreasedProb = probToIncrease + increaseAmount;
            double finalReducedProb1 = Math.Max(0.0, probToReduce1 - reduction1);
            double finalReducedProb2 = Math.Max(0.0, probToReduce2 - reduction2);

            // 6. Optional: Fine-tune due to clamping/floating point to ensure sum is exactly 100
            // Calculate the actual total reduction achieved
            double actualTotalReduction = (probToReduce1 - finalReducedProb1) + (probToReduce2 - finalReducedProb2);
            // Adjust the increased probability by the reduction actually achieved
            finalIncreasedProb = probToIncrease + actualTotalReduction;

            // Final check to prevent exceeding 100 due to float issues and ensure sum is 100
            finalIncreasedProb = Math.Min(100.0, finalIncreasedProb); // Clamp just in case
            double currentSum = finalIncreasedProb + finalReducedProb1 + finalReducedProb2;

            // If sum isn't 100 adjust the largest reducer (or the increased one) slightly
            if (Math.Abs(currentSum - 100.0) > 1e-6)
            {
                double diff = 100.0 - currentSum;
                // Apply correction to the last one calculated or the largest pool contributor
                finalReducedProb2 += diff;
                // Re-clamp after correction
                finalReducedProb2 = Math.Max(0.0, Math.Min(100.0, finalReducedProb2));
            }


            // 7. Update the actual member variables using the setters
            setIncreased(finalIncreasedProb);
            setReduced1(finalReducedProb1);
            setReduced2(finalReducedProb2);
        }


        public CircuitElementTemp GenerateRandomCircuitComponent()
        {
            Random rng = new Random();
            int randomNumber1 = rng.Next(1, 101);
            int randomNumber2 = rng.Next(1, 101);

            double randomResistance = 0;
            double randomVoltage = 0;


            CircuitElementType circuitElementType;

            if (randomNumber1 > 0 && randomNumber1 <= currentDiodeProbability)
            {
                circuitElementType = CircuitElementType.Diode;
            }
            else if (randomNumber1 > currentDiodeProbability && randomNumber1 <= currentDiodeProbability + currentSourceProbability)
            {
                circuitElementType = CircuitElementType.Source;
            }
            else if (randomNumber1 > currentDiodeProbability + currentSourceProbability && randomNumber1 <= 100)
            {
                circuitElementType = CircuitElementType.Resistor;
            }
            else
            {
                circuitElementType = CircuitElementType.Source;
            }

            if (randomNumber1 > 0 && randomNumber1 <= 20)
            {
                randomResistance = 1 * DifficultyManager.ResistanceValueMultiplier;
                randomVoltage = 1 * DifficultyManager.SourceValueMultiplier;
            }
            else if (randomNumber1 > 20 && randomNumber1 <= 40)
            {
                randomResistance = 2 * DifficultyManager.ResistanceValueMultiplier;
                randomVoltage = 2 * DifficultyManager.SourceValueMultiplier;
            }
            else if (randomNumber1 > 40 && randomNumber1 <= 60)
            {
                randomResistance = 3 * DifficultyManager.ResistanceValueMultiplier;
                randomVoltage = 3 * DifficultyManager.SourceValueMultiplier;
            }
            else if (randomNumber1 > 60 && randomNumber1 <= 80)
            {
                randomResistance = 4 * DifficultyManager.ResistanceValueMultiplier;
                randomVoltage = 4 * DifficultyManager.SourceValueMultiplier;
            }
            else if (randomNumber1 > 80 && randomNumber1 <= 100)
            {
                randomResistance = 5 * DifficultyManager.ResistanceValueMultiplier;
                randomVoltage = 5 * DifficultyManager.SourceValueMultiplier;
            }

            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    return new CircuitElementTemp()
                    {
                        CircuitElementType = circuitElementType,
                        Resistance = Math.Round(randomResistance, 2)
                    };
                case CircuitElementType.Source:
                    return new CircuitElementTemp()
                    {
                        CircuitElementType = circuitElementType,
                        Voltage = Math.Round(randomVoltage, 2),
                        Resistance = 0.001
                    };
                case CircuitElementType.Diode:
                    return new CircuitElementTemp()
                    {
                        CircuitElementType = circuitElementType,
                        Voltage = 0
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(circuitElementType), "Invalid circuit element type.");
            }
        }

        private CircuitSimulator.LoadCalculationResult result;
        private double _sourceVoltage;
        public double SourceVoltage
        {
            get { return _sourceVoltage; }
            set 
            {
                _sourceVoltage = value;
                if (InitialVoltageValueLabel == null) { return; }
                InitialVoltageValueLabel.Text = _sourceVoltage.ToString() + " V";
            }
        }
        public double LoadResistance = 0;

        public void UpdateCircuitElementUI()
        {
            double rangeScale = (100 - 0) / (OperatingCurrent - MinimumOperatingCurrent);
            result = CircuitSimulator.CalculateLoadState(CircuitBlocks, SourceVoltage, LoadResistance);
            if (double.IsNaN(result.LoadCurrent)) {
                ReverseDiodeCount++;
                GameOverPrompt("The diode blocked all current!");
                PauseGame();
                return;
            }
            double normalized_value = ((result.LoadCurrent - MinimumOperatingCurrent) * rangeScale);
            if (double.IsNaN(normalized_value)) { normalized_value = 0; }
            int clampedValue = Convert.ToInt32(Math.Clamp(normalized_value, 0, 100));
            OperatingCurrentMaxLabel.Text = OperatingCurrent.ToString("F3") + " A";
            OperatingCurrentMinLabel.Text = MinimumOperatingCurrent.ToString("F3") + " A";
            OperatingCurrentProgressBar.Value = clampedValue;
            CurrentValueLabel.Text = (result.LoadCurrent).ToString("F3") + " A";
        }

        private void OperatingCurrentTimer_Tick(object sender, EventArgs e)
        {
            if (OperatingCurrentTick >= 10000 && result.LoadCurrent > OperatingCurrent)
            {
                // LED Burned
                LedBurnedCount++;
                GameOverPrompt("Ooops! You burned the LED!");
                PauseGame();
                // Game over screen
            }

            if (MinimumOperatingCurrentTick >= 10000 && result.LoadCurrent < MinimumOperatingCurrent)
            {
                // LED Unpowered
                UnpoweredLedCount++;
                GameOverPrompt("Umm... You did not power the LED!");
                PauseGame();
                // Game over screen
            }

            if (result.LoadCurrent < MinimumOperatingCurrent && MinimumOperatingCurrentTick < 10000)
            {
                MinimumOperatingCurrentTick += 100;
                WarningLowProgressBar.Progress = Convert.ToInt32((MinimumOperatingCurrentTick / 10000f) * 100);
            }
            else if (MinimumOperatingCurrentTick > 0 && result.LoadCurrent > MinimumOperatingCurrent)
            {
                MinimumOperatingCurrentTick -= 100;
                WarningLowProgressBar.Progress = Convert.ToInt32((MinimumOperatingCurrentTick / 10000f) * 100);
                //ledBurnedIndicator.Visible = false;
            }

            if (result.LoadCurrent > OperatingCurrent && OperatingCurrentTick < 10000)
            {
                OperatingCurrentTick += 100;
                WarningHighProgressBar.Progress = Convert.ToInt32((OperatingCurrentTick / 10000f) * 100);
            }
            else if (OperatingCurrentTick > 0 && result.LoadCurrent < OperatingCurrent)
            {
                OperatingCurrentTick -= 100;
                WarningHighProgressBar.Progress = Convert.ToInt32((OperatingCurrentTick / 10000f) * 100);
                //ledBurnedIndicator.Visible = false;
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!DropDownCircuitElement(2))
            {
                //UpdateCircuitElementUI();
            }
        }


        #region Game Canvas UI
        public void SpawnCircuitElement(CircuitElementType circuitElementType, double voltage, double resistance)
        {
            UpdateCircuitElementUI();
            _currentCircuitElementDroppedOrientation = 1;
            if (WillUseHoldCircuitElement && CurrentCircuitElementHold != null)
            {
                holdOnCooldown = true;
                holdCooldownTick = 0;
                holdCooldownTimer.Start();

                circuitElementType = CurrentCircuitElementHold.Value.CircuitElementType;
                voltage = CurrentCircuitElementHold.Value.Voltage;
                resistance = CurrentCircuitElementHold.Value.Resistance;

                HoldComponentPbox.Image = null;
                HoldComponentLabel.Text = "";

            }
            CurrentCircuitElementDroppedResistance = resistance;
            CurrentCircuitElementDroppedVoltage = voltage;
            CurrentCircuitElementDroppedType = circuitElementType;

            CircuitElement circuitElement = null;
            PictureBox circuitElementPbox = new PictureBox();
            circuitElementPbox.BackColor = Color.Transparent;
            circuitElementPbox.Location = new Point(0, CircuitBlocks[CurrentBlockIndex].Location.Y - CircuitBlocks[CurrentBlockIndex].CircuitElementHeight - CircuitElementOffset);
            circuitElementPbox.Image = GetOrientedImageClone(circuitElementType, _currentCircuitElementDroppedOrientation);
            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    CurrentCircuitElementDroppedType = CircuitElementType.Resistor;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    CircuitBlocks[CurrentBlockIndex].Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
                case CircuitElementType.Source:
                    CurrentCircuitElementDroppedType = CircuitElementType.Source;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    CircuitBlocks[CurrentBlockIndex].Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
                case CircuitElementType.Diode:
                    CurrentCircuitElementDroppedType = CircuitElementType.Diode;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    CircuitBlocks[CurrentBlockIndex].Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
            }
        }

        public void SpawnCircuitBlock(CircuitBlockConnectionType CircuitConnection, Point _location, int _circuitElementWidth, int _circuitElementHeight)
        {         
            if (CurrentBlockIndex == -1) CurrentBlockIndex = 0;
            CircuitBlock circuitBlock = new CircuitBlock();
            circuitBlock.CircuitBlockConnectionType = CircuitConnection;
            circuitBlock.CircuitElementWidth = _circuitElementWidth;
            circuitBlock.CircuitElementHeight = _circuitElementHeight;
            circuitBlock.Location = _location;
            UpdateCircuitBlock(circuitBlock);
            Controls.Add(circuitBlock);
            circuitBlock.BringToFront();
            CircuitBlocks.Add(circuitBlock);
        }

        public void SpawnCircuitBlock(CircuitBlockState circuitBlockState, Point _location, int _circuitElementWidth, int _circuitElementHeight)
        {
            if (CurrentBlockIndex == -1) CurrentBlockIndex = 0;
            CircuitBlock circuitBlock = new CircuitBlock();
            circuitBlock.CircuitBlockState = circuitBlockState;
            circuitBlock.CircuitElementWidth = _circuitElementWidth;
            circuitBlock.CircuitElementHeight = _circuitElementHeight;
            circuitBlock.Location = _location;
            UpdateCircuitBlock(circuitBlock);
            Controls.Add(circuitBlock);
            circuitBlock.BringToFront();
            CircuitBlocks.Add(circuitBlock);
        }

        public void UpdateCircuitBlock(CircuitBlock circuitBlock)
        {          
            if (circuitBlock.CircuitBlockState == CircuitBlockState.Locked)
            {
                circuitBlock.BackgroundImage = LockedCircuitBlockImage;
                circuitBlock.BackgroundImageLayout = ImageLayout.Zoom;
                return;
            }
            switch (circuitBlock.CircuitBlockConnectionType)
            {
                case CircuitBlockConnectionType.Series:
                    circuitBlock.BackgroundImage = SeriesCircuitBlockImage;
                    circuitBlock.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                case CircuitBlockConnectionType.Parallel:
                    circuitBlock.BackgroundImage = ParallelCircuitBlockImage;
                    circuitBlock.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                case CircuitBlockConnectionType.Trash:
                    circuitBlock.BackgroundImage = TrashCircuitBlockImage;
                    circuitBlock.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
            }
        }

        public void ClearHoldCircuitElement()
        {
            HoldComponentPbox.Image = null;
            HoldComponentLabel.Text = "";

            holdCooldownTick = 0;
            holdOnCooldown = false;

            HoldCooldownProgressbar.Progress = 100;
            holdCooldownTimer.Stop();

            CurrentCircuitElementHold = null;
        }

        public void HoldCircuitElement(CircuitElementType type, double voltage, double resistance)
        {
            DifficultyManager.UpdateImageKeys(new List<Image>()
            {
                CircuitElementSourceSprite1,
                CircuitElementSourceSprite2,
                CircuitElementSourceSprite3,
                CircuitElementSourceSprite4,
                CircuitElementSourceSprite5
            },
            new List<Image>()
            {
                CircuitElementResistorSprite1,
                CircuitElementResistorSprite2,
                CircuitElementResistorSprite3,
                CircuitElementResistorSprite4,
                CircuitElementResistorSprite5
            });
            if (CurrentCircuitElementHold == null && !holdOnCooldown)
            {
                CircuitBlocks[CurrentBlockIndex].Controls.Remove(CurrentCircuitElementDropped);
                CurrentCircuitElementDropped = null;
                
                switch (type)
                {
                    case CircuitElementType.Resistor:
                        HoldComponentPbox.Image = DifficultyManager.ResistanceValues[resistance];
                        HoldComponentLabel.Text = resistance +  " Ω";
                        break;
                    case CircuitElementType.Source:
                        HoldComponentPbox.Image = DifficultyManager.VoltageValues[voltage];
                        HoldComponentLabel.Text = voltage + " V";
                        break;
                    case CircuitElementType.Diode:
                        HoldComponentPbox.Image = CircuitElementDiodeSprite;
                        HoldComponentLabel.Text = voltage + " V";
                        break;
                }


                CurrentCircuitElementHold = new CircuitElementTemp()
                {
                    CircuitElementType = type,
                    Voltage = voltage,
                    Resistance = resistance
                };

                nextComponentTimer.Start();
            }
        }


        public bool DropDownCircuitElement(int y)
        {
            if (CurrentCircuitElementDropped == null)
            {
                return false;
            }

            CurrentCircuitElementDropped.Parent = CircuitBlocks[CurrentBlockIndex];

            if (CurrentCircuitElementDropped.Location.Y + CurrentCircuitElementDropped.Height + y > 
                CircuitBlocks[CurrentBlockIndex].Location.Y + CircuitBlocks[CurrentBlockIndex].Height - 
                (CircuitBlocks[CurrentBlockIndex].CircuitElements.Count * CircuitBlocks[CurrentBlockIndex].CircuitElementHeight))
            {
                CurrentCircuitElementDropped.Location = new Point(0, 
                    CircuitBlocks[CurrentBlockIndex].Location.Y + CircuitBlocks[CurrentBlockIndex].Height - CurrentCircuitElementDropped.Height - 
                    (CircuitBlocks[CurrentBlockIndex].CircuitElements.Count * CircuitBlocks[CurrentBlockIndex].CircuitElementHeight));
                CircuitBlocks[CurrentBlockIndex].AddCircuitElement(CurrentCircuitElementDroppedType, CurrentCircuitElementDroppedVoltage, CurrentCircuitElementDroppedResistance, CurrentCircuitElementDroppedOrientation, CurrentCircuitElementDropped);
                CurrentCircuitElementDropped = null;

                if (CircuitBlocks[CurrentBlockIndex].CircuitElements.Count >= CircuitBlocks[CurrentBlockIndex].MaximumElements)
                {
                    CircuitBlocks[CurrentBlockIndex].CircuitBlockState = CircuitBlockState.Full;
                    int currentBlockIndex = CurrentBlockIndex;
                    CurrentBlockIndex++;
                    if (currentBlockIndex == CurrentBlockIndex)
                    {
                        CurrentBlockIndex--;
                        if (currentBlockIndex == CurrentBlockIndex)
                        {
                            CircuitOverflowCount++;
                            GameOverPrompt("You ran out of space!");
                            PauseGame();
                        }
                    }
                }
                nextComponentTimer.Start();

                UpdateCircuitElementUI();
                return false;
            }
            CurrentCircuitElementDropped.Location = new Point(0, CurrentCircuitElementDropped.Location.Y + y);
            return true;
        }

        public void SnapCurrentDropElementToLowest()
        {
            if (CurrentCircuitElementDropped == null) return;
            CurrentCircuitElementDropped.Location = new Point(0,
                    CircuitBlocks[CurrentBlockIndex].Location.Y + CircuitBlocks[CurrentBlockIndex].Height - CurrentCircuitElementDropped.Height -
                    (CircuitBlocks[CurrentBlockIndex].CircuitElements.Count * CircuitBlocks[CurrentBlockIndex].CircuitElementHeight));
        }
        #endregion

        [Category("Game Canvas Settings")]
        [Description("New Circuit ELement Spawn Offset")]
        [Editor("System.ComponentModel.Design.CollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public List<CircuitBlock> CircuitBlocks
        {
            get { return _circuitBlocks; }
            set { _circuitBlocks = value ?? new List<CircuitBlock>(); }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementResistorSprite5
        {
            get { return _circuitElementResistorSprite5; }
            set { _circuitElementResistorSprite5 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementResistorSprite4
        {
            get { return _circuitElementResistorSprite4; }
            set { _circuitElementResistorSprite4 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementResistorSprite3
        {
            get { return _circuitElementResistorSprite3; }
            set { _circuitElementResistorSprite3 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementResistorSprite2
        {
            get { return _circuitElementResistorSprite2; }
            set { _circuitElementResistorSprite2 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementResistorSprite1
        {
            get { return _circuitElementResistorSprite1; }
            set { _circuitElementResistorSprite1 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite5
        {
            get { return _circuitElementSourceSprite5; }
            set { _circuitElementSourceSprite5 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite4
        {
            get { return _circuitElementSourceSprite4; }
            set { _circuitElementSourceSprite4 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite3
        {
            get { return _circuitElementSourceSprite3; }
            set { _circuitElementSourceSprite3 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite2
        {
            get { return _circuitElementSourceSprite2; }
            set { _circuitElementSourceSprite2 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite1
        {
            get { return _circuitElementSourceSprite1; }
            set { _circuitElementSourceSprite1 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("LED Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementLedSprite
        {
            get { return _circuitElementLEDSprite; }
            set { _circuitElementLEDSprite = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Diode Sprite Normal")]
        [DefaultValue(null)]
        public Image CircuitElementDiodeSprite
        {
            get { return _circuitElementDiodeSprite; }
            set { _circuitElementDiodeSprite = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("New Circuit Element Spawn Offset")]
        [DefaultValue(null)]
        public int CircuitElementOffset
        {
            get { return _circuitElementSpawnOffsetY; }
            set { _circuitElementSpawnOffsetY = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Hold Element Picture Box")]
        [DefaultValue(null)]
        public PictureBox HoldComponentPbox
        {
            get { return _holdComponentPbox; }
            set { _holdComponentPbox = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Hold Element Label")]
        [DefaultValue(null)]
        public BigLabel HoldComponentLabel
        {
            get { return _holdComponentLabel; }
            set { _holdComponentLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Current Value Label")]
        [DefaultValue(null)]
        public BigLabel CurrentValueLabel
        {
            get { return _currentValueLabel; }
            set { _currentValueLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Initial Voltage Value Label")]
        [DefaultValue(null)]
        public BigLabel InitialVoltageValueLabel
        {
            get { return _initialVoltageSourceLabel; }
            set { _initialVoltageSourceLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Operating Current Progress Bar")]
        [DefaultValue(null)]
        public ProgressBar OperatingCurrentProgressBar
        {
            get { return _operatingCurrentProgressBar; }
            set { _operatingCurrentProgressBar = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Operating Current Max Label")]
        [DefaultValue(null)]
        public BigLabel OperatingCurrentMaxLabel
        {
            get { return _operatingCurrentMaxLabel; }
            set { _operatingCurrentMaxLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Operating Current Min Label")]
        [DefaultValue(null)]
        public BigLabel OperatingCurrentMinLabel
        {
            get { return _operatingCurrentMinLabel; }
            set { _operatingCurrentMinLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Warning High Progress Bar")]
        [DefaultValue(null)]
        public LostProgressBar WarningHighProgressBar
        {
            get { return _warningHighProgressBar; }
            set { _warningHighProgressBar = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Warning Low Progress Bar")]
        [DefaultValue(null)]
        public LostProgressBar WarningLowProgressBar
        {
            get { return _warningLowProgressBar; }
            set { _warningLowProgressBar = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Next Component Picture Box 1")]
        [DefaultValue(null)]
        public PictureBox NextComponentPictureBox1
        {
            get { return _nextComponentPbox1; }
            set { _nextComponentPbox1 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Next Component Label 1")]
        [DefaultValue(null)]
        public BigLabel NextComponentLabel1
        {
            get { return _nextComponentLabel1; }
            set { _nextComponentLabel1 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Next Component Picture Box 2")]
        [DefaultValue(null)]
        public PictureBox NextComponentPictureBox2
        {
            get { return _nextComponentPbox2; }
            set { _nextComponentPbox2 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Next Component Label 2")]
        [DefaultValue(null)]
        public BigLabel NextComponentLabel2
        {
            get { return _nextComponentLabel2; }
            set { _nextComponentLabel2 = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Locked Circuit Block Image")]
        [DefaultValue(null)]
        public Image LockedCircuitBlockImage
        {
            get { return _lockedCircuitBlockImage; }
            set { _lockedCircuitBlockImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Series Circuit Block Image")]
        [DefaultValue(null)]
        public Image SeriesCircuitBlockImage
        {
            get { return _seriesCircuitBlockImage; }
            set { _seriesCircuitBlockImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Parallel Circuit Block Image")]
        [DefaultValue(null)]
        public Image ParallelCircuitBlockImage
        {
            get { return _parallelCircuitBlockImage; }
            set { _parallelCircuitBlockImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Trash Circuit Block Image")]
        [DefaultValue(null)]
        public Image TrashCircuitBlockImage
        {
            get { return _trashCircuitBlockImage; }
            set { _trashCircuitBlockImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Joule Currency Label")]
        [DefaultValue(null)]
        public BigLabel JouleCurrencyLabel
        {
            get { return _jouleCurrencyLabel; }
            set { _jouleCurrencyLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Series Circuit Block Card Image")]
        [DefaultValue(null)]
        public Image SeriesCircuitBlockCardImage
        {
            get { return _seriesCircuitBlockCardImage; }
            set { _seriesCircuitBlockCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Parallel Circuit Block Card Image")]
        [DefaultValue(null)]
        public Image ParallelCircuitBlockCardImage
        {
            get { return _parallelCircuitBlockCardImage; }
            set { _parallelCircuitBlockCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Trash Circuit Block Card Image")]
        [DefaultValue(null)]
        public Image TrashCircuitBlockCardImage
        {
            get { return _trashCircuitBlockCardImage; }
            set { _trashCircuitBlockCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Source Increase Chance Card Image")]
        [DefaultValue(null)]
        public Image SourceIncreaseChanceCardImage
        {
            get { return _sourceIncreaseChanceCardImage; }
            set { _sourceIncreaseChanceCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Increase Chance Card Image")]
        [DefaultValue(null)]
        public Image ResistorIncreaseChanceCardImage
        {
            get { return _resistorIncreaseChanceCardImage; }
            set { _resistorIncreaseChanceCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Diode Increase Chance Card Image")]
        [DefaultValue(null)]
        public Image DiodeIncreaseChanceCardImage
        {
            get { return _diodeIncreaseChanceCardImage; }
            set { _diodeIncreaseChanceCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Increase Initial Voltage Card Image")]
        [DefaultValue(null)]
        public Image IncreaseInitialVoltageCardImage
        {
            get { return _initialVoltageIncreaseCardImage; }
            set { _initialVoltageIncreaseCardImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Series Circuit Block Card Description")]
        [DefaultValue(null)]
        public string SeriesCircuitBlockCardDescription
        {
            get { return _seriesCircuitBlockCardText; }
            set { _seriesCircuitBlockCardText = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Parallel Circuit Block Card Description")]
        [DefaultValue(null)]
        public string ParallelCircuitBlockCardDescription
        {
            get { return _parallelCircuitBlockCardText; }
            set { _parallelCircuitBlockCardText = value; }
        }


        [Category("Game Canvas Settings")]
        [Description("Trash Circuit Block Card Description")]
        [DefaultValue(null)]
        public string TrashCircuitBlockCardDescription
        {
            get { return _trashCircuitBlockCardText; }
            set { _trashCircuitBlockCardText = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Source Increase Chance Card Description")]
        [DefaultValue(null)]
        public string SourceIncreaseChanceCardDescription
        {
            get { return _sourceIncreaseChanceText; }
            set { _sourceIncreaseChanceText = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Diode Increase Chance Card Description")]
        [DefaultValue(null)]
        public string DiodeIncreaseChanceCardDescription
        {
            get { return _diodeIncreaseChanceText; }
            set { _diodeIncreaseChanceText = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Increase Chance Card Description")]
        [DefaultValue(null)]
        public string ResistorIncreaseChanceCardDescription
        {
            get { return _resistorIncreaseChanceText; }
            set { _resistorIncreaseChanceText = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Increase Initial Voltage Card Description")]
        [DefaultValue(null)]
        public string IncreaseInitialVoltageCardDescription
        {
            get { return _initialVoltageIncreaseText; }
            set { _initialVoltageIncreaseText = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Series Circuit Block Card Cost")]
        [DefaultValue(null)]
        public int SeriesCircuitBlockCardCost
        {
            get { return _seriesCircuitBlockCardCost; }
            set { _seriesCircuitBlockCardCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Parallel Circuit Block Card Cost")]
        [DefaultValue(null)]
        public int ParallelCircuitBlockCardCost
        {
            get { return _parallelCircuitBlockCardCost; }
            set { _parallelCircuitBlockCardCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Trash Circuit Block Card Cost")]
        [DefaultValue(null)]
        public int TrashCircuitBlockCardCost
        {
            get { return _trashCircuitBlockCardCost; }
            set { _trashCircuitBlockCardCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Source Increase Chance Card Cost")]
        [DefaultValue(null)]
        public int SourceIncreaseChanceCardCost
        {
            get { return _sourceIncreaseChanceCost; }
            set { _sourceIncreaseChanceCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Diode Increase Chance Card Cost")]
        [DefaultValue(null)]
        public int DiodeIncreaseChanceCardCost
        {
            get { return _diodeIncreaseChanceCost; }
            set { _diodeIncreaseChanceCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Increase Initial Voltage Card Cost")]
        [DefaultValue(null)]
        public int IncreaseInitialVoltageCardCost
        {
            get { return _initialVoltageIncreaseCost; }
            set { _initialVoltageIncreaseCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Increase Chance Card Cost")]
        [DefaultValue(null)]
        public int ResistorIncreaseChanceCardCost
        {
            get { return _resistorIncreaseChanceCost; }
            set { _resistorIncreaseChanceCost = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Maintain Timer Label")]
        [DefaultValue(null)]
        public BigLabel MaintainTimerLabel
        {
            get { return _maintainTimerLabel; }
            set { _maintainTimerLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Hold Cooldown Label")]
        [DefaultValue(null)]
        public BigLabel HoldCooldownLabel
        {
            get { return _holdCooldownLabel; }
            set { _holdCooldownLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Hold Cooldown Progress Bar")]
        [DefaultValue(null)]
        public LostProgressBar HoldCooldownProgressbar
        {
            get { return _holdCooldownProgressBar; }
            set { _holdCooldownProgressBar = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Level Label")]
        [DefaultValue(null)]
        public BigLabel LevelLabel
        {
            get { return _levelLabel; }
            set { _levelLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Rating Label")]
        [DefaultValue(null)]
        public BigLabel RatingLabel
        {
            get { return _ratingLabel; }
            set { _ratingLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Next Component Progress Bar")]
        [DefaultValue(null)]
        public LostProgressBar NextComponentProgressbar
        {
            get { return _nextComponentProgressbar; }
            set { _nextComponentProgressbar = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Game Message Label")]
        [DefaultValue(null)]
        public BigLabel GameMessageLabel
        {
            get { return _gameMessageLabel; }
            set { _gameMessageLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Warning Timer Label")]
        [DefaultValue(null)]
        public BigLabel WarningTimerLabel
        {
            get { return _warningTimerLabel; }
            set { _warningTimerLabel = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Play Button Image")]
        [DefaultValue(null)]
        public Image PlayButtonImage
        {
            get { return _playButtonImage; }
            set { _playButtonImage = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Pause Button Image")]
        [DefaultValue(null)]
        public Image PauseButtonImage
        {
            get { return _pauseButtonImage; }
            set { _pauseButtonImage = value; }
        }

        public CircuitBlock CircuitBlock
        {
            get => default;
            set
            {
            }
        }

        public CircuitElement CircuitElement
        {
            get => default;
            set
            {
            }
        }

        public MainGame MainGame
        {
            get => default;
            set
            {
            }
        }
    }
}
