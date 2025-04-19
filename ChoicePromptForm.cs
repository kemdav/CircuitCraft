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
    public partial class ChoicePromptForm : Form
    {
        public event EventHandler TheButtonClicked;

        public PictureBox CardPictureBox
        {
            get { return cardImagePbox; }
        }

        public BigLabel CardDescriptionLabel
        {
            get { return cardDescription; }
        }

        public BigLabel JouleCurrencyLabel
        {
            get { return jouleCurrencyLabel; }
        }

        public ChoicePromptForm()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            OnTheButtonClicked();
        }

        protected virtual void OnTheButtonClicked()
        {
            // Check if any listeners are subscribed before raising the event
            TheButtonClicked?.Invoke(this, EventArgs.Empty);
            // If using custom EventArgs:
            // TheButtonClickedWithData?.Invoke(this, new MyCustomEventArgs("Some Data"));
        }
    }
}
