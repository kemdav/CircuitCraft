using MaterialSkin.Controls;
using ReaLTaiizor.Controls;
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
        }

        public LoadingForm LoadingForm
        {
            get => default;
            set
            {
            }
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
            var frm = new MainMenuForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
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

            if (DataClass.AuthenticateUser(usernameLoginTbox.Text, passwordLoginTbox.Text) == false)
            {
                usernameLoginTbox.ErrorMessage = "Invalid username";
                passwordLoginTbox.ErrorMessage = "Invalid password";
                usernameLoginTbox.SetErrorState(true);
                passwordLoginTbox.SetErrorState(true);
                return;
            }
            DataClass.username = usernameLoginTbox.Text;
            var frm = new LoadingForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void signUpBttn_Click(object sender, EventArgs e)
        {
            loginPanel.Hide();
            createPasswordTbox.Text = "";
            confirmPasswordTbox.Text = "";
            createUsernameTbox.Text = "";
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

        private void backButton_Click(object sender, EventArgs e)
        {
            loginPanel.Show();
            signUpPanel.Hide();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (createPasswordTbox.Text == "" || confirmPasswordTbox.Text == "")
            {
                confirmPasswordTbox.ErrorMessage = "Password cannot be empty";
                isValid = false;
                confirmPasswordTbox.SetErrorState(true);
            }
            if (createPasswordTbox.Text != confirmPasswordTbox.Text)
            {
                confirmPasswordTbox.ErrorMessage = "Passwords do not match";
                isValid = false;
                confirmPasswordTbox.SetErrorState(true);
            }
            if (createUsernameTbox.Text == "")
            {
                createUsernameTbox.ErrorMessage = "Username cannot be empty";
                isValid = false;
                createUsernameTbox.SetErrorState(true);
            }

            if (isValid && DataClass.RegisterUser(createUsernameTbox.Text, createPasswordTbox.Text))
            {
                var frm = new LoginScreenForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosing += delegate { Close(); };
                frm.Show();
                Hide();

                DataClass.username = createUsernameTbox.Text;
                DataClass.UpdateUserInformation("profileimage", File.ReadAllBytes(Path.Combine(Application.StartupPath, "Images", "Default Profile Picture", "default.jpg")));
                DataClass.ResetUserData();
            }
            else
            {
                createUsernameTbox.ErrorMessage = "Username already exists";
                createUsernameTbox.SetErrorState(true);
            }
        }

        private void UsernameTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
            int maxLength = 12;

            if (usernameLoginTbox.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
