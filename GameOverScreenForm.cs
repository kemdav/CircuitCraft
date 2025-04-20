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

        public event EventHandler TheButtonClicked;
        protected virtual void OnTheButtonClicked()
        {
            TheButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            OnTheButtonClicked();
        }
    }
}
