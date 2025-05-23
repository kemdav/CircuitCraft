﻿using LibVLCSharp.Shared;
using MaterialSkin.Controls;
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
            changePasswordPanel.Visible = false;
            if (!isInitialized)
            {
                isInitialized = true;
                DataClass.AqcuireUserInformation();
                usernameTxt.Text = "USERNAME: " + DataClass.username;
                ratingTxt.Text = "RATING: " + DataClass.Rating;
                highestLevelLabel.Text = "" + DataClass.HighestLevelReached;
                highestJoulesLabel.Text = "" + DataClass.HighestJoulesObtained;
                ledUnpoweredLabel.Text = "" + DataClass.UnpoweredLeds;
                ledBurnedLabel.Text = "" + DataClass.BurnedLeds;
                diodeBlockedLabel.Text = "" + DataClass.DiodeBlocked;
                circuitOverflowedLabel.Text = "" + DataClass.CircuitOverflowed;
                if (DataClass.profileImageBytes != null)
                {
                    using (MemoryStream stream = new MemoryStream(DataClass.profileImageBytes))
                    {
                        profilePbox.Image = System.Drawing.Image.FromStream(stream);
                        profilePbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                musicSlider.Value = DataClass.MusicVolume;
                soundSlider.Value = DataClass.SoundVolume;
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

        private string UserOperation = "";
        private void deleteButton_Click(object sender, EventArgs e)
        {
            accountSettingsPanel.Visible = false;
            UserOperation = "delete";
            confirmMessage.Text = "Are you sure you want to delete your account?";
            confirmBox.Visible = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            accountSettingsPanel.Visible = false;

            UserOperation = "reset";
            confirmMessage.Text = "Are you sure you want to reset your progress?";
            confirmBox.Visible = true;
        }

        private void confirmBoxYesButton_Click(object sender, EventArgs e)
        {
            if (UserOperation == "delete")
            {
                DataClass.DeleteUser();
                var frm = new LoginScreenForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosing += delegate { Close(); };
                frm.Show();
                Hide();
            }
            else if (UserOperation == "reset")
            {
                DataClass.ResetUser();
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

        private void changeProfilePicButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    profilePbox.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    profilePbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    DataClass.UpdateUserInformation("profileimage", File.ReadAllBytes(openFileDialog.FileName));
                    DataClass.AqcuireUserInformation();
                }
            }
        }

        private void changePasswordConfirmButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            changePasswordConfirmPasswordTbox.SetErrorState(false);
            changePasswordCreatePasswordTbox.SetErrorState(false);
            changePasswordCurrentPasswordTbox.SetErrorState(false);
            if (changePasswordCreatePasswordTbox.Text != changePasswordConfirmPasswordTbox.Text)
            {
                isValid = false;
                changePasswordCreatePasswordTbox.ErrorMessage = "";
                changePasswordConfirmPasswordTbox.ErrorMessage = "Passwords do not match";
                changePasswordCreatePasswordTbox.SetErrorState(true);
                changePasswordConfirmPasswordTbox.SetErrorState(true);
            }
            if (!DataClass.AuthenticateUser(DataClass.username, changePasswordCurrentPasswordTbox.Text))
            {
                isValid = false;
                changePasswordCurrentPasswordTbox.ErrorMessage = "Current password is incorrect";
                changePasswordCurrentPasswordTbox.SetErrorState(true);
            }
            else
            {
                if (isValid && changePasswordCurrentPasswordTbox.Text == changePasswordCreatePasswordTbox.Text)
                {
                    isValid = false;
                    changePasswordCreatePasswordTbox.ErrorMessage = "";
                    changePasswordConfirmPasswordTbox.ErrorMessage = "New password must not be the same as the current password";
                    changePasswordCreatePasswordTbox.SetErrorState(true);
                    changePasswordConfirmPasswordTbox.SetErrorState(true);
                }
            }
            if (isValid)
            {
                changePasswordCurrentPasswordTbox.SetErrorState(false);
                DataClass.UpdateUserInformation("password", changePasswordCreatePasswordTbox.Text);
                changePasswordCreatePasswordTbox.Text = "";
                changePasswordConfirmPasswordTbox.Text = "";
                changePasswordCurrentPasswordTbox.Text = "";
                changePasswordConfirmPasswordTbox.SetErrorState(false);
                changePasswordCreatePasswordTbox.SetErrorState(false);
                changePasswordPanel.Visible = false;
                accountSettingsPanel.Visible = true;
            }
        }

        private void AccountTbox_Click(object sender, EventArgs e)
        {
            changePasswordConfirmPasswordTbox.SetErrorState(false);
            changePasswordCreatePasswordTbox.SetErrorState(false);
            changePasswordCurrentPasswordTbox.SetErrorState(false);
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            changePasswordPanel.Visible = true;
            accountSettingsPanel.Visible = false;
        }

        private void changePasswordCancelButton_Click(object sender, EventArgs e)
        {
            changePasswordPanel.Visible = false;
            accountSettingsPanel.Visible = true;
        }

        private void confirmBoxNoButton_Click(object sender, EventArgs e)
        {
            confirmBox.Visible = false;
            accountSettingsPanel.Visible = true;
        }

        private void soundSlider_Validated(object sender, EventArgs e)
        {
            DataClass.SoundVolume = soundSlider.Value;
        }

        private void musicSlider_Validated(object sender, EventArgs e)
        {
            DataClass.MusicVolume = musicSlider.Value;
            AudioManager.SetMusicVolume(DataClass.MusicVolume);
        }

        private void musicSlider_Click(object sender, EventArgs e)
        {

        }
    }
}
