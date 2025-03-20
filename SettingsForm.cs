using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LockedAspectRatioForm;

namespace CircuitCraft
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LibVLC _libvlc = new LibVLC();
            MediaPlayer _mediaPlayer = new MediaPlayer(_libvlc);

            backgroundVideo.MediaPlayer = _mediaPlayer;
            backgroundVideo.Visible = true;
            backgroundVideo.SendToBack();
            _mediaPlayer.Play(Program.mainMenuMedia);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //private void fullScreenCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (fullScreenCheckBox.Checked & !Program.isFullScreen)
        //    {
        //        Program.originalWindowState = WindowState;
        //        Program.originalBounds = Bounds;
        //        Program.originalBorderStyle = FormBorderStyle;

        //        TopMost = true;
        //        WindowState = FormWindowState.Normal;
        //        FormBorderStyle = FormBorderStyle.None;
        //        WindowState = FormWindowState.Maximized;
        //        Bounds = Screen.AllScreens[0].Bounds;
        //        DesktopBounds = SystemInformation.VirtualScreen;
        //        Program.isFullScreen = true;
        //        hopeForm1.Hide();
        //    }
        //    else
        //    {
        //        hopeForm1.Show();
        //        this.FormBorderStyle = Program.originalBorderStyle;
        //        this.WindowState = Program.originalWindowState;
        //        this.Bounds = Program.originalBounds;
        //        Program.isFullScreen = false;
        //    }
        //}
    }
}
