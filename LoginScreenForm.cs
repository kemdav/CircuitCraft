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
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
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
            var frm = new MainMenuForm();
            frm.Location = Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { Close(); };
            frm.Show();
            Hide();
        }

        private void signUpBttn_Click(object sender, EventArgs e)
        {
            loginPanel.Hide();
            signUpPanel.Show();
        }
    }
}
