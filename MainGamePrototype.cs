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
                int distance = 133;
                if (i == 0)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Series, new Point(2 + (distance * i), 0), 130, 220);
                    continue;
                }
                if (i == 1)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(2 + (distance * i), 0), 130, 220);
                    continue;
                }
                if (i == 2)
                {
                    gameCanvas.SpawnCircuitBlock(CircuitBlockConnectionType.Parallel, new Point(2 + (distance * i), 0), 130, 220);
                    continue;
                }
                gameCanvas.SpawnCircuitBlock(CircuitBlockState.Locked, new Point(2 + (distance * i), 0), 130, 220);
            }


            gameCanvas.FillUpNextComponents();

            gameCanvas.ShowChoicesPrompt = CardsChoicePrompt;
        
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
            // TODO Continous spawning of components must be i think 10 seconds or 5 seconds
            // TODO A gameplay loop where there is a clear start and a game over, the player can proceed to next level when current is completed

            // TODO Resistors Burned

            // TODO Music and Background

            // TODO Sorting in leaderboard, and Searching

            // TODO Game Balancing

            // If time allows:
            // More Cards

            // Presentation Need to Remember
            // Address how AI can be integrated to the game
            // Address how the game can be used to teach students
            // Improvements could be achievements, store, and more circuit components

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
                case Keys.S:
                    gameCanvas.WillUseHoldCircuitElement = true;
                    break;
                case Keys.Space:
                    gameCanvas.SnapCurrentDropElementToLowest();
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
            gameCanvas.JouleCurrency = 0;
        }

        private void MainGamePrototype_Shown(object sender, EventArgs e)
        {
            //EnterFullScreen();

        }
    }
}
