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
        private bool isDraggingElement2 = false;
        private List<Wire> wires = new List<Wire>();
        private string? elementToPlace = null;

        public GridControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.TabStop = true; // Important: Make GridControl focusable for KeyPress events
            this.KeyPress += GridControl_KeyPress; // Add KeyPress event handler
        }


        public void SetElementToPlace(string elementType)
        {
            elementToPlace = elementType;
        }

        public void ClearElementToPlace()
        {
            elementToPlace = null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGrid(e.Graphics);
            DrawWires(e.Graphics);
        }

        private void DrawWires(Graphics g)
        {
            using (Pen wirePen = new Pen(Color.Black, 2))
            {
                foreach (var wire in wires)
                {
                    // Compute an intermediate point so the wire consists of two segments:
                    // horizontal from start to intermediate, then vertical from intermediate to end.
                    Point intermediate = new Point(wire.EndPoint.X, wire.StartPoint.Y);
                    g.DrawLine(wirePen, wire.StartPoint, intermediate);
                    g.DrawLine(wirePen, intermediate, wire.EndPoint);
                }

                // Optionally, draw the temporary wire during the drawing process:
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

            // Draw vertical lines
            for (int x = 0; x <= controlWidth; x += GridSize)
            {
                g.DrawLine(gridPen, x, 0, x, controlHeight);
            }

            // Draw horizontal lines
            for (int y = 0; y <= controlHeight; y += GridSize)
            {
                g.DrawLine(gridPen, 0, y, controlWidth, y);
            }

            gridPen.Dispose();
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
            if (currentTool == ToolType.Wire)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDrawingWire = true;
                    wireStartPoint = SnapToGrid(e.Location);
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
                        toolTip.SetToolTip(newPictureBox, $"Potential Difference: {newElementData.PotentialDifference} V\nCurrent: {newElementData.Current} A\nResistance: {newElementData.Resistance} Ohms");
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
                        newElementData.Location = newPictureBox.Location; // Update element data too
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

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentTool == ToolType.None)
            {
                isDraggingElement = true;
                isDraggingElement2 = true;
                selectedPictureBox = (PictureBox)sender;
                selectedElementData = (CircuitElement)selectedPictureBox.Tag;
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
                Point snappedPosition = SnapToGrid(e.Location);
                int offsetX = selectedPictureBox.Width / 2;
                int offsetY = selectedPictureBox.Height / 2;
                selectedPictureBox.Location = new Point(snappedPosition.X - offsetX, snappedPosition.Y - offsetY);
                selectedElementData.Location = selectedPictureBox.Location;
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDraggingElement)
            {
                isDraggingElement = false;
                isDraggingElement2 = false;
                selectedElementData = null;
                selectedPictureBox = null;
            }
            Focus();
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
            else if (isDraggingElement && selectedPictureBox != null && selectedElementData != null && !isDraggingElement2)
            {
                Point snappedPosition = SnapToGrid(e.Location);
                int offsetX = selectedPictureBox.Width / 2;
                int offsetY = selectedPictureBox.Height / 2;
                selectedPictureBox.Location = new Point(snappedPosition.X - offsetX, snappedPosition.Y - offsetY);
                selectedElementData.Location = selectedPictureBox.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (isDrawingWire)
            {
                Point wireEndPoint = SnapToGrid(e.Location);
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



        private PictureBox CreatePictureBoxForElement(CircuitElement element)
        {
            PictureBox pictureBox = new PictureBox();

            // Determine the larger dimension (width or height) for square PictureBox
            int maxDimension = Math.Max(GridSize * 2, GridSize); // Assuming initial size was 2x1 grid cells
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
                pictureBox.Size = new Size(GridSize * 2, GridSize); // Default size if image fails (still set a reasonable size)
            }
            pictureBox.Location = element.Location;
            return pictureBox;
        }

        private void GridControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'r' || e.KeyChar == 'R') // Rotate on 'R' or 'r' key press
            {
                RotateSelectedElement();
                e.Handled = true; // Mark event as handled
            }
        }

        private void RotateSelectedElement()
        {
            if (selectedElementData != null && selectedPictureBox != null)
            {
                selectedElementData.RotationAngle += 90; // Increment rotation angle (in degrees)
                if (selectedElementData.RotationAngle >= 360)
                {
                    selectedElementData.RotationAngle -= 360; // Keep angle within 0-360 range (optional, but cleaner)
                }

                // Rotate the PictureBox's image
                selectedPictureBox.Image = RotateImage(Image.FromFile(selectedElementData.ImageFileName), selectedElementData.RotationAngle);

                Invalidate(); // Redraw to reflect rotation
            }
        }

        private void DeleteSelectedElement()
        {
            if (selectedElementData != null && selectedPictureBox != null)
            {
                // Locate the element tuple by matching the PictureBox
                var elementTuple = circuitElements
                    .FirstOrDefault(tuple => tuple.Item2 == selectedPictureBox);

                if (elementTuple != null)
                {
                    // Remove controls from the grid control
                    Controls.Remove(elementTuple.Item2);

                    // Remove from the internal list
                    circuitElements.Remove(elementTuple);
                }

                // Clear the selection
                selectedElementData = null;
                selectedPictureBox = null;
                Invalidate(); // Redraw the control
            }
        }



        private Image RotateImage(Image originalImage, float angleDegrees)
        {
            if (originalImage == null) return null;

            // Create a bitmap from the original image
            Bitmap originalBitmap = new Bitmap(originalImage);

            // Calculate the rotation angle in radians
            double angleRadians = angleDegrees * Math.PI / 180.0;
            double cos = Math.Abs(Math.Cos(angleRadians));
            double sin = Math.Abs(Math.Sin(angleRadians));

            // Compute the new bounding dimensions
            int newWidth = (int)Math.Round(originalBitmap.Width * cos + originalBitmap.Height * sin);
            int newHeight = (int)Math.Round(originalBitmap.Width * sin + originalBitmap.Height * cos);

            // Create a new empty bitmap to hold rotated image
            Bitmap rotatedImage = new Bitmap(newWidth, newHeight);
            rotatedImage.SetResolution(originalBitmap.HorizontalResolution, originalBitmap.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Move rotation point to center of new bitmap
                g.TranslateTransform(newWidth / 2f, newHeight / 2f);
                g.RotateTransform(angleDegrees);

                // Draw the original image, centered at the origin
                g.DrawImage(originalBitmap, -originalBitmap.Width / 2f, -originalBitmap.Height / 2f);
            }

            originalBitmap.Dispose();
            return rotatedImage;
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
                default:
                    return null;
            }
        }
    }
}