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
    public partial class CircuitBlock : UserControl
    {
        public List<CircuitElement> CircuitElements { get; set; } = new List<CircuitElement>();
        public int CurrentElementIndex { get; set; } = 0;

        private int _maximumElements = 4;
        private int _circuitElementWidth = 40;
        private int _circuitElementHeight = 40;

        private Image _circuitElementResistorSprite;

        public CircuitBlock()
        {
            InitializeComponent();
        }

        public void UpdateCircuitBlockSize()
        {
            Height = _circuitElementHeight * _maximumElements;
            Width = _circuitElementWidth;
        }

        [Category("Circuit Block Settings")]
        [Description("Circuit Block Properties")]
        [DefaultValue(4)]
        public int MaximumElements
        {
            get { return _maximumElements; }
            set 
            { 
                _maximumElements = value;
                UpdateCircuitBlockSize();
            }
        }

        [Category("Circuit Block Settings")]
        [Description("Circuit Element Width")]
        [DefaultValue(40)]
        public int CircuitElementWidth
        {
            get { return _circuitElementWidth; }
            set 
            { 
                _circuitElementWidth = value; 
                UpdateCircuitBlockSize();
            }
        }

        [Category("Circuit Block Settings")]
        [Description("Circuit Element Height")]
        [DefaultValue(40)]
        public int CircuitElementHeight
        {
            get { return _circuitElementHeight; }
            set 
            { 
                _circuitElementHeight = value;
                UpdateCircuitBlockSize();
            }
        }

        [Category("Circuit Block Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSprite
        {
            get { return _circuitElementResistorSprite; }
            set { _circuitElementResistorSprite = value; }
        }
    }
}
