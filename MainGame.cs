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
    public partial class MainGame : Form
    {
        public MainGame()
        {
            InitializeComponent();
            gameCanvas.SpawnCircuitBlock(new Point(20, 90), 50, 100);
            gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor);
        }
    }
}
