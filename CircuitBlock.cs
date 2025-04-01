using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitCraft
{
    public enum CircuitBlockType
    {
        Series,
        Parallel
    }
    public class CircuitBlock
    {
        public List<CircuitElement> circuitElements = new List<CircuitElement>();
        public CircuitBlockType circuitBlockType { get; set; }
        public int maximumNumber { get; set; } = 3;

        public CircuitBlock(CircuitBlockType circuitBlockType)
        {
            this.circuitBlockType = circuitBlockType;
        }
    }
}
