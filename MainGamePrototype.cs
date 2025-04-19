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
        private List<ChoicePromptForm> choicePromptForms = new List<ChoicePromptForm>();

        public MainGamePrototype()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(PlayerInput);


            for (int i = 0; i < 12; i++)
            {
                if (i == 0 || i == 1 || i == 2)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(5 + (140 * i), 0), 130, 220);
                    continue;
                }
                gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Locked, new Point(5 + (132 * i), 0), 130, 220);
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

            foreach (CircuitBlock circuitBlock in gameCanvas.CircuitBlocks)
            {
                circuitBlock.CircuitElementWidth = 50;
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
                    choicePromptForms.Clear();
                    foreach (Panel panel in choicePanelList)
                    {
                        ChoicePromptForm frmPrompt1 = new ChoicePromptForm();
                        frmPrompt1.StartPosition = FormStartPosition.Manual;
                        Point panelTopLeftOnScreen = panel.PointToScreen(Point.Empty);
                        frmPrompt1.Location = panelTopLeftOnScreen;
                        frmPrompt1.ShowInTaskbar = false;
                        frmPrompt1.Show();
                        frmPrompt1.TheButtonClicked += ChoicePrompt_TheButtonClicked;
                        frmPrompt1.FormClosed += (s, args) =>
                        {
                            frmPrompt1.TheButtonClicked -= ChoicePrompt_TheButtonClicked;
                        };
                        choicePromptForms.Add(frmPrompt1);
                    }
                    break;
            }
        }

        private void ChoicePrompt_TheButtonClicked(object sender, EventArgs e)
        {
            // --- This code runs in FormA when the button on FormB is clicked ---


            // You can access the instance of FormB that raised the event via 'sender'
            ChoicePromptForm sourceForm = sender as ChoicePromptForm;
            if (sourceForm != null)
            {
                // Obtain properties
            }
            foreach (ChoicePromptForm form in choicePromptForms)
            {
                form.Close();
            }
        }

        private void gameCanvas_Load(object sender, EventArgs e)
        {
            gameCanvas.JouleCurrency = 1000;
        }

        private void MainGamePrototype_Shown(object sender, EventArgs e)
        {
            //EnterFullScreen();

        }
    }
}
