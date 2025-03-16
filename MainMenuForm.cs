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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();

            Program.ApplyTransparentUI(ref mainMenuPbox, ref tutorialTXT);
            Program.ApplyTransparentUI(ref mainMenuPbox, ref leaderboardsTXT);
            Program.ApplyTransparentUI(ref mainMenuPbox, ref settingsTXT);
            Program.ApplyTransparentUI(ref mainMenuPbox, ref playTXT);
            Program.ApplyTransparentUI(ref mainMenuPbox, ref logoutTXT);

            Program.ApplyTransparentUI(ref settingsPbox, ref musicTXT);
            Program.ApplyTransparentUI(ref settingsPbox, ref soundTXT);
            Program.ApplyTransparentUI(ref settingsPbox, ref musicSlider);
            Program.ApplyTransparentUI(ref settingsPbox, ref settingsBackTXT);

            settingsPbox.Hide();
        }

        private void logoutTXT_Click(object sender, EventArgs e)
        {
            var frm = new LoginScreenForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void settingsTXT_Click(object sender, EventArgs e)
        {
            mainMenuPbox.Hide();
            settingsPbox.Show();
        }

        private void settingsBackTXT_Click(object sender, EventArgs e)
        {
            settingsPbox.Hide();
            mainMenuPbox.Show();
        }

        private void leaderboardsTXT_Click(object sender, EventArgs e)
        {
            var frm = new LeaderboardsForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void playTXT_Click(object sender, EventArgs e)
        {
            var frm = new TutorialForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void tutorialTXT_Click(object sender, EventArgs e)
        {
            var frm = new TutorialForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }
    }
}
