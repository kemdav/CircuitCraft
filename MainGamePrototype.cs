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
    public partial class MainGamePrototype : Form
    {
        private int Joule { get; set; }


        public MainGamePrototype()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(PlayerInput);
           

            for (int i = 0; i < 12; i++)
            {
                gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(5 + (56 * i), 6), 50, 130);
            }

            gameCanvas.gameTimer.Start();
            gameCanvas.warningTimer.Start();

            gameCanvas.OperatingCurrent = 0.2;
            gameCanvas.MinimumOperatingCurrent = 0.1;
        }

       

        private void PlayerInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    gameCanvas.CurrentBlockIndex--;
                    break;
                case Keys.D:
                    gameCanvas.CurrentBlockIndex++;
                    break;
                case Keys.W:
                    gameCanvas.HoldCircuitElement(gameCanvas.CurrentCircuitElementDroppedType, 
                        gameCanvas.CurrentCircuitElementDroppedVoltage, gameCanvas.CurrentCircuitElementDroppedResistance);
                    break;
                case Keys.S:
                    gameCanvas.WillUseHoldCircuitElement = true;
                    break;
                case Keys.G:
                    gameCanvas.SpawnCircuitElement(CircuitElementType.Resistor, 0, 20);
                    break;
            }
        }
    }
}
