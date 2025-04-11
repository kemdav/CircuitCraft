﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitCraft
{
    public partial class GameCanvas : UserControl
    {
        public List<CircuitElement> CircuitSources { get; set; }
        public double OperatingCurrent { get; set; } = 0;
        public int OperatingCurrentTick { get; set; } = 0;

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
            }
        }

        public PictureBox? CurrentCircuitElementDropped { get; set; }
        public double CurrentCircuitElementDroppedResistance { get; set; }
        public double CurrentCircuitElementDroppedVoltage { get; set; }

        private List<CircuitBlock> _circuitBlocks { get; set; } = new List<CircuitBlock>();

        private Image _circuitElementSourceSprite;
        private Image _circuitElementResistorSprite;
        private Image _circuitElementLEDSprite;
        private Image _circuitElementDiodeSprite;
        
        private int _circuitElementSpawnOffsetY = 20;

        public GameCanvas()
        {
            InitializeComponent();
            if (_circuitBlocks == null)
            {
                _circuitBlocks = new List<CircuitBlock>();
            }
        }

        public void AddCircuitSource(double voltage)
        {
            CircuitElement circuitElement = new GameSource();
            circuitElement.Voltage = voltage;
            //circuitElement.CircuitElementSprite = CircuitElementSourceSprite;
            CircuitSources.Add(circuitElement);
        }

        public void ClearCircuitElements()
        {
            foreach (var block in CircuitBlocks)
            {
                block.CircuitElements.Clear();
                foreach (var element in block.CircuitElementsUI)
                {
                    Controls.Remove(element);
                    Invalidate();
                }
            }
        }


        #region Game Canvas UI
        public void SpawnCircuitElement(CircuitElementType circuitElementType, double voltage, double resistance)
        {
            CurrentCircuitElementDroppedResistance = resistance;
            CurrentCircuitElementDroppedVoltage = voltage;
            CircuitElement circuitElement = null;
            PictureBox circuitElementPbox = new PictureBox();
            circuitElementPbox.Location = new Point(CircuitBlocks[CurrentBlockIndex].Location.X, CircuitBlocks[CurrentBlockIndex].Location.Y - CircuitBlocks[CurrentBlockIndex].CircuitElementHeight - CircuitElementOffset);
            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    circuitElementPbox.Image = CircuitElementResistorSprite;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
                case CircuitElementType.Source:
                    circuitElementPbox.Image = CircuitElementSourceSprite;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    CurrentCircuitElementDropped = circuitElementPbox;
                    break;
                case CircuitElementType.Diode:
                    circuitElementPbox.Image = CircuitElementDiodeSprite;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(circuitElementPbox);
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

      

        public bool DropDownCircuitElement(int y)
        {
            if (CurrentCircuitElementDropped == null)
            {
                return false;
            }
            if (CurrentCircuitElementDropped.Location.Y + CurrentCircuitElementDropped.Height + y > 
                CircuitBlocks[CurrentBlockIndex].Location.Y + CircuitBlocks[CurrentBlockIndex].Height - 
                (CircuitBlocks[CurrentBlockIndex].CircuitElements.Count * CircuitBlocks[CurrentBlockIndex].CircuitElementHeight))
            {
                CurrentCircuitElementDropped.Location = new Point(CircuitBlocks[CurrentBlockIndex].Location.X, 
                    CircuitBlocks[CurrentBlockIndex].Location.Y + CircuitBlocks[CurrentBlockIndex].Height - CurrentCircuitElementDropped.Height - 
                    (CircuitBlocks[CurrentBlockIndex].CircuitElements.Count * CircuitBlocks[CurrentBlockIndex].CircuitElementHeight));
                CircuitBlocks[CurrentBlockIndex].AddCircuitElement(CircuitElementType.Resistor, CurrentCircuitElementDroppedVoltage, CurrentCircuitElementDroppedResistance);
                CurrentCircuitElementDropped = null;
                return false;
            }
            CurrentCircuitElementDropped.Location = new Point(CircuitBlocks[CurrentBlockIndex].Location.X, CurrentCircuitElementDropped.Location.Y + y);
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
        [Description("Diode Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementDiodeSprite
        {
            get { return _circuitElementDiodeSprite; }
            set { _circuitElementDiodeSprite = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("New Circuit ELement Spawn Offset")]
        [DefaultValue(null)]
        public int CircuitElementOffset
        {
            get { return _circuitElementSpawnOffsetY; }
            set { _circuitElementSpawnOffsetY = value; }
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
