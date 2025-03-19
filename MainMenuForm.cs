using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
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
        private LibVLC _libvlc;
        private MediaPlayer _mediaPlayer;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            _libvlc = new LibVLC();

            _mediaPlayer = new MediaPlayer(_libvlc);
            mainMenuBackgroundMedia.MediaPlayer = _mediaPlayer;

            string exePath = Path.Combine(Application.StartupPath, "Images", "Animated", "mp4.main_menu.background.mp4");
            var media = new Media(_libvlc, exePath, FromType.FromPath);

            media.AddOption(":input-repeat=100");
            _mediaPlayer.Play(media);
            mainMenuBackgroundMedia.SendToBack();
        }

        private void playButton_Click(object sender, EventArgs e)
        {

        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {

        }

        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            var frm = new LeaderboardsForm();
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
            var frm = new LoginScreenForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void versionLABEL_Click(object sender, EventArgs e)
        {

        }

        private void settingsButton_Click_1(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click_1(object sender, EventArgs e)
        {

        }

        private void leaderboardButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
