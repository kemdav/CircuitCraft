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
    public enum Cards
    {
        SeriesCircuit,
        ParallelCircuit,
        TrashCircuit
    }
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
                if (i == 0)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(5 + (140 * i), 0), 130, 220);
                    continue;
                }
                if (i == 1)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(5 + (140 * i), 0), 130, 220);
                    continue;
                }
                if (i == 2)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(5 + (140 * i), 0), 130, 220);
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
            // Rotation
            // A way to instant down the circuit component
            // A way to prevent putting elements in a full capacity circuit block

            // A working timer

            // A way to earn Joules

            // A way to differentiate between different circuit blocks

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
                case Keys.R:
                    gameCanvas.CurrentCircuitElementDroppedOrientation++;
                    break;
                case Keys.Space:
                    gameCanvas.WillUseHoldCircuitElement = true;
                    break;
                case Keys.G:
                    gameCanvas.SpawnNextComponent();
                    break;
                case Keys.P:
                    CardsChoicePrompt();
                    break;
            }
        }

        public void CardsChoicePrompt()
        {
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
            List<ChoicePromptData> cards = GenerateThreeRandomCards();
            foreach (Panel panel in choicePanelList)
            {
                ChoicePromptForm frmPrompt1 = new ChoicePromptForm();
                frmPrompt1.StartPosition = FormStartPosition.Manual;
                Point panelTopLeftOnScreen = panel.PointToScreen(Point.Empty);
                frmPrompt1.Location = panelTopLeftOnScreen;
                frmPrompt1.ShowInTaskbar = false;
                frmPrompt1.ChoicePromptData = cards[choicePanelList.IndexOf(panel)];
                frmPrompt1.Show();
                frmPrompt1.TheButtonClicked += ChoicePrompt_TheButtonClicked;
                frmPrompt1.FormClosed += (s, args) =>
                {
                    frmPrompt1.TheButtonClicked -= ChoicePrompt_TheButtonClicked;
                };
                choicePromptForms.Add(frmPrompt1);
            }
        }

        public List<ChoicePromptData> GenerateThreeRandomCards()
        {
            List<Cards> UniqueCards = new List<Cards>()
            {
                Cards.SeriesCircuit,
                Cards.ParallelCircuit,
                Cards.TrashCircuit
            };

            Random random = new Random();
            List<ChoicePromptData> cardsList = new List<ChoicePromptData>();
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(0, UniqueCards.Count);
                switch (UniqueCards[randomIndex])
                {
                    case Cards.SeriesCircuit:
                        ChoicePromptData choicePromptData = new ChoicePromptData
                        {
                            Cards = Cards.SeriesCircuit,
                            CardImage = gameCanvas.SeriesCircuitBlockCardImage,
                            CardDescription = gameCanvas.SeriesCircuitBlockCardDescription,
                            Cost = gameCanvas.SeriesCircuitBlockCardCost
                        };
                        cardsList.Add(choicePromptData);
                        break;
                    case Cards.ParallelCircuit:
                        ChoicePromptData choicePromptData2 = new ChoicePromptData
                        {
                            Cards = Cards.ParallelCircuit,
                            CardImage = gameCanvas.ParallelCircuitBlockCardImage,
                            CardDescription = gameCanvas.ParallelCircuitBlockCardDescription,
                            Cost = gameCanvas.ParallelCircuitBlockCardCost
                        };
                        cardsList.Add(choicePromptData2);
                        break;
                    case Cards.TrashCircuit:
                        ChoicePromptData choicePromptData3 = new ChoicePromptData
                        {
                            Cards = Cards.TrashCircuit,
                            CardImage = gameCanvas.TrashCircuitBlockCardImage,
                            CardDescription = gameCanvas.TrashCircuitBlockCardDescription,
                            Cost = gameCanvas.TrashCircuitBlockCardCost
                        };
                        cardsList.Add(choicePromptData3);
                        break;
                }
                UniqueCards.RemoveAt(randomIndex);
            }
            return cardsList;
        }

        private void ChoicePrompt_TheButtonClicked(object sender, EventArgs e)
        {
            ChoicePromptForm sourceForm = sender as ChoicePromptForm;
            if (sourceForm != null)
            {
                gameCanvas.UnlockCircuitBlock(sourceForm.ChoicePromptData.Cards);
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
