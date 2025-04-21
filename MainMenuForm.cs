using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitCraft
{
    public partial class MainMenuForm : Form
    {
        private LibVLC _libvlc;
        private MediaPlayer _mediaPlayer;

        private SoundPlayer sfxPlayer;
        private string sfxFilePath_ClickButton = @"Assets\Audio\ClickButton.wav";

        public MainMenuForm()
        {
            InitializeComponent();
            LibVLC _libvlc = new LibVLC();
            MediaPlayer _mediaPlayer = new MediaPlayer(_libvlc);

            mainMenuBackgroundMedia.MediaPlayer = _mediaPlayer;
            mainMenuBackgroundMedia.SendToBack();
            _mediaPlayer.Play(Program.mainMenuMedia);
        }

        public MainGame MainGame
        {
            get => default;
            set
            {
            }
        }

        public LeaderboardsForm LeaderboardsForm
        {
            get => default;
            set
            {
            }
        }

        public SettingsForm SettingsForm
        {
            get => default;
            set
            {
            }
        }

        public LoginScreenForm LoginScreenForm
        {
            get => default;
            set
            {
            }
        }

        public TutorialForm TutorialForm
        {
            get => default;
            set
            {
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            var frm = new MainGame();
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
    }
}
