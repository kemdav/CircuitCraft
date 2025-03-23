using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitCraft
{
    public partial class LoginScreenForm : Form
    {
        public LoginScreenForm()
        {
            InitializeComponent();
            signUpPanel.Hide();

            usernameLoginTbox.MaxLength = 12;
        }

        private void LoginScreenForm_Load(object sender, EventArgs e)
        {
        }

        private void Tbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Tbox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = Regex.Replace((sender as TextBox).Text, @"\s+", "");
        }

        private void loginUserText_Click(object sender, EventArgs e)
        {
            // Login Logic
            var frm = new MainMenuForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void signupTXT_Click_1(object sender, EventArgs e)
        {
        }

        private void signupUserBtn_Click(object sender, EventArgs e)
        {
        }

        private void exitTXT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginBttn_Click(object sender, EventArgs e)
        {
            if (usernameLoginTbox.Text == "" || passwordLoginTbox.Text == "")
            {
                if (usernameLoginTbox.Text == "")
                {
                    usernameLoginTbox.ErrorMessage = "Username cannot be empty";
                    usernameLoginTbox.SetErrorState(true);
                }
                if (passwordLoginTbox.Text == "")
                {
                    passwordLoginTbox.ErrorMessage = "Password cannot be empty";
                    passwordLoginTbox.SetErrorState(true);
                }
                return;
            }
            if (usernameLoginTbox.Text != "user" && passwordLoginTbox.Text != "123")
            {
                usernameLoginTbox.ErrorMessage = "Invalid username";
                passwordLoginTbox.ErrorMessage = "Invalid password";
                usernameLoginTbox.SetErrorState(true);
                passwordLoginTbox.SetErrorState(true);
                return;
            }
            var frm = new LoadingForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void signUpBttn_Click(object sender, EventArgs e)
        {
            loginPanel.Hide();
            signUpPanel.Show();
        }

        private void InformationTbox_Click(object sender, EventArgs e)
        {
            if (usernameLoginTbox.GetErrorState() == true || passwordLoginTbox.GetErrorState() == true)
            {
                usernameLoginTbox.SetErrorState(false);
                passwordLoginTbox.SetErrorState(false);
            }
            if (createUsernameTbox.GetErrorState() == true || createPasswordTbox.GetErrorState() == true || confirmPasswordTbox.GetErrorState() == true)
            {
                createUsernameTbox.SetErrorState(false);
                createPasswordTbox.SetErrorState(false);
                confirmPasswordTbox.SetErrorState(false);
            }
        }

        private void passwordLoginTbox_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            loginPanel.Show();
            signUpPanel.Hide();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (createPasswordTbox.Text == "" || confirmPasswordTbox.Text == "")
            {
                confirmPasswordTbox.ErrorMessage = "Password cannot be empty";
                confirmPasswordTbox.SetErrorState(true);
            }
            if (createPasswordTbox.Text != confirmPasswordTbox.Text)
            {
                confirmPasswordTbox.ErrorMessage = "Passwords do not match";
                confirmPasswordTbox.SetErrorState(true);
            }
            if (createUsernameTbox.Text == "")
            {
                createUsernameTbox.ErrorMessage = "Username cannot be empty";
                createUsernameTbox.SetErrorState(true);
            }
            else if (createUsernameTbox.Text == "user")
            {
                createUsernameTbox.ErrorMessage = "Username already exists";
                createUsernameTbox.SetErrorState(true);
            }           
        }
    }
}
