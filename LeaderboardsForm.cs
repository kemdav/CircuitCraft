﻿using LibVLCSharp.Shared;
using MaterialSkin.Controls;
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
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (value == 1 && DataClass.SortedUsersByRating().Count > 7)
                {
                    prevButton.Enabled = false;
                    nextButton.Enabled = true;
                }
                else if (value == 0)
                {
                    value = 1;
                }
                else if (value > 1 && value * 7 < DataClass.SortedUsersByRating().Count)
                {
                    prevButton.Enabled = true;
                    nextButton.Enabled = true;
                }
                else if (value == 1 && DataClass.SortedUsersByRating().Count < 7)
                {
                    nextButton.Enabled = false;
                    prevButton.Enabled = false;
                }
                else
                {
                    nextButton.Enabled = false;
                    prevButton.Enabled = true;
                }
                _currentPage = value;
            }
        }

        public LeaderboardsForm()
        {
            InitializeComponent();
            CurrentPage = 1;
            prevButton.Enabled = false;
            LeaderboardRefresh(CurrentPage);
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

        private void LeaderboardRefresh(int page)
        {
            List<MaterialLabel> rankTxt = new List<MaterialLabel> { Row1Col1Txt, Row2Col1Txt, Row3Col1Txt, Row4Col1Txt, Row5Col1Txt, Row6Col1Txt, Row7Col1Txt };
            List<PictureBox> pictureBox = new List<PictureBox>() { Row1Col2Pbox, Row2Col2Pbox, Row3Col2Pbox, Row4Col2Pbox, Row5Col2Pbox, Row6Col2Pbox, Row7Col2Pbox };
            List<MaterialLabel> usernameTxt = new List<MaterialLabel> { Row1Col3Txt, Row2Col3Txt, Row3Col3Txt, Row4Col3Txt, Row5Col3Txt, Row6Col3Txt, Row7Col3Txt };
            List<MaterialLabel> completedCircuitsTxt = new List<MaterialLabel> { Row1Col4Txt, Row2Col4Txt, Row3Col4Txt, Row4Col4Txt, Row5Col4Txt, Row6Col4Txt, Row7Col4Txt };
            List<MaterialLabel> resistorsBurnedTxt = new List<MaterialLabel> { Row1Col5Txt, Row2Col5Txt, Row3Col5Txt, Row4Col5Txt, Row5Col5Txt, Row6Col5Txt, Row7Col5Txt };
            List<MaterialLabel> ledsBurnedTxt = new List<MaterialLabel> { Row1Col6Txt, Row2Col6Txt, Row3Col6Txt, Row4Col6Txt, Row5Col6Txt, Row6Col6Txt, Row7Col6Txt };
            List<MaterialLabel> ratingTxt = new List<MaterialLabel> { Row1Col7Txt, Row2Col7Txt, Row3Col7Txt, Row4Col7Txt, Row5Col7Txt, Row6Col7Txt, Row7Col7Txt };

            List<TempUserInformation> tempUserInformation = DataClass.SortedUsersByRating();
            for (int i = (page - 1) * 7; i < page * 7; i++)
            {
                if (i >= tempUserInformation.Count)
                {
                    rankTxt[i - ((page - 1) * 7)].Text = "";
                    pictureBox[i - ((page - 1) * 7)].Image = null;
                    usernameTxt[i - ((page - 1) * 7)].Text = "";
                    completedCircuitsTxt[i - ((page - 1) * 7)].Text = "";
                    resistorsBurnedTxt[i - ((page - 1) * 7)].Text = "";
                    ledsBurnedTxt[i - ((page - 1) * 7)].Text = "";
                    ratingTxt[i - ((page - 1) * 7)].Text = "";
                    continue;
                }
                rankTxt[i - ((page - 1) * 7)].Text = (i + 1).ToString();
                if (tempUserInformation[i].ProfileImage != null)
                {
                    using (MemoryStream stream = new MemoryStream(tempUserInformation[i].ProfileImage))
                    {
                        pictureBox[i - ((page - 1) * 7)].Image = System.Drawing.Image.FromStream(stream);
                        pictureBox[i - ((page - 1) * 7)].SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pictureBox[i - ((page - 1) * 7)].Image = null;
                }
                usernameTxt[i - ((page - 1) * 7)].Text = tempUserInformation[i].Username;
                completedCircuitsTxt[i - ((page - 1) * 7)].Text = tempUserInformation[i].CircuitsCompleted.ToString();
                resistorsBurnedTxt[i - ((page - 1) * 7)].Text = tempUserInformation[i].BurnedResistors.ToString();
                ledsBurnedTxt[i - ((page - 1) * 7)].Text = tempUserInformation[i].BurnedLed.ToString();
                ratingTxt[i - ((page - 1) * 7)].Text = tempUserInformation[i].Rating.ToString();
            }

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

        private void nextButton_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            LeaderboardRefresh(CurrentPage);
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            LeaderboardRefresh(CurrentPage);
        }
    }
}
