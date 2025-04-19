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
using Timer = System.Windows.Forms.Timer;

namespace CircuitCraft
{
    public partial class GameCanvas : UserControl
    {
        public struct CircuitElementTemp
        {
            public CircuitElementType CircuitElementType;
            public double Voltage;
            public double Resistance;
        }

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
        public double OperatingCurrent { get; set; } = 0.2;
        public double MinimumOperatingCurrent { get; set; } = 0.1;
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
                    if (CircuitBlocks[_currentBlockIndex].CircuitBlockConnectionType == CircuitBlockConnectionType.Locked)
                    {
                        for (int i = 1; i < CircuitBlocks.Count; i++)
                        {
                            if (_currentBlockIndex < previousIndex)
                            {
                                if (_currentBlockIndex - i > -1)
                                {
                                    if (CircuitBlocks[_currentBlockIndex - i].CircuitBlockConnectionType != CircuitBlockConnectionType.Locked)
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
                                    if (CircuitBlocks[_currentBlockIndex + i].CircuitBlockConnectionType != CircuitBlockConnectionType.Locked)
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

        private Image _circuitElementSourceSprite;
        private Image _circuitElementResistorSprite;
        private Image _circuitElementLEDSprite;
        private Image _circuitElementDiodeSprite;

        private PictureBox _holdComponentPbox;
        private BigLabel _holdComponentLabel;

        private PictureBox _nextComponentPbox1;
        private BigLabel _nextComponentLabel1;

        private PictureBox _nextComponentPbox2;
        private BigLabel _nextComponentLabel2;


        private BigLabel _currentValueLabel;

        private BigLabel _initialVoltageSourceLabel;

        private BigLabel _jouleCurrencyLabel;

        private ProgressBar _operatingCurrentProgressBar;
        private BigLabel _operatingCurrentMaxLabel;
        private BigLabel _operatingCurrentMinLabel;

        private LostProgressBar _warningHighProgressBar;
        private LostProgressBar _warningLowProgressBar;

        private Image _lockedCircuitBlockImage;

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
        #endregion

        private int _circuitElementSpawnOffsetY = 20;

        public Timer gameTimer = new Timer();
        public Timer warningTimer = new Timer();

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
                if (circuitBlock.CircuitBlockConnectionType == CircuitBlockConnectionType.Locked)
                {
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
                return; 
            }
            NextCircuitElements.RemoveAt(0);
            FillUpNextComponents();
        }

        private Image GetOrientedImageClone(CircuitElementType type, int orientation)
        {
            Image baseImage = null;
            switch (type)
            {
                case CircuitElementType.Resistor:
                    baseImage = this.CircuitElementResistorSprite;
                    break;
                case CircuitElementType.Source:
                    baseImage = this.CircuitElementSourceSprite;
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

        public void FillUpNextComponents()
        {
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
                                nextComponentsPboxs[i].Image = CircuitElementResistorSprite;
                                nextComponentsLabels[i].Text = NextCircuitElements[0].Resistance + " Ω";
                                break;
                            case CircuitElementType.Source:
                                nextComponentsPboxs[i].Image = CircuitElementSourceSprite;
                                nextComponentsLabels[i].Text = NextCircuitElements[0].Voltage + " V";
                                break;
                            case CircuitElementType.Diode:
                                nextComponentsPboxs[i].Image = CircuitElementDiodeSprite;
                                nextComponentsLabels[i].Text = NextCircuitElements[0].Voltage + " V";
                                break;
                        }
                        continue; 
                    }
                    NextCircuitElements.Add(circuitElement);

                    switch (circuitElement.CircuitElementType)
                    {
                        case CircuitElementType.Resistor:
                            nextComponentsPboxs[i].Image = CircuitElementResistorSprite;
                            nextComponentsLabels[i].Text = circuitElement.Resistance + " Ω";
                            break;
                        case CircuitElementType.Source:
                            nextComponentsPboxs[i].Image = CircuitElementSourceSprite;
                            nextComponentsLabels[i].Text = circuitElement.Voltage + " V";
                            break;
                        case CircuitElementType.Diode:
                            nextComponentsPboxs[i].Image = CircuitElementDiodeSprite;
                            nextComponentsLabels[i].Text = circuitElement.Voltage + " V";
                            break;
                    }

                }

            }
        }

        public CircuitElementTemp GenerateRandomCircuitComponent()
        {
            Random rng = new Random();
            int randomNumber1 = rng.Next(1, 101);
            int randomNumber2 = rng.Next(1, 4);

            double randomResistance = 0;
            double randomVoltage = 0;

            CircuitElementType circuitElementType;

            switch (randomNumber2)
            {
                case 1:
                    circuitElementType = CircuitElementType.Resistor;
                    break;
                case 2:
                    circuitElementType = CircuitElementType.Source;
                    break;
                case 3:
                    circuitElementType = CircuitElementType.Diode;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(randomNumber2), "Invalid random number for circuit element type.");
            }

            if (randomNumber1 > 0 && randomNumber1 <= 20)
            {
                randomResistance = 5;
                randomVoltage = 5;
            }
            else if (randomNumber1 > 20 && randomNumber1 <= 40)
            {
                randomResistance = 10;
                randomVoltage = 10;
            }
            else if (randomNumber1 > 40 && randomNumber1 <= 60)
            {
                randomResistance = 15;
                randomVoltage = 15;
            }
            else if (randomNumber1 > 60 && randomNumber1 <= 80)
            {
                randomResistance = 20;
                randomVoltage = 20;
            }
            else if (randomNumber1 > 80 && randomNumber1 <= 100)
            {
                randomResistance = 25;
                randomVoltage = 25;
            }

            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    return new CircuitElementTemp()
                    {
                        CircuitElementType = circuitElementType,
                        Resistance = randomResistance
                    };
                case CircuitElementType.Source:
                    return new CircuitElementTemp()
                    {
                        CircuitElementType = circuitElementType,
                        Voltage = randomVoltage
                    };
                case CircuitElementType.Diode:
                    return new CircuitElementTemp()
                    {
                        CircuitElementType = circuitElementType,
                        Voltage = randomVoltage
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(circuitElementType), "Invalid circuit element type.");
            }
        }

