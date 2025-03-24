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
    public class CircuitElement
    {
        public string Type { get; set; }
        public Point Location { get; set; }
        public string ImageFileName { get; set; }
        public int RotationAngle { get; set; } // Degrees

        public List<CircuitNode> Nodes { get; set; } = new List<CircuitNode>();
        public double Voltage { get; set; } = 0.0; // Voltage (V)
        public double Current { get; set; } = 0.0; // Current (A)
        public double Resistance { get; set; } = 0.0; // Resistance (Ω)

        public CircuitElement(string type, Point location, string imageFileName)
        {
            Type = type;
            Location = location;
            ImageFileName = imageFileName;
            RotationAngle = 0;

            if (type == "Battery")
            {
                Nodes.Add(new CircuitNode("Positive", new Point(0, 10), this));
                Nodes.Add(new CircuitNode("Negative", new Point(40, 10), this));
            }
            else if (type == "Resistor")
            {
                Nodes.Add(new CircuitNode("Left", new Point(location.X, location.Y + 10), this));
                Nodes.Add(new CircuitNode("Right", new Point(location.X + 40, location.Y + 10), this));
            }
        }

        public void UpdateNodes(Point newLocation)
        {
            Location = newLocation;

            if (Type == "Battery")
            {
                Nodes[0].Location = new Point(newLocation.X,
                                              newLocation.Y + 60);
                Nodes[1].Location = new Point(newLocation.X + 120,
                                              newLocation.Y + 60);
            }
        }
    }

    public class Wire
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        // For more complex wires, store a list of points to represent polyline segments
        public List<Point> Points { get; set; } = new List<Point>();

        public Wire(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
            Points.Add(start);
            Points.Add(end);
        }
    }

    public class CircuitNode
    {
        public string Name { get; set; }

        public Point Location { get; set; }

        public Point RelativeOffset { get; set; } 

        public CircuitElement ParentElement { get; set; }

        public Rectangle Bounds
        {
            get
            {
                int size = 6;
                return new Rectangle(Location.X - size / 2, Location.Y - size / 2, size, size);
            }
        }

        public CircuitNode(string name, Point relativeOffset, CircuitElement parent)
        {
            Name = name;
            RelativeOffset = relativeOffset;
            ParentElement = parent;
            Location = Point.Empty; // Will be computed later
        }
    }
}
