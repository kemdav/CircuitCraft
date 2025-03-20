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
        public string ImageFileName { get; set; }
        public int RotationAngle { get; set; } // New property for rotation angle (in degrees)

        // Electrical properties
        public double PotentialDifference { get; set; } = 0.0; // Voltage (V)
        public double Current { get; set; } = 0.0; // Current (A)
        public double Resistance { get; set; } = 0.0; // Resistance (Ω)

        public CircuitElement(string type, Point location, string imageFileName)
        {
            Type = type;
            Location = location;
            ImageFileName = imageFileName;
            RotationAngle = 0; // Initialize rotation angle to 0
        }
    }

    public class Wire
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        // For more complex wires, you can store a list of points to represent polyline segments
        public List<Point> Points { get; set; } = new List<Point>();

        public Wire(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
            Points.Add(start);
            Points.Add(end);
        }
    }

}
