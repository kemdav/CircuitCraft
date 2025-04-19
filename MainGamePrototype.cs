using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CircuitCraft
{
    public partial class MainGamePrototype : Form
    {

        public MainGamePrototype()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(PlayerInput);


            for (int i = 0; i < 12; i++)
            {
                if (i == 0 || i == 1 || i == 2)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(5 + (56 * i), 6), 50, 130);
                    continue;
                }
                gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Locked, new Point(5 + (56 * i), 6), 50, 130);
            }

            gameCanvas.gameTimer.Start();
            gameCanvas.warningTimer.Start();

            gameCanvas.OperatingCurrent = 0.2;
            gameCanvas.MinimumOperatingCurrent = 0.1;

            gameCanvas.FillUpNextComponents();
        
        }

        public void EnterFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Bounds = Screen.FromControl(this).Bounds;
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
                    gameCanvas.SpawnNextComponent();
                    break;
                case Keys.P:
                    MainGameChoiceOverlay frm = new MainGameChoiceOverlay();
                    frm.Location = Location;
                    frm.Opacity = 0.7f;
                    frm.StartPosition = FormStartPosition.Manual;
                    if (WindowState == FormWindowState.Maximized)
                    {
                        frm.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        frm.Width = Width;
                        frm.Height = Height;
                    }
                    frm.FormClosing += delegate { Close(); };
                    frm.ShowInTaskbar = false;
                    frm.Show();

                    List<Panel> choicePanelList = new List<Panel>() { frm.ChoicePanel1, frm.ChoicePanel2, frm.ChoicePanel3 };
                    foreach (Panel panel in choicePanelList)
                    {
                        ChoicePromptForm frmPrompt1 = new ChoicePromptForm();
                        frmPrompt1.StartPosition = FormStartPosition.Manual;
                        Point panelTopLeftOnScreen = panel.PointToScreen(Point.Empty);
                        frmPrompt1.Location = panelTopLeftOnScreen;
                        frmPrompt1.ShowInTaskbar = false;
                        frmPrompt1.Show();
                    }
                    break;
            }
        }

        private void gameCanvas_Load(object sender, EventArgs e)
        {
            gameCanvas.JouleCurrency = 1000;
        }

        private void MainGamePrototype_Shown(object sender, EventArgs e)
        {
            EnterFullScreen();
        }
    }
}
