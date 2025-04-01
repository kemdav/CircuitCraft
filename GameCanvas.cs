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
        public List<CircuitBlock> CircuitBlocks { get; set; } = new List<CircuitBlock>();
        public List<CircuitElement> CircuitSources { get; set; } = new List<CircuitElement>();
        public int CurrentBlockIndex { get; set; } = 0;

        public GameCanvas()
        {
            InitializeComponent();
        }
    }
}
