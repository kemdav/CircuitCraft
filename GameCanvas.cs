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

        public GameCanvas()
        {
            InitializeComponent();
        }
    }
}
