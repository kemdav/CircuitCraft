using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitCraft
{
    public class CircuitElement
    {
        public string Type { get; set; }
        public Point Location { get; set; }
        public string ImageFileName { get; set; } // Store image file name (or resource name)

        public CircuitElement(string type, Point location, string imageFileName)
        {
            Type = type;
            Location = location;
            ImageFileName = imageFileName;
        }
    }
}
