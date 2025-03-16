using System.Drawing;
using System.Windows.Forms; // Import for drawing functionality
using System;
using System.Drawing.Drawing2D;
using System.Reflection; // Add this for Math functions

public static class GeometryHelper
{
    public static Point GetCenterPoint(CircuitElement element)
    {
        if (element is Wire wire)
        {
            return new Point((wire.Location.X + wire.EndPoint.X) / 2, (wire.Location.Y + wire.EndPoint.Y) / 2);
        }
        return new Point(element.Location.X + element.Width / 2, element.Location.Y + element.Height / 2);
    }

    public static Point RotatePoint(Point pointToRotate, Point centerPoint, float angleDegrees)
    {
        double angleRadians = angleDegrees * (Math.PI / 180);
        double cos = Math.Cos(angleRadians);
        double sin = Math.Sin(angleRadians);
        double x = centerPoint.X + (pointToRotate.X - centerPoint.X) * cos - (pointToRotate.Y - centerPoint.Y) * sin;
        double y = centerPoint.Y + (pointToRotate.X - centerPoint.X) * sin + (pointToRotate.Y - centerPoint.Y) * cos;
        return new Point((int)Math.Round(x), (int)Math.Round(y));
    }
}

public static class DrawingHelper
{
    public static void DrawElement(Graphics g, CircuitElement element)
    {
        if (element is Wire wire)
        {
            DrawWire(g, wire); // Use a dedicated method
        }
        else if (element.Image != null)
        {
            g.DrawImage(element.Image, element.Location.X, element.Location.Y, element.Width, element.Height);
        }
    }
    private static void DrawWire(Graphics g, Wire wire)
    {
        // Determine if the wire is horizontal or vertical
        if (wire.Location.X == wire.EndPoint.X) // Vertical
        {
            int height = Math.Abs(wire.EndPoint.Y - wire.Location.Y);
            // Ensure we draw from top to bottom
            int topY = Math.Min(wire.Location.Y, wire.EndPoint.Y);
            g.DrawImage(wire.Image, wire.Location.X, topY, wire.Width, height);

        }
        else // Horizontal (we've already ensured it's not diagonal)
        {
            int width = Math.Abs(wire.EndPoint.X - wire.Location.X);
            // Ensure we draw from left to right
            int leftX = Math.Min(wire.Location.X, wire.EndPoint.X);
            g.DrawImage(wire.Image, leftX, wire.Location.Y, width, wire.Height);
        }
        // Draw endpoint handles
        int handleSize = 8;
        g.FillRectangle(Brushes.Red, wire.Location.X - handleSize / 2, wire.Location.Y - handleSize / 2, handleSize, handleSize);
        g.FillRectangle(Brushes.Green, wire.EndPoint.X - handleSize / 2, wire.EndPoint.Y - handleSize / 2, handleSize, handleSize);

    }
}


public static class InteractionHelper
{
    public static bool HitTestElement(CircuitElement element, Point point)
    {
        if (element is Wire wire)
        {
            return HitTestWire(wire, point);
        }
        else
        {
            // Check if the point is within the  rectangle
            return new Rectangle(element.Location.X, element.Location.Y, element.Width, element.Height).Contains(point);
        }

    }
    private static bool HitTestWire(Wire wire, Point point)
    {
        int tolerance = 5;
        // Simplifies as no rotation
        if (wire.Location.X == wire.EndPoint.X) //Vertical
        {
            int topY = Math.Min(wire.Location.Y, wire.EndPoint.Y);
            int bottomY = Math.Max(wire.Location.Y, wire.EndPoint.Y);
            return point.X >= wire.Location.X - tolerance && point.X <= wire.Location.X + tolerance &&
                   point.Y >= topY - tolerance && point.Y <= bottomY + tolerance;
        }
        else //Horizontal
        {
            int leftX = Math.Min(wire.Location.X, wire.EndPoint.X);
            int rightX = Math.Max(wire.Location.X, wire.EndPoint.X);
            return point.X >= leftX - tolerance && point.X <= rightX + tolerance &&
                   point.Y >= wire.Location.Y - tolerance && point.Y <= wire.Location.Y + tolerance;
        }
    }

    public static bool IsNearWireEndPoint(Wire wire, Point p, out bool isStartPoint)
    {
        isStartPoint = false;
        int handleSize = 8;
        //Simplified hit test logic as no rotation
        Rectangle startHandleRect = new Rectangle(wire.Location.X - handleSize / 2, wire.Location.Y - handleSize / 2, handleSize, handleSize);
        Rectangle endHandleRect = new Rectangle(wire.EndPoint.X - handleSize / 2, wire.EndPoint.Y - handleSize / 2, handleSize, handleSize);

        if (startHandleRect.Contains(p)) { isStartPoint = true; return true; }
        else if (endHandleRect.Contains(p)) { isStartPoint = false; return true; }
        return false;
    }
    public static void UpdateWireEndPoint(Wire wire, Point newPosition, bool isStartPoint)
    {
        // Keep only the relevant coordinate (X for vertical, Y for horizontal)
        if (wire.Location.X == wire.EndPoint.X) // Vertical
        {
            newPosition.X = wire.Location.X; // Keep X constant
        }
        else // Horizontal
        {
            newPosition.Y = wire.Location.Y; // Keep Y constant
        }

        if (isStartPoint)
        {
            wire.Location = newPosition;
        }
        else
        {
            wire.EndPoint = newPosition;
        }
    }
}



public abstract class CircuitElement
{
    public Point Location { get; set; }
    public int Width { get; set; } = 40; // Example default width
    public int Height { get; set; } = 40; // Example default height
    public float Rotation { get; set; } = 0;
    public Image Image { get; set; } // Add an Image property

