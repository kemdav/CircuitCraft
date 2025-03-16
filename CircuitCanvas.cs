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
    public partial class CircuitCanvas : UserControl
    {
        public List<CircuitElement> Elements { get; set; } = new List<CircuitElement>();

        private CircuitElement selectedElement = null;
        private Point dragOffset;
        private bool isDragging = false;

        // Wire Creation
        private bool isCreatingWire = false;
        private Point wireStartPoint;
        private Wire tempWire;

        public CircuitCanvas()
        {
            InitializeComponent();
            SuspendLayout();
            DoubleBuffered = true;


            this.DoubleBuffered = true; 
            this.BackColor = Color.White; 

            this.MouseDown += CircuitCanvas_MouseDown;
            this.MouseMove += CircuitCanvas_MouseMove;
            this.MouseUp += CircuitCanvas_MouseUp;
            this.Paint += CircuitCanvas_Paint;
            this.Resize += CircuitCanvas_Resize;
            ResumeLayout();
        }

        private void CircuitCanvas_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private Point SnapToGrid(Point startPoint, Point endPoint)
        {
            // Determine if we should snap horizontally or vertically based on the greater distance
            int deltaX = Math.Abs(endPoint.X - startPoint.X);
            int deltaY = Math.Abs(endPoint.Y - startPoint.Y);

            if (deltaX > deltaY)
            {
                // Snap horizontally
                return new Point(endPoint.X, startPoint.Y);
            }
            else
            {
                // Snap vertically
                return new Point(startPoint.X, endPoint.Y);
            }
        }

        private void CircuitCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            //if (isCreatingWire)
            //{
            //    // Second click: Finalize the wire, snapping to horizontal/vertical
            //    Point snappedEndPoint = SnapToGrid(wireStartPoint, e.Location);
            //    tempWire.EndPoint = snappedEndPoint;
            //    Elements.Add(tempWire);
            //    tempWire = null;
            //    isCreatingWire = false;
            //    Invalidate();
            //    return;
            //}

            bool isStartPoint;
            for (int i = Elements.Count - 1; i >= 0; i--)
            {
                if (Elements[i] is Wire wire && wire.IsNearEndPoint(e.Location, out isStartPoint))
                {
                    selectedElement = wire;
                    wire.DraggingStartPoint = isStartPoint;

                    // Calculate drag offset based on which endpoint is being dragged
                    dragOffset = isStartPoint
                        ? new Point(e.X - wire.Location.X, e.Y - wire.Location.Y)
                        : new Point(e.X - wire.EndPoint.X, e.Y - wire.EndPoint.Y);

                    Elements.RemoveAt(i);
                    Elements.Add(selectedElement);
                    Invalidate();
                    return;
                }
            }


            // Check if the mouse clicked on any element (in reverse order, so top elements get priority)
            for (int i = Elements.Count - 1; i >= 0; i--)
            {
                if (InteractionHelper.HitTestElement(Elements[i], e.Location))
                {
                    selectedElement = Elements[i];
                    if (selectedElement is Wire wire)
                    {
                        wire.DraggingStartPoint = false; // Ensure not dragging an endpoint
                    }

                    dragOffset = new Point(e.X - selectedElement.Location.X, e.Y - selectedElement.Location.Y);
                    Elements.RemoveAt(i);
                    Elements.Add(selectedElement);
                    Invalidate();
                    return;
                }
            }

            wireStartPoint = e.Location;
            tempWire = new Wire { Location = wireStartPoint, EndPoint = wireStartPoint };
            isCreatingWire = true;
            Invalidate();
        }

        private void CircuitCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCreatingWire && isDragging)
            {
                // Snap the temporary wire's endpoint during creation
                Point snappedEndPoint = SnapToGrid(wireStartPoint, e.Location);
                tempWire.EndPoint = snappedEndPoint;
                Invalidate();
                return;
            }
            if (selectedElement != null)
            {
                if (selectedElement is Wire wire)
                {
                    // Get the current mouse position
                    Point newPosition = new Point(e.X - dragOffset.X, e.Y - dragOffset.Y);
                    // Update the wire endpoint, keeping it horizontal/vertical
                    InteractionHelper.UpdateWireEndPoint(wire, newPosition, wire.DraggingStartPoint);
                }
                else
                {
                    selectedElement.Location = new Point(e.X - dragOffset.X, e.Y - dragOffset.Y);
                }
                Invalidate();
            }
        }

        private void CircuitCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isCreatingWire && isDragging)
            {
                // Second click: Finalize the wire, snapping to horizontal/vertical
                Point snappedEndPoint = SnapToGrid(wireStartPoint, e.Location);
                tempWire.EndPoint = snappedEndPoint;
                if (Math.Sqrt(Math.Pow(tempWire.Location.X - tempWire.EndPoint.X, 2) + Math.Pow(tempWire.Location.Y - tempWire.EndPoint.Y, 2)) < 50)
                {
                    // Wire is too short, don't add it
                    tempWire = null;
                    isCreatingWire = false;
                    Invalidate();
                    return;
                }
                Elements.Add(tempWire);
                tempWire = null;
                isCreatingWire = false;
                Invalidate();
                return;
            }
            isDragging = false;
            if (selectedElement != null)
            {
                foreach (var element in Elements)
                {
                    int direction = selectedElement.IsConnectedTo(element);
                    if (element != selectedElement && direction != -1)
                    {
                        // Connect the elements
                        selectedElement.ConnectTo(element, direction);
                        Invalidate();
                    }
                }
            }
            selectedElement = null; // Deselect element on mouse up
        }

        private void CircuitCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw elements
            foreach (var element in Elements)
            {
                DrawingHelper.DrawElement(e.Graphics, element);
            }
            if (isCreatingWire && tempWire != null)
            {
                DrawingHelper.DrawElement(e.Graphics, tempWire); // Draw temp wire
            }
        }

        public void AddElement(CircuitElement element)
        {
            Elements.Add(element);
            this.Invalidate(); // Redraw after adding an element
        }

        private void RotateItem_Click(object sender, EventArgs e)
        {
            if (selectedElement != null)
            {
                selectedElement.Rotation = (selectedElement.Rotation + 90) % 360; // Rotate by 90 degrees
                Invalidate(); // Redraw
            }
        }
    }
}
