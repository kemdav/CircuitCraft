using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public double DebugDropSourceVoltage { get; set; }

        private CircuitSimulator.LoadCalculationResult result;

        Timer gameTimer = new Timer();
        Timer operatingCurrentTimer = new Timer();
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

            gameCanvas.OperatingCurrent = 0.2;
            gameCanvas.MinimumOperatingCurrent = 0.1;

            CircuitSimulator.CalculationTest();

            gameTimer.Interval = 100;
            gameTimer.Tick += new EventHandler(Timer_Tick);

            operatingCurrentTimer.Interval = 100;
            operatingCurrentTimer.Tick += new EventHandler(OperatingCurrentTimer_Tick);

            operatingCurrentTimer.Start();

            DataClass.username = "a";
            DataClass.AqcuireUserInformation();
            UpdateCircuitElementUI();
        }

        public void StartTicking()
        {
            gameTimer.Start();
        }

        public void StopTicking()
        {
            gameTimer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameCanvas.DropDownCircuitElement(10))
            {
                UpdateCircuitElementUI();
            }
        }

        private void OperatingCurrentTimer_Tick(object sender, EventArgs e)
        {
            if (gameCanvas.OperatingCurrentTick >= 10000 && result.LoadCurrent > gameCanvas.OperatingCurrent)
            {
                // LED Burned
                //gameCanvas.OperatingCurrentTick = 0;
                //operatingCurrentProgress.Progress = 0;
                ledBurnedIndicator.Visible = true;
            }

            // In the final game, the indicator will be the LED icon itself on how bright it is
            if (result.LoadCurrent < gameCanvas.MinimumOperatingCurrent)
            {
                operatingCurrentProgress.Color = Color.Red;
                gameCanvas.MinimumOperatingCurrentTick += 100;
            }
            else if (result.LoadCurrent > gameCanvas.MinimumOperatingCurrent)
            {
                operatingCurrentProgress.Color = Color.Green;
                gameCanvas.MinimumOperatingCurrentTick = 0;
            }

            if (result.LoadCurrent > gameCanvas.OperatingCurrent && gameCanvas.OperatingCurrentTick < 10000)
            {
                gameCanvas.OperatingCurrentTick += 100;
                operatingCurrentProgress.Progress = Convert.ToInt32((gameCanvas.OperatingCurrentTick / 10000f) * 100);
            }
            else if (gameCanvas.OperatingCurrentTick > 0 && result.LoadCurrent < gameCanvas.OperatingCurrent)
            {
                gameCanvas.OperatingCurrentTick -= 100;
                operatingCurrentProgress.Progress = Convert.ToInt32((gameCanvas.OperatingCurrentTick / 10000f) * 100);
                ledBurnedIndicator.Visible = false;
            }
        }

        public void UpdateCircuitElementUI()
        {
            result = CircuitSimulator.CalculateLoadState(gameCanvas.CircuitBlocks, DebugSourceVoltage, DebugLoadResistance);

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
            dropVoltageLabel.Text = "Drop Voltage: " + DebugDropSourceVoltage + " V";
            operatingCurrentLabel.Text = "Operating Current: " + gameCanvas.OperatingCurrent.ToString("F2") + " A";
        }

        private void PlayerInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.G:
                    gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 0, DebugDropResistorResistance);
                    break;
                case Keys.S:
                    gameCanvas.SpawnCircuitElement(CircuitElementType.Source, DebugDropSourceVoltage, 0);
                    break;
                case Keys.F:
                    gameCanvas.SpawnCircuitElement(CircuitElementType.Diode, 0, 0);
                    break;
                case Keys.P:
                    StopTicking();
                    break;
                case Keys.O:
                    StartTicking();
                    break;
                case Keys.A:
                    gameCanvas.CurrentBlockIndex--;
                    break;
                case Keys.D:
                    gameCanvas.CurrentBlockIndex++;
                    break;
                case Keys.R:
                    gameCanvas.CurrentCircuitElementDroppedOrientation = 0;
                    break;
                case Keys.L:
                    gameCanvas.CircuitBlocks[gameCanvas.CurrentBlockIndex].RemoveCircuitElement(ref gameCanvas, 1);
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

        private void dropSourceTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double result;
                double.TryParse(dropSourceTbox.Text, out result);
                DebugDropSourceVoltage = result;
                UpdateCircuitElementUI();
            }
        }

        private void MainGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                var frm = new MainMenuForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosing += delegate { Close(); };
                frm.Show();
                Hide();
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
