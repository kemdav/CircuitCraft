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
