using LibVLCSharp.Shared;
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
    public partial class LeaderboardsForm : Form
    {
        public LeaderboardsForm()
        {
            InitializeComponent();
        }

        private void LeaderboardsForm_Load(object sender, EventArgs e)
        {
            LibVLC _libvlc = new LibVLC();
            MediaPlayer _mediaPlayer = new MediaPlayer(_libvlc);

            backgroundVideo.MediaPlayer = _mediaPlayer;
            backgroundVideo.Visible = true;
            backgroundVideo.SendToBack();
            _mediaPlayer.Play(Program.mainMenuMedia);
        }

        private void leaderboardBackTXT_Click(object sender, EventArgs e)
        {
            var frm = new MainMenuForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bigLabel3_Click(object sender, EventArgs e)
        {

        }

        private void returnMainMenuButton_Click(object sender, EventArgs e)
        {
            var frm = new MainMenuForm();
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
    }
}
