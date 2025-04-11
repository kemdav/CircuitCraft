using CircuitCraft;
using SpiceSharp.Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CircuitCraft
{
    public enum CircuitElementType
    {
        Source,
        Resistor,
        Diode
    }
    public class CircuitElement
    {      
        public CircuitElementType circuitElementType { get; set; }
        public byte[]? CircuitElementSprite { get; set; }
        public double Resistance { get; set; } = 0;
        public double Voltage { get; set; } = 0;
        public double Current { get; set; } = 0;
    }

    public class GameResistor : CircuitElement
    {
        public GameResistor()
        {
            circuitElementType = CircuitElementType.Resistor;
        }
    }

    public class GameSource : CircuitElement
    {
        public GameSource()
        {
            circuitElementType = CircuitElementType.Source;
        }
    }

    public class GameCircuitLoad : CircuitElement
    {
        public GameCircuitLoad()
        {
            circuitElementType = CircuitElementType.Source;
        }
    }

    public class GameDiode : CircuitElement
    {
        public GameDiode()
        {
            circuitElementType = CircuitElementType.Diode;
        }
    }
}
