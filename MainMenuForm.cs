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
            mainMenuBackgroundMedia.Visible = false;
            AspectRatio = 16f / 9f;
        }

        private async void MainMenuForm_Load(object sender, EventArgs e)
        {
            await LoadVideoInBackground();
        }


        private async Task LoadVideoInBackground()
        {
            await Task.Run(() =>
            {
                _libvlc = new LibVLC();
                _mediaPlayer = new MediaPlayer(_libvlc);

                string exePath = Path.Combine(Application.StartupPath, "Images", "Animated", "mp4.main_menu.background.mp4");
                Program.mainMenuMedia = new Media(_libvlc, exePath, FromType.FromPath);
                Program.mainMenuMedia.AddOption(":input-repeat=100");

                // **Use Invoke to access UI control safely**
                this.Invoke((MethodInvoker)delegate
                {
                    mainMenuBackgroundMedia.MediaPlayer = _mediaPlayer;
                    mainMenuBackgroundMedia.SendToBack();
                    _mediaPlayer.Play(Program.mainMenuMedia);
                    Thread.Sleep(100);
                    mainMenuBackgroundMedia.Visible = true;
                });
            });
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

        private void playButton_Click_1(object sender, EventArgs e)
        {
            var frm = new GameForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }
    }
}
