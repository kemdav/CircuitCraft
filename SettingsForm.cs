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
using static System.Net.Mime.MediaTypeNames;

namespace CircuitCraft
{
    public partial class SettingsForm : Form
    {
        private bool isInitialized = false;
        public SettingsForm()
        {
            InitializeComponent();
            confirmBox.Visible = false;
            if (!isInitialized)
            {
                isInitialized = true;
                usernameTxt.Text = "USERNAME: " + DataClass.username;
                ratingTxt.Text = "RATING: " + DataClass.rating;
                circuitsCompletedTxt.Text = "" + DataClass.circuitsCompleted;
                ledsBurnedTxt.Text = "" + DataClass.burnedLed;
                resistorsBurnedTxt.Text = "" + DataClass.burnedResistors;
                if (DataClass.profileImageBytes != null)
                {
                    using (MemoryStream stream = new MemoryStream(DataClass.profileImageBytes))
                    {
                        profilePbox.Image = System.Drawing.Image.FromStream(stream);
                    }
                }
                musicSlider.Value = DataClass.musicVolume;
                soundSlider.Value = DataClass.soundVolume;
            }
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

        private string UserOperation = "";
        private void deleteButton_Click(object sender, EventArgs e)
        {
            resetButton.Enabled = false;
            deleteButton.Enabled = false;

            UserOperation = "delete";
            confirmMessage.Text = "Are you sure you want to delete your account?";
            confirmBox.Visible = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetButton.Enabled = false;
            deleteButton.Enabled = false;

            UserOperation = "reset";
            confirmMessage.Text = "Are you sure you want to reset your progress?";
            confirmBox.Visible = true;
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
