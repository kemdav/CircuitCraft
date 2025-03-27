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
using Timer = System.Windows.Forms.Timer;

namespace CircuitCraft
{
    public partial class LoadingForm : Form
    {

        private LibVLC _libvlc;
        private MediaPlayer _mediaPlayer;
        private System.Windows.Forms.Timer timer = new Timer();

        public LoadingForm()
        {
            InitializeComponent();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {
            await LoadVideoInBackground();
            timer.Stop();
            timer.Interval = 25;
            timer.Tick += new EventHandler(timer_Finish);
            timer.Start();
        }

        private void timer_Finish(object sender, EventArgs e)
        {
            loadProgressBar.Progress += 1;
            if (loadProgressBar.Progress >= 100)
            {
                ((Timer)sender).Stop();
                var frm = new MainMenuForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosing += delegate { Close(); };
                frm.Show();
                Hide();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            loadProgressBar.Progress += 1;        
        }

        private async Task LoadVideoInBackground()
        {
            await Task.Run(() =>
            {
                DataClass.AqcuireUserInformation();
                _libvlc = new LibVLC();
                _mediaPlayer = new MediaPlayer(_libvlc);

                string exePath = Path.Combine(Application.StartupPath, "Images", "Animated", "mp4.main_menu.background.mp4");
                Program.mainMenuMedia = new Media(_libvlc, exePath, FromType.FromPath);
                Program.mainMenuMedia.AddOption(":input-repeat=100");
            });
        }

        private void loadProgressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
