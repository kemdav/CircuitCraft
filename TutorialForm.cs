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
    public partial class TutorialForm : Form
    {
        public TutorialForm()
        {
            InitializeComponent();
            InitializePbox();
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Visible = false;
                if (i == currentIndex)
                {
                    pictureBoxes[i].Visible = true;
                    pictureBoxes[i].BringToFront();
                    break;
                }
            }
        }

        public List<PictureBox> pictureBoxes;
        public int currentIndex = 0;
        public void InitializePbox()
        {
            pictureBoxes = new List<PictureBox>() { t1, t2, t3, t4, t5, t6, t7, t8, t9 };
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            var frm = new MainMenuForm();
            frm.Location = Location;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            InitializePbox();
            if (currentIndex <= 0) { return; }
            currentIndex--;
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Visible = false;
                if (i == currentIndex)
                {
                    pictureBoxes[i].Visible = true;
                    pictureBoxes[i].BringToFront();
                    break;
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            InitializePbox();
            if (currentIndex + 1 >= pictureBoxes.Count) { return; }
            currentIndex++;
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Visible = false;
                if (i == currentIndex)
                {
                    pictureBoxes[i].Visible = true;
                    pictureBoxes[i].BringToFront();
                    break;
                }
            }
        }
    }
}
