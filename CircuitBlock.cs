using System;
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
    public enum CircuitBlockConnectionType
    {
        Series,
        Parallel
    }

    [Serializable]
    public partial class CircuitBlock : UserControl
    {
        public CircuitBlockConnectionType CircuitBlockConnectionType { get; set; }
        public List<CircuitElement> CircuitElements { get; set; } = new List<CircuitElement>();
        public int CurrentElementIndex { get; set; } = 0;

        private int _maximumElements = 4;
        private int _circuitElementWidth = 40;
        private int _circuitElementHeight = 40;

        public bool isEnabled { get; set; } = true;

        public CircuitBlock()
        {
            InitializeComponent();
        }

        public void UpdateCircuitBlockSize()
        {
            Height = _circuitElementHeight * _maximumElements;
            Width = _circuitElementWidth;
        }

        public void RemoveCircuitElement(ref GameCanvas gameCanvas, int circuitElementIndex)
        {
            if (circuitElementIndex < 0 || circuitElementIndex >= CircuitElements.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(circuitElementIndex), "Invalid circuit element index.");
            }
            gameCanvas.Controls.Remove(CircuitElements[circuitElementIndex].CircuitELementUI);
            CircuitElements.RemoveAt(circuitElementIndex);
            gameCanvas.Invalidate();
        }

        public void AddCircuitElement(CircuitElementType circuitElementType, double voltage, double resistance, int orientation, PictureBox ciruitElementPbox)
        {
            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    CircuitElement circuitElement = new GameResistor();
                    circuitElement.circuitElementType = CircuitElementType.Resistor;
                    circuitElement.Voltage = voltage;
                    circuitElement.Resistance = resistance;
                    circuitElement.Orientation = orientation;
                    circuitElement.CircuitELementUI = ciruitElementPbox;
                    CircuitElements.Add(circuitElement);
                    break;
                case CircuitElementType.Source:
                    circuitElement = new GameSource();
                    circuitElement.circuitElementType = CircuitElementType.Source;
                    circuitElement.Voltage = voltage;
                    circuitElement.Resistance = resistance;
                    circuitElement.Orientation = orientation;
                    circuitElement.CircuitELementUI = ciruitElementPbox;
                    CircuitElements.Add(circuitElement);
                    break;
                case CircuitElementType.Diode:
                    circuitElement = new CircuitElement();
                    circuitElement.circuitElementType = CircuitElementType.Diode;
                    circuitElement.Voltage = voltage;
                    circuitElement.Resistance = resistance;
                    circuitElement.Orientation = orientation;
                    circuitElement.CircuitELementUI = ciruitElementPbox;
                    CircuitElements.Add(circuitElement);
                    break;
            }
        }

        public double GetEquivalentResistance()
        {
            double equivalentResistance = 0;
            foreach (var element in CircuitElements)
            {
                if (element.circuitElementType == CircuitElementType.Diode && element.Orientation == 0) // Reverse Biased
                {
                    return double.NaN;
                }
                else if (element.circuitElementType == CircuitElementType.Diode)
                {
                    continue;
                }
                equivalentResistance += element.Resistance;
            }
            return equivalentResistance;
        }

        public double GetEquivalentSourceVoltage()
        {
            double equivalentVoltage = 0;
            foreach (var element in CircuitElements)
            {
                if (element.circuitElementType == CircuitElementType.Diode && element.Orientation == 0) // Reverse Biased
                {
                    return double.NaN;
                }
                else if (element.circuitElementType == CircuitElementType.Diode)
                {
                    equivalentVoltage -= element.Voltage;
                    continue;
                }
                equivalentVoltage += element.Voltage;
            }
            return equivalentVoltage;
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
      
    }
}
