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
        public struct CircuitElementHold
        {
            public CircuitElementType CircuitElementType;
            public double Voltage;
            public double Resistance;
        }

        public CircuitElementHold? CurrentCircuitElementHold = null;
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
                if (value == 1)
                {
                    _currentCircuitElementDroppedOrientation = value;
                    CurrentCircuitElementDropped?.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
                else if (value == 0)
                {
                    _currentCircuitElementDroppedOrientation = value;
                    Image currentImage = CurrentCircuitElementDropped?.Image;
                    if (currentImage != null)
                    {
                        currentImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        CurrentCircuitElementDropped.Image = currentImage;
                    }
                }
            }
        }

        public double CurrentCircuitElementDroppedResistance { get; set; }
        public double CurrentCircuitElementDroppedVoltage { get; set; }
        public CircuitElementType CurrentCircuitElementDroppedType { get; set; }

        public bool WillUseHoldCircuitElement { get; set; } = false;

        private List<CircuitBlock> _circuitBlocks { get; set; } = new List<CircuitBlock>();

        private Image _circuitElementSourceSprite;
        private Image _circuitElementResistorSprite;
        private Image _circuitElementLEDSprite;
        private Image _circuitElementDiodeSprite;

        private PictureBox _holdComponentPbox;
        private BigLabel _holdComponentLabel;

        private BigLabel _currentValueLabel;

        private BigLabel _initialVoltageSourceLabel;

        private ProgressBar _operatingCurrentProgressBar;
        private BigLabel _operatingCurrentMaxLabel;
        private BigLabel _operatingCurrentMinLabel;

        private LostProgressBar _warningHighProgressBar;
        private LostProgressBar _warningLowProgressBar;

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

        private CircuitSimulator.LoadCalculationResult result;
        public double SourceVoltage = 10;
        public double LoadResistance = 0;

        public void UpdateCircuitElementUI()
        {
            double rangeScale = (100 - 0) / (OperatingCurrent - MinimumOperatingCurrent);
            result = CircuitSimulator.CalculateLoadState(CircuitBlocks, SourceVoltage, LoadResistance);
            double normalized_value = ((result.LoadCurrent - MinimumOperatingCurrent) * rangeScale);
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
            CurrentCircuitElementDroppedOrientation = 1;
            if (WillUseHoldCircuitElement && CurrentCircuitElementHold != null)
            {
                circuitElementType = CurrentCircuitElementHold.Value.CircuitElementType;
                voltage = CurrentCircuitElementHold.Value.Voltage;
                resistance = CurrentCircuitElementHold.Value.Resistance;

                HoldComponentPbox.Image = null;
                HoldComponentLabel.Text = "";

                WillUseHoldCircuitElement = false;
            }
            CurrentCircuitElementDroppedResistance = resistance;
            CurrentCircuitElementDroppedVoltage = voltage;
            CircuitElement circuitElement = null;
            PictureBox circuitElementPbox = new PictureBox();
            circuitElementPbox.BackColor = Color.Transparent;
            circuitElementPbox.BringToFront();
            circuitElementPbox.Location = new Point(CircuitBlocks[CurrentBlockIndex].Location.X, CircuitBlocks[CurrentBlockIndex].Location.Y - CircuitBlocks[CurrentBlockIndex].CircuitElementHeight - CircuitElementOffset);
            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    CurrentCircuitElementDroppedType = CircuitElementType.Resistor;
                    circuitElementPbox.Image = CircuitElementResistorSprite;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    CircuitBlocks[CurrentBlockIndex].Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
                case CircuitElementType.Source:
                    CurrentCircuitElementDroppedType = CircuitElementType.Source;
                    circuitElementPbox.Image = CircuitElementSourceSprite;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    CircuitBlocks[CurrentBlockIndex].Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
                case CircuitElementType.Diode:
                    CurrentCircuitElementDroppedType = CircuitElementType.Diode;
                    circuitElementPbox.Image = CircuitElementDiodeSprite;
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
            Controls.Add(circuitBlock);
            circuitBlock.BringToFront();
            CircuitBlocks.Add(circuitBlock);
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


                CurrentCircuitElementHold = new CircuitElementHold()
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
