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
    public partial class GameCanvas : UserControl
    {
        public List<CircuitElement> CircuitSources { get; set; } = new List<CircuitElement>();
        public int CurrentBlockIndex { get; set; } = 0;

        private List<CircuitBlock> _circuitBlocks { get; set; } = new List<CircuitBlock>();

        private Image _circuitElementSourceSprite;
        private Image _circuitElementResistorSprite;
        
        private int _circuitElementSpawnOffsetY = 20;

        public GameCanvas()
        {
            InitializeComponent();
            if (_circuitBlocks == null)
            {
                _circuitBlocks = new List<CircuitBlock>();
            }
        }

        public void SpawnCircuitElement(CircuitElementType circuitElementType)
        {
            CircuitElement circuitElement = null;
            PictureBox circuitElementPbox = new PictureBox();
            circuitElementPbox.Visible = false;
            circuitElementPbox.Location = new Point(CircuitBlocks[CurrentBlockIndex].Location.X, CircuitBlocks[CurrentBlockIndex].Location.Y - CircuitElementOffset);
            switch (circuitElementType)
            {
                case CircuitElementType.Resistor:
                    circuitElementPbox.Image = CircuitElementResistorSprite;
                    circuitElementPbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    circuitElementPbox.Width = CircuitBlocks[CurrentBlockIndex].CircuitElementWidth;
                    circuitElementPbox.Height = CircuitBlocks[CurrentBlockIndex].CircuitElementHeight;
                    circuitElementPbox.Visible = true;
                    Controls.Add(circuitElementPbox);
                    circuitElementPbox.BringToFront();
                    break;
            }
        }

        public void SpawnCircuitBlock(Point _location, int _circuitElementWidth, int _circuitElementHeight)
        {
            CircuitBlock circuitBlock = new CircuitBlock();
            circuitBlock.CircuitElementWidth = _circuitElementWidth;
            circuitBlock.CircuitElementHeight = _circuitElementHeight;
            circuitBlock.Location = _location;
            Controls.Add(circuitBlock);
            circuitBlock.BringToFront();
            CircuitBlocks.Add(circuitBlock);
        }

        [Category("Game Canvas Settings")]
        [Description("New Circuit ELement Spawn Offset")]
        [Editor("System.ComponentModel.Design.CollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public List<CircuitBlock> CircuitBlocks
        {
            get { return _circuitBlocks; }
            set { _circuitBlocks = value ?? new List<CircuitBlock>(); }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementResistorSprite
        {
            get { return _circuitElementResistorSprite; }
            set { _circuitElementResistorSprite = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("Resistor Sprite")]
        [DefaultValue(null)]
        public Image CircuitElementSourceSprite
        {
            get { return _circuitElementSourceSprite; }
            set { _circuitElementSourceSprite = value; }
        }

        [Category("Game Canvas Settings")]
        [Description("New Circuit ELement Spawn Offset")]
        [DefaultValue(null)]
        public int CircuitElementOffset
        {
            get { return _circuitElementSpawnOffsetY; }
            set { _circuitElementSpawnOffsetY = value; }
        }

    }
}
