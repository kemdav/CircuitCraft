using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitCraft
{
    public partial class GameOverScreenForm : Form
    {
        public GameOverScreenForm()
        {
            InitializeComponent();
        }

        public event EventHandler OnPlayAgainButtonClicked;
        public event EventHandler OnBackToMainMenuClicked;

        public int RecordedHighestLevel = 0;
        public int RecordedLedBurned = 0;
        public int RecordedLedUnpowered  = 0;
        public int RecordedHighestJoule  = 0;
        public int RecordedRating  = 0;
        public int RecordedDiodeBlocked  = 0;
        public int RecordedCircuitOverflowed = 0;

        public int Rating
        {
            set
            {
                if (value > RecordedRating)
                {
                    ratingChangeLabel.ForeColor = Color.Green;
                    ratingChangeLabel.Text = RecordedRating + " -> " + value;
                }
                else if (value < RecordedRating)
                {
                    ratingChangeLabel.ForeColor = Color.Red;
                    ratingChangeLabel.Text = RecordedRating + " -> " + value;
                }
                else if (value == RecordedRating)
                {
                    ratingChangeLabel.ForeColor = Color.Black;
                    ratingChangeLabel.Text = RecordedRating + " -> " + value;
                }
            }
        }

        public int HighestLevel
        {
            set
            {
                if (value > RecordedHighestLevel)
                {
                    highestLevelChangeLabel.ForeColor = Color.Green;
                    highestLevelChangeLabel.Text = RecordedHighestLevel + " -> " + value;
                }
                else if (value == RecordedHighestLevel)
                {
                    highestLevelChangeLabel.ForeColor = Color.Black;
                    highestLevelChangeLabel.Text = RecordedHighestLevel + " -> " + value;
                }
            }
        }

        public int LedBurned
        {
            set
            {
                if (value > RecordedLedBurned)
                {
                    ledBurnedChangeLabel.ForeColor = Color.Red;
                    ledBurnedChangeLabel.Text = RecordedHighestLevel + " -> " + value;
                }
                else if (value == RecordedLedBurned)
                {
                    ledBurnedChangeLabel.ForeColor = Color.Black;
                    ledBurnedChangeLabel.Text = RecordedLedBurned + " -> " + value;
                }
            }
        }

        public int LedUnpowered
        {
            set
            {
                if (value > RecordedLedUnpowered)
                {
                    ledUnpoweredChangeLabel.ForeColor = Color.Red;
                    ledUnpoweredChangeLabel.Text = RecordedLedUnpowered + " -> " + value;
                }
                else if (value == RecordedLedUnpowered)
                {
                    ledUnpoweredChangeLabel.ForeColor = Color.Black;
                    ledUnpoweredChangeLabel.Text = RecordedLedUnpowered + " -> " + value;
                }
            }
        }

        public int HighestJoule
        {
            set
            {
                if (value > RecordedHighestJoule)
                {
                    jouleLabel.ForeColor = Color.Green;
                    jouleLabel.Text = RecordedHighestJoule + " -> " + value;
                }
                else if (value == RecordedHighestJoule)
                {
                    jouleLabel.ForeColor = Color.Black;
                    jouleLabel.Text = RecordedHighestJoule + " -> " + value;
                }
            }
        }

        public int Overflow
        {
            set
            {
                if (value > RecordedCircuitOverflowed)
                {
                    overflowLabel.ForeColor = Color.Red;
                    overflowLabel.Text = RecordedCircuitOverflowed + " -> " + value;
                }
                else if (value == RecordedCircuitOverflowed)
                {
                    overflowLabel.ForeColor = Color.Black;
                    overflowLabel.Text = RecordedCircuitOverflowed + " -> " + value;
                }
            }
        }

        public int ReverseDiode
        {
            set
            {
                if (value > RecordedDiodeBlocked)
                {
                    diodeLabel.ForeColor = Color.Red;
                    diodeLabel.Text = RecordedDiodeBlocked + " -> " + value;
                }
                else if (value == RecordedDiodeBlocked)
                {
                    diodeLabel.ForeColor = Color.Black;
                    diodeLabel.Text = RecordedDiodeBlocked + " -> " + value;
                }
            }
        }
        public void SetGameOverText(string text)
        {
            gameOverMessage.Text = text;
        }

        protected virtual void OnPlayAgainClicked()
        {
            OnPlayAgainButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnMainMenuClicked()
        {
            OnBackToMainMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            OnPlayAgainClicked();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            OnMainMenuClicked();
        }
    }
}
