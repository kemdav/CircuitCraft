using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CircuitCraft
{
    public partial class MainGame : Form
    {
        Timer timer = new Timer();
        public double timerModifier = 1;
        public MainGame()
        {
            InitializeComponent();
            gameCanvas.SpawnCircuitBlock(new Point(60, 160), 30, 90);
            gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 90, 90);

            timer.Interval = 200;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameCanvas.DropDownCircuitElement(10))
            { 
                gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 90, 90);
            }
        }
    }
}
