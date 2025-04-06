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
        public double DebugLoadResistance { get; set; }
        public double DebugDropResistorResistance { get; set; }
        public double DebugSourceVoltage { get; set; }

        Timer timer = new Timer();
        public double timerModifier = 1;
        public MainGame()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(PlayerInput);

            gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(60, 110), 40, 120);
            gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(140, 110), 40, 120);
            gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(220, 110), 40, 120);
            gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(300, 110), 40, 120);

            timer.Interval = 200;
            timer.Tick += new EventHandler(Timer_Tick);

            DataClass.username = "a";
            DataClass.AqcuireUserInformation();
            UpdateCircuitElementUI();
        }

        public void StartTicking()
        {
            timer.Start();
        }

        public void StopTicking()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameCanvas.DropDownCircuitElement(10))
            {
                gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 90, DebugDropResistorResistance);
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

            CircuitSimulator.LoadCalculationResult result = CircuitSimulator.CalculateLoadState(DebugSourceVoltage, seriesResistance, parallelResistance, DebugLoadResistance);
            loadCurrentLabel.Text = "Load Current: " + result.LoadCurrent.ToString("F2") + " A";
            loadVoltageLabel.Text = "Load Voltage: " + result.LoadVoltage.ToString("F2") + " V";
            loadResistanceLabel.Text = "Load Resistance: " + result.LoadResistance.ToString("F2") + " Ω";
            loadPowerLabel.Text = "Load Power: " + (result.LoadVoltage * result.LoadCurrent).ToString("F2") + " W";
            circuitSourceLabel.Text = "Circuit Source: " + DebugSourceVoltage + " V";
            dropResistorLabel.Text = "Drop Resistor: " + DebugDropResistorResistance.ToString("F2") + " Ω";
            circuitCompletedLabel.Text = "Circuits Completed: " + DataClass.CircuitsCompleted.ToString();
            resistorBurnedLabel.Text = "Burned Resistors: " + DataClass.BurnedResistors.ToString();
            ledBurnedLabel.Text = "Burned LEDs: " + DataClass.BurnedLeds.ToString();
            ratingLabel.Text = "Rating: " + DataClass.Rating.ToString("F2");
        }

        private void PlayerInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.G:
                    gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 0, DebugDropResistorResistance);
                    break;
                case Keys.P:
                    StopTicking();
                    break;
                case Keys.O:
                    StartTicking();
                    break;
                case Keys.C:
                    gameCanvas.ClearCircuitElements();
                    break;
                case Keys.A:
                    gameCanvas.CurrentBlockIndex--;
                    break;
                case Keys.D:
                    gameCanvas.CurrentBlockIndex++;
                    break;
            }

        }

        #region Debug
        private void circuitSourceTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double result;
                double.TryParse(circuitSourceTbox.Text, out result);
                DebugSourceVoltage = result;
                UpdateCircuitElementUI();
            }
        }

        private void dropResistorTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double result;
                double.TryParse(dropResistorTbox.Text, out result);
                DebugDropResistorResistance = result;
                UpdateCircuitElementUI();
            }
        }

        private void loadResistanceTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double result;
                double.TryParse(loadResistanceTbox.Text, out result);
                DebugLoadResistance = result;
                UpdateCircuitElementUI();
            }
        }

        private void circuitCompletedButton_Click(object sender, EventArgs e)
        {
            DataClass.CircuitsCompleted++;
            UpdateCircuitElementUI();
        }

        private void resistorBurnedButton_Click(object sender, EventArgs e)
        {
            DataClass.BurnedResistors++;
            UpdateCircuitElementUI();
        }

        private void ledBurnedButton_Click(object sender, EventArgs e)
        {
            DataClass.BurnedLeds++;
            UpdateCircuitElementUI();
        }
        #endregion
    }
}
