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
    public partial class MainMenuForm : LockedAspectRatioForm
    {
        public MainMenuForm()
        {
            InitializeComponent();
            AspectRatio = 16f / 9f;
        }

        private void playButton_Click(object sender, EventArgs e)
        {

        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {

        }

        private void leaderboardButton_Click(object sender, EventArgs e)
        {

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var frm = new SettingsForm();
            frm.Location = Location;
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
            frm.Show();
            Hide();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {

        }
    }
}
