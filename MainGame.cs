using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            KeyPreview = true;
            KeyDown += new KeyEventHandler(PlayerInput);

            gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(60, 160), 30, 90);
            gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel,new Point(100, 160), 30, 90);
            gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 90, 1);

            timer.Interval = 200;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            UpdateCircuitElementUI();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameCanvas.DropDownCircuitElement(10))
            { 
                gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 90, 1);
                UpdateCircuitElementUI();
            }
        }

        public void UpdateCircuitElementUI()
        {
            List<double> seriesResistance = new List<double>();
            List<double> parallelResistance = new List<double>();

            foreach (var block in gameCanvas.CircuitBlocks)
            {
                if (block.CircuitBlockConnectionType == CircuitBlockConnectionType.Series)
                {

                    for (int i = 0; i < block.CircuitElements.Count; i++)
                    {
                        seriesResistance.Add(block.CircuitElements[i].Resistance);
                    }
                }
                else if (block.CircuitBlockConnectionType == CircuitBlockConnectionType.Parallel)
                {
                    for (int i = 0; i < block.CircuitElements.Count; i++)
                    {
                        parallelResistance.Add(block.CircuitElements[i].Resistance);
                    }
                }
            }

            double loadResistance = 50;
            CircuitSimulator.LoadCalculationResult result = CircuitSimulator.CalculateLoadState(10, seriesResistance, parallelResistance, loadResistance);
            loadCurrentLabel.Text = "Load Current: " + result.LoadCurrent.ToString("F2") + " A";
            loadVoltageLabel.Text = "Load Voltage: " + result.LoadVoltage.ToString("F2") + " V";
            loadResistanceLabel.Text = "Load Resistance: " + result.LoadResistance.ToString("F2") + " Ω";
            loadPowerLabel.Text = "Load Power: " + (result.LoadVoltage * result.LoadCurrent).ToString("F2") + " W";
            circuitSourceLabel.Text = "Circuit Source: " + 10 + " V"; 
        }

        private void PlayerInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.A:
                    gameCanvas.CurrentBlockIndex--;
                    break;
                case Keys.D:
                    gameCanvas.CurrentBlockIndex++;
                    break;
            }

        }
    }
}
