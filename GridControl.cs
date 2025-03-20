using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CircuitCraft // Replace with your namespace
{
    public partial class GridControl : UserControl
    {
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
        private string? elementToPlace = null;

        public GridControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.White; // Optional: Set a background color for the GridControl
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();

            if (elementToPlace != null)
            {
                Point snappedPosition = SnapToGrid(e.Location);
                string imageFileName = GetImageFileNameForElementType(elementToPlace);
                if (imageFileName != null)
                {
                    CircuitElement newElementData = new CircuitElement(elementToPlace, snappedPosition, imageFileName);
                    PictureBox newPictureBox = CreatePictureBoxForElement(newElementData);
                    circuitElements.Add(new Tuple<CircuitElement, PictureBox>(newElementData, newPictureBox));
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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDraggingElement && selectedPictureBox != null && selectedElementData != null)
            {
                Point snappedPosition = SnapToGrid(e.Location);

                // **Center Alignment Adjustment for OnMouseMove**
                int offsetX = selectedPictureBox.Width / 2;
                int offsetY = selectedPictureBox.Height / 2;
                selectedPictureBox.Location = new Point(snappedPosition.X - offsetX, snappedPosition.Y - offsetY);
                selectedElementData.Location = selectedPictureBox.Location; // Update element data too
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDraggingElement = false;
            selectedElementData = null;
            selectedPictureBox = null;
        }

        private PictureBox CreatePictureBoxForElement(CircuitElement element)
        {
            PictureBox pictureBox = new PictureBox();

            // Set PictureBox Size based on GridSize (e.g., 2x1 grid cells)
            pictureBox.Width = GridSize * 2;
            pictureBox.Height = GridSize;

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
            pictureBox.Location = element.Location; // Initial location will be adjusted in OnMouseDown/MouseMove
            return pictureBox;
        }

        private string? GetImageFileNameForElementType(string elementType)
        {
            string basePath = Path.Combine(Application.StartupPath, "Images", "CircuitElements");

            switch (elementType)
            {
                case "Resistor":
                    return Path.Combine(basePath, "resistor.png");
                case "Capacitor":
                    return Path.Combine(basePath, "capacitor.png");
                default:
                    return null;
            }
        }
    }
}