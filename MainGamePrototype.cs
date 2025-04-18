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

        Timer gameTimer = new Timer();


        public MainGamePrototype()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(PlayerInput);

            gameTimer.Interval = 1;
            gameTimer.Tick += new EventHandler(Timer_Tick);

            for (int i = 0; i < 12; i++)
            {
                gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(5 + (56 * i), 6), 50, 130);
            }

            gameTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!gameCanvas.DropDownCircuitElement(2))
            {
                //UpdateCircuitElementUI();
            }
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
                    gameCanvas.SpawnCircuitElement(CircuitElementType.Source, 10, 0);
                    break;
            }
        }
    }
}