    // Simplified abstract methods
    public abstract int IsConnectedTo(CircuitElement other);
    public abstract Rectangle[] GetConnectionPoints();
    public abstract void ConnectTo(CircuitElement element, int direction);

    // Helper method to load images from embedded resources
    protected Image LoadImageFromResource(string imageName)
    {
        try
        {
            // 1. Try loading from the executable's directory (for deployment).
            string exePath = Path.Combine(Application.StartupPath, "Images", "CircuitElements", imageName);
            if (File.Exists(exePath))
            {
                return Image.FromFile(exePath);
            }

            // 2. If not found, try loading relative to the project directory (for development).
            string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\CircuitElements", imageName);
            if (File.Exists(projectPath))
            {
                return Image.FromFile(projectPath);
            }

            // 3. If not found in either location, throw an exception.
            throw new FileNotFoundException($"Image file not found: {imageName}.  Checked:\n{exePath}\n{projectPath}");
        }
        catch (FileNotFoundException)
        {
            // Handle the case where the file doesn't exist.
            MessageBox.Show($"Image file not found: {imageName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null; // Or throw the exception, depending on your error handling strategy.
        }
        catch (Exception ex)
        {
            // Handle other potential exceptions (e.g., invalid image format).
            MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null; // Or throw the exception.
        }
    }
}

public class Battery : CircuitElement
{
    public int Voltage { get; set; } = 9; // Example voltage property

    // Constructor to load the image
    public Battery()
    {
        // Assuming you have a resource named "CircuitSimulator.Images.battery.png"
        Image = LoadImageFromResource("battery.png"); // Pass just the file name
        Width = 60;
        Height = 30;

    }
    public override int IsConnectedTo(CircuitElement other)
    {
        Rectangle[] myConnectionPoints = GetConnectionPoints();
        if (myConnectionPoints[1].Contains(new Point(other.Location.X, other.Location.Y + (other.Height / 2))))
        {
            return 1;
        }
        else if (myConnectionPoints[0].Contains(new Point(other.Location.X + Width, other.Location.Y + (other.Height / 2))))
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    public override Rectangle[] GetConnectionPoints()
    {
        Rectangle leftRect = new Rectangle(Location.X, Location.Y, Width / 2, Height);
        Rectangle rightRect = new Rectangle(Location.X + (Width / 2), Location.Y, Width / 2, Height);
        return [leftRect, rightRect];
    }
    public override void ConnectTo(CircuitElement element, int direction) 
    {
        Point snapLocation;
        if (direction == 1)
        {
            snapLocation = new Point(element.Location.X - Width, element.Location.Y);
        }
        else if (direction == 0)
        {
            snapLocation = new Point(element.Location.X + element.Width, element.Location.Y);
        }
        else
        {
            throw new ArgumentException("Invalid direction");
        }
        Location = snapLocation;
    }
}

public class Resistor : CircuitElement
{

    public Resistor()
    {
        Image = LoadImageFromResource("resistor.png");
        Width = 80;
        Height = 20;
    }

    public override int IsConnectedTo(CircuitElement other)
    {
        Rectangle[] myConnectionPoints = GetConnectionPoints();
        if (myConnectionPoints[1].Contains(new Point(other.Location.X, other.Location.Y + (other.Height / 2))))
        {
            return 1;
        }
        else if (myConnectionPoints[0].Contains(new Point(other.Location.X + Width, other.Location.Y + (other.Height / 2))))
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public override Rectangle[] GetConnectionPoints()
    {
        Rectangle leftRect = new Rectangle(Location.X, Location.Y, Width / 2, Height);
        Rectangle rightRect = new Rectangle(Location.X + (Width / 2), Location.Y, Width / 2, Height);
        return [leftRect, rightRect];
    }

    public override void ConnectTo(CircuitElement element, int direction)
    {
        Point snapLocation;
        if (direction == 1)
        {
            snapLocation = new Point(element.Location.X - Width, element.Location.Y);
        }
        else if (direction == 0)
        {
            snapLocation = new Point(element.Location.X + element.Width, element.Location.Y);
        }
        else
        {
            throw new ArgumentException("Invalid direction");
        }
        Location = snapLocation;
    }
}

public class Wire : CircuitElement
{
    public Point EndPoint { get; set; }
    private bool draggingStartPoint = false;
    public const int handleSize = 8;

    public Wire()
    {
        string imagePath = "wire.png"; //Horizontal
        Image = LoadImageFromResource(imagePath);
        Width = 4; // Set a default width for horizontal
        Height = 4;  // Set a small default height
    }

    public override int IsConnectedTo(CircuitElement other)
    {
        return -1;
    }

    public override Rectangle[] GetConnectionPoints()
    {
        Rectangle leftRect = new Rectangle(Location.X, Location.Y, Width / 2, Height);
        Rectangle rightRect = new Rectangle(Location.X + (Width / 2), Location.Y, Width / 2, Height);
        return [leftRect, rightRect];
    }

    public override void ConnectTo(CircuitElement element, int direction)
    {
        // Implement connection logic here
    }

    public bool IsNearEndPoint(Point p, out bool isStartPoint)
    {
        isStartPoint = false;

        Rectangle startHandleRect = new Rectangle(Location.X - handleSize / 2, Location.Y - handleSize / 2, handleSize, handleSize);
        Rectangle endHandleRect = new Rectangle(EndPoint.X - handleSize / 2, EndPoint.Y - handleSize / 2, handleSize, handleSize);

        if (startHandleRect.Contains(p))
        {
            isStartPoint = true;
            return true;
        }
        else if (endHandleRect.Contains(p))
        {
            isStartPoint = false;
            return true;
        }
        return false;
    }

    public bool DraggingStartPoint
    {
        get { return draggingStartPoint; }
        set { draggingStartPoint = value; }
    }
}