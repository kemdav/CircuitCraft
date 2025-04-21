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
    public struct ChoicePromptData
    {
        public Cards Cards;
        public string CardDescription;
        public Image CardImage;
        public int Cost;
    }
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

        public BigLabel CostLabel
        {
            get { return costLabel; }
        }

        private ChoicePromptData _choicePromptData;
        public ChoicePromptData ChoicePromptData
        {
            get { return _choicePromptData; }
            set
            {
                _choicePromptData = value;

                cardImagePbox.Image = value.CardImage;
                cardImagePbox.SizeMode = PictureBoxSizeMode.Zoom;

                cardDescription.Text = value.CardDescription;

                costLabel.Text = value.Cost.ToString();
                if (value.Cost == 0) { costLabel.Text = "FREE"; }
            }
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