        private CircuitSimulator.LoadCalculationResult result;
        public double SourceVoltage = 10;
        public double LoadResistance = 0;

        public void UpdateCircuitElementUI()
        {
            double rangeScale = (100 - 0) / (OperatingCurrent - MinimumOperatingCurrent);
            result = CircuitSimulator.CalculateLoadState(CircuitBlocks, SourceVoltage, LoadResistance);
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
                //gameCanvas.OperatingCurrentTick = 0;
                //operatingCurrentProgress.Progress = 0;

                //ledBurnedIndicator.Visible = true;
            }

            // In the final game, the indicator will be the LED icon itself on how bright it is
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
                circuitElementType = CurrentCircuitElementHold.Value.CircuitElementType;
                voltage = CurrentCircuitElementHold.Value.Voltage;
                resistance = CurrentCircuitElementHold.Value.Resistance;

                HoldComponentPbox.Image = null;
                HoldComponentLabel.Text = "";

                CurrentCircuitElementHold = null;

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

        public void UpdateCircuitBlock(CircuitBlock circuitBlock)
        {
            if (circuitBlock.CircuitBlockConnectionType == CircuitBlockConnectionType.Locked)
            {
                circuitBlock.BackgroundImage = LockedCircuitBlockImage;
            }
        }

        public void HoldCircuitElement(CircuitElementType type, double voltage, double resistance)
        {
            // TODO Add cooldown

            if (CurrentCircuitElementHold == null)
            {
                CircuitBlocks[CurrentBlockIndex].Controls.Remove(CurrentCircuitElementDropped);
                CurrentCircuitElementDropped = null;
                
                switch (type)
                {
                    case CircuitElementType.Resistor:
                        HoldComponentPbox.Image = CircuitElementResistorSprite;
                        HoldComponentLabel.Text = resistance +  " Ω";
                        break;
                    case CircuitElementType.Source:
                        HoldComponentPbox.Image = CircuitElementSourceSprite;
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
        public Image CircuitElementResistorSprite
        {
            get { return _circuitElementResistorSprite; }
            set { _circuitElementResistorSprite = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite
        {
            get { return _circuitElementSourceSprite; }
            set { _circuitElementSourceSprite = value; }
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
