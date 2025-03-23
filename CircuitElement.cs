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
        public int RotationAngle { get; set; } // New property for rotation angle (in degrees)

        public List<CircuitNode> Nodes { get; set; } = new List<CircuitNode>();

        // Electrical properties
        public double Voltage { get; set; } = 0.0; // Voltage (V)
        public double Current { get; set; } = 0.0; // Current (A)
        public double Resistance { get; set; } = 0.0; // Resistance (Ω)

        public CircuitElement(string type, Point location, string imageFileName)
        {
            Type = type;
            Location = location;
            ImageFileName = imageFileName;
            RotationAngle = 0; // Initialize rotation angle to 0

            if (type == "Battery")
            {
                // Example: For a battery, the nodes might be at fixed offsets relative to the element's location.
                Nodes.Add(new CircuitNode("Positive", new Point(0, 10), this));
                Nodes.Add(new CircuitNode("Negative", new Point(40, 10), this));
            }
            else if (type == "Resistor")
            {
                // For a resistor, nodes at the left and right ends
                Nodes.Add(new CircuitNode("Left", new Point(location.X, location.Y + 10), this));
                Nodes.Add(new CircuitNode("Right", new Point(location.X + 40, location.Y + 10), this));
            }
        }

        public void UpdateNodes(Point newLocation)
        {
            // Update this element's location
            Location = newLocation;

            // Recalculate the node positions, but don't add new nodes!
            if (Type == "Battery")
            {
                // For example, if you have exactly two nodes in your constructor:
                //   Nodes.Add(new CircuitNode("Positive", new Point(0, 10), this));
                //   Nodes.Add(new CircuitNode("Negative", new Point(40, 10), this));
                // then just update them here:
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

    public class CircuitNode
    {
        // A friendly name or identifier (e.g., "Positive", "Negative", "Input", etc.)
        public string Name { get; set; }

        // The absolute location of this node on the grid
        public Point Location { get; set; }

        public Point RelativeOffset { get; set; } // Offset relative to the parent element

        // Optionally, reference to the parent element
        public CircuitElement ParentElement { get; set; }

        // A helper property for hit-testing (for example, a small circle around the node)
        public Rectangle Bounds
        {
            get
            {
                int size = 6; // diameter of the node indicator
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
