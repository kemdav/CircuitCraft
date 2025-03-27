using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace CircuitCraft 
{
    public partial class GridControl : UserControl
    {
        public enum ToolType
        {
            None,
            Wire,
            Resistor,
            Battery,
            LED,
            Delete
        }

        private int _gridSize = 20;
        public int GridSize
        {
            get { return _gridSize; }
            set { _gridSize = value; Invalidate(); }
        }

        private Color gridColor = Color.LightGray;
        private List<Tuple<CircuitElement, PictureBox>> circuitElements = new List<Tuple<CircuitElement, PictureBox>>();
        private CircuitElement? selectedElementData = null;
        private PictureBox? selectedPictureBox = null;
        private bool isDraggingElement = false;
        private List<Wire> wires = new List<Wire>();
        private string? elementToPlace = null;

        public GridControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.TabStop = true; 
            this.KeyPress += GridControl_KeyPress;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGrid(e.Graphics);
            DrawWires(e.Graphics);
            DrawNodes(e.Graphics);
        }

        #region Drawing Methods

        private void DrawNodes(Graphics g)
        {
            using (Brush nodeBrush = new SolidBrush(Color.Red))
            using (Pen nodePen = new Pen(Color.Black))
            {
                foreach (var elementTuple in circuitElements)
                {
                    var element = elementTuple.Item1;
                    foreach (var node in element.Nodes)
                    {
                        g.FillEllipse(nodeBrush, node.Bounds);
                        g.DrawEllipse(nodePen, node.Bounds);
                    }
                }
            }
        }

        private void DrawWires(Graphics g)
        {
            using (Pen wirePen = new Pen(Color.Black, 2))
            {
                foreach (var wire in wires)
                {
                    Point intermediate = new Point(wire.EndPoint.X, wire.StartPoint.Y);
                    g.DrawLine(wirePen, wire.StartPoint, intermediate);
                    g.DrawLine(wirePen, intermediate, wire.EndPoint);
                }
                if (isDrawingWire && currentWireEndPoint.HasValue)
                {
                    Point intermediateTemp = new Point(currentWireEndPoint.Value.X, wireStartPoint.Y);
                    g.DrawLine(wirePen, wireStartPoint, intermediateTemp);
                    g.DrawLine(wirePen, intermediateTemp, currentWireEndPoint.Value);
                }
            }
        }


        private void DrawGrid(Graphics g)
        {
            int controlWidth = this.ClientSize.Width;
            int controlHeight = this.ClientSize.Height;

            Pen gridPen = new Pen(gridColor);

            for (int x = 0; x <= controlWidth; x += GridSize)
            {
                g.DrawLine(gridPen, x, 0, x, controlHeight);
            }
            for (int y = 0; y <= controlHeight; y += GridSize)
            {
                g.DrawLine(gridPen, 0, y, controlWidth, y);
            }

            gridPen.Dispose();
        }

        #endregion

        #region Mouse Events

        private bool isDrawingWire = false;
        private Point wireStartPoint;
        public ToolType currentTool = ToolType.None;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            Point snappedPosition = SnapToGrid(e.Location);

            int topMargin = GridSize * 2;

            if (snappedPosition.Y < topMargin)
            {
                return;
            }
            if (currentTool == ToolType.Delete)
            {
                DeleteWireAtPosition(e.Location);
                return;
            }
            if (currentTool == ToolType.Wire)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDrawingWire = true;
                    wireStartPoint = SnapToGrid(e.Location);
                    CircuitNode? startNode = FindNearestNode(SnapToGrid(e.Location));
                    if (startNode != null)
                    {
                        wireStartPoint = startNode.Location;
                    }
                    else
                    {
                        wireStartPoint = SnapToGrid(e.Location);
                    }
                }
            }
            else
            {
                switch (currentTool)
                {
                    case ToolType.Battery:
                        SetElementToPlace("Battery");
                        currentTool = ToolType.None;
                        break;
                    case ToolType.Resistor:
                        SetElementToPlace("Resistor");
                        currentTool = ToolType.None;
                        break;
                    case ToolType.LED:
                        SetElementToPlace("LED");
                        currentTool = ToolType.None;
                        break;
                }
                if (elementToPlace != null)
                {                
                    string imageFileName = GetImageFileNameForElementType(elementToPlace);
                    if (imageFileName != null)
                    {
                        CircuitElement newElementData = new CircuitElement(elementToPlace, snappedPosition, imageFileName);
                        PictureBox newPictureBox = CreatePictureBoxForElement(newElementData);
                        circuitElements.Add(new Tuple<CircuitElement, PictureBox>(newElementData, newPictureBox));
                        ToolTip toolTip = new ToolTip();
                        toolTip.SetToolTip(newPictureBox, $"Potential Difference: {newElementData.Voltage} V\nCurrent: {newElementData.Current} A\nResistance: {newElementData.Resistance} Ohms");
                        newPictureBox.MouseDown += PictureBox_MouseDown;
                        newPictureBox.MouseUp += PictureBox_MouseUp;
                        newPictureBox.MouseMove += PictureBox_MouseMove;
                        newPictureBox.Tag = newElementData;
                        Controls.Add(newPictureBox);
                        isDraggingElement = true;
                        selectedElementData = newElementData;
                        selectedPictureBox = newPictureBox;
                        ClearElementToPlace();

                        // **Center Alignment Adjustment for OnMouseDown**
                        int offsetX = newPictureBox.Width / 2;
                        int offsetY = newPictureBox.Height / 2;
                        newPictureBox.Location = new Point(snappedPosition.X - offsetX, snappedPosition.Y - offsetY);
                        newElementData.Location = newPictureBox.Location; // Update element data 
                    }
                }
                else
                {
                    var foundElementTuple = FindElementAtPosition(e.Location);
                    if (foundElementTuple != null)
                    {
                        isDraggingElement = true;
                        selectedElementData = foundElementTuple.Item1;
                        selectedPictureBox = foundElementTuple.Item2;
                    }
                }
            }   
        }

        private Point? currentWireEndPoint = null;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDrawingWire)
            {
                // Optionally, store a temporary end point and call Invalidate to refresh the drawing.
                currentWireEndPoint = SnapToGrid(e.Location);
                Invalidate(); // This will trigger OnPaint
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (isDrawingWire)
            {
                CircuitNode? endNode = FindNearestNode(SnapToGrid(e.Location));
                Point wireEndPoint = (endNode != null) ? endNode.Location : SnapToGrid(e.Location);
                Wire newWire = new Wire(wireStartPoint, wireEndPoint);
                wires.Add(newWire);
                isDrawingWire = false;

                Invalidate(); // Redraw control to show the new wire
            }
            else
            {
                isDraggingElement = false;
                selectedElementData = null;
                selectedPictureBox = null;
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedPictureBox = (PictureBox)sender;
            selectedElementData = (CircuitElement)selectedPictureBox.Tag;
            if (currentTool == ToolType.None)
            {
                isDraggingElement = true;
            }
            else if (currentTool == ToolType.Delete)
            {
                DeleteSelectedElement();
            }
            Focus();
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingElement && selectedPictureBox != null && selectedElementData != null)
            {
                Point parentCoords = selectedPictureBox.Parent.PointToClient(
                                selectedPictureBox.PointToScreen(e.Location));
                Point snappedPosition = SnapToGrid(parentCoords);

                int offsetX = selectedPictureBox.Width / 2;
                int offsetY = selectedPictureBox.Height / 2;
                selectedPictureBox.Location = new Point(snappedPosition.X - offsetX, snappedPosition.Y - offsetY);

                // Update the element's own location and node positions
                selectedElementData.UpdateNodes(selectedPictureBox.Location);
                this.Invalidate();
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDraggingElement)
            {
                isDraggingElement = false;
                selectedElementData = null;
                selectedPictureBox = null;
            }
            Focus();
        }


        #endregion

        #region Circuit Element Manipulation Methods

        private void DeleteWireAtPosition(Point clickPosition)
        {
            const double tolerance = 5.0;

            foreach (var wire in new List<Wire>(wires))
            {
                Point intermediate = new Point(wire.EndPoint.X, wire.StartPoint.Y);

                double distance1 = DistanceFromPointToLineSegment(clickPosition, wire.StartPoint, intermediate);
                double distance2 = DistanceFromPointToLineSegment(clickPosition, intermediate, wire.EndPoint);

                if (distance1 <= tolerance || distance2 <= tolerance)
                {
                    wires.Remove(wire);
                    Invalidate();
                    return;
                }
            }
        }

        private void GridControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'r' || e.KeyChar == 'R')
            {
                RotateSelectedElement();
                e.Handled = true; 
            }
        }

        private void RotateSelectedElement()
        {
            if (selectedElementData != null && selectedPictureBox != null)
            {
                selectedElementData.RotationAngle += 90;
                if (selectedElementData.RotationAngle >= 360)
                {
                    selectedElementData.RotationAngle -= 360;
                }

                selectedPictureBox.Image = RotateImage(Image.FromFile(selectedElementData.ImageFileName), selectedElementData.RotationAngle);

                Invalidate(); 
            }
        }

        private void DeleteSelectedElement()
        {
            if (selectedElementData != null && selectedPictureBox != null)
            {
                var elementTuple = circuitElements
                    .FirstOrDefault(tuple => tuple.Item2 == selectedPictureBox);

                if (elementTuple != null)
                {
                    Controls.Remove(elementTuple.Item2);

                    circuitElements.Remove(elementTuple);
                }

                selectedElementData = null;
                selectedPictureBox = null;
                Invalidate(); 
            }
        }



        private Image RotateImage(Image originalImage, float angleDegrees)
        {
            if (originalImage == null) return null;

            Bitmap originalBitmap = new Bitmap(originalImage);

            double angleRadians = angleDegrees * Math.PI / 180.0;
            double cos = Math.Abs(Math.Cos(angleRadians));
            double sin = Math.Abs(Math.Sin(angleRadians));

            int newWidth = (int)Math.Round(originalBitmap.Width * cos + originalBitmap.Height * sin);
            int newHeight = (int)Math.Round(originalBitmap.Width * sin + originalBitmap.Height * cos);

            Bitmap rotatedImage = new Bitmap(newWidth, newHeight);
            rotatedImage.SetResolution(originalBitmap.HorizontalResolution, originalBitmap.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.TranslateTransform(newWidth / 2f, newHeight / 2f);
                g.RotateTransform(angleDegrees);

                g.DrawImage(originalBitmap, -originalBitmap.Width / 2f, -originalBitmap.Height / 2f);
            }

            originalBitmap.Dispose();
            return rotatedImage;
        }

        #endregion

        #region Helper Methods

        public void SetElementToPlace(string elementType)
        {
            elementToPlace = elementType;
        }

        public void ClearElementToPlace()
        {
            elementToPlace = null;
        }

        private CircuitNode? FindNearestNode(Point p, int tolerance = 10)
        {
            foreach (var elementTuple in circuitElements)
            {
                foreach (var node in elementTuple.Item1.Nodes)
                {
                    if (Math.Abs(p.X - node.Location.X) <= tolerance &&
                        Math.Abs(p.Y - node.Location.Y) <= tolerance)
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        private double DistanceFromPointToLineSegment(Point p, Point a, Point b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            if (dx == 0 && dy == 0)
            {
                return Math.Sqrt((p.X - a.X) * (p.X - a.X) + (p.Y - a.Y) * (p.Y - a.Y));
            }
            double t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));
            double projX = a.X + t * dx;
            double projY = a.Y + t * dy;
            double distX = p.X - projX;
            double distY = p.Y - projY;
            return Math.Sqrt(distX * distX + distY * distY);
        }


        public Point SnapToGrid(Point point)
        {
            int snappedX = (int)Math.Round((double)point.X / GridSize) * GridSize;
            int snappedY = (int)Math.Round((double)point.Y / GridSize) * GridSize;
            return new Point(snappedX, snappedY);
        }

        private Tuple<CircuitElement, PictureBox>? FindElementAtPosition(Point point)
        {
            foreach (var elementTuple in circuitElements)
            {
                if (elementTuple.Item2.Bounds.Contains(point))
                {
                    return elementTuple;
                }
            }
            return null;
        }

        private PictureBox CreatePictureBoxForElement(CircuitElement element)
        {
            PictureBox pictureBox = new PictureBox();

            int maxDimension = Math.Max(GridSize * 2, GridSize);
            pictureBox.Width = maxDimension;
            pictureBox.Height = maxDimension;

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;

            try
            {
                pictureBox.Image = Image.FromFile(element.ImageFileName);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Image file not found: {element.ImageFileName}", "Error Loading Image");
                pictureBox.BackColor = Color.Red;
                pictureBox.Size = new Size(GridSize * 2, GridSize);
            }
            pictureBox.Location = element.Location;
            return pictureBox;
        }

        private string? GetImageFileNameForElementType(string elementType)
        {
            string basePath = Path.Combine(Application.StartupPath, "Images", "CircuitElements");

            switch (elementType)
            {
                case "Resistor":
                    return Path.Combine(basePath, "resistor.png");
                case "Battery":
                    return Path.Combine(basePath, "battery.png");
                case "LED":
                    return Path.Combine(basePath, "led.png");
                default:
                    return null;
            }
        }

        #endregion
    }
}