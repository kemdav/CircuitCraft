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
        private PrivateFontCollection pfc = new PrivateFontCollection();
        public LoginScreenForm()
        {
            InitializeComponent();
            Program.ApplyTransparentUI(ref loginScreenPbox, ref titleText);
            Program.ApplyTransparentUI(ref loginScreenPbox, ref loginTXT);
            Program.ApplyTransparentUI(ref loginScreenPbox, ref signupTXT);
            Program.ApplyTransparentUI(ref loginScreenPbox, ref exitTXT);

            Program.ApplyTransparentUI(ref loginPbox, ref usernameText);
            Program.ApplyTransparentUI(ref loginPbox, ref usernameTbox);

            Program.ApplyTransparentUI(ref loginPbox, ref passwordText);
            Program.ApplyTransparentUI(ref loginPbox, ref passwordTbox);

            Program.ApplyTransparentUI(ref loginPbox, ref loginUserText);

            Program.ApplyTransparentUI(ref signupPbox, ref signupUserTXT);
            Program.ApplyTransparentUI(ref signupPbox, ref signupUserTbox);
            Program.ApplyTransparentUI(ref signupPbox, ref signupPassTXT);
            Program.ApplyTransparentUI(ref signupPbox, ref signupPassTbox);
            Program.ApplyTransparentUI(ref signupPbox, ref signupCPassTXT);
            Program.ApplyTransparentUI(ref signupPbox, ref signupCPassTbox);
            Program.ApplyTransparentUI(ref signupPbox, ref signupUserBtn);


            loginPbox.Hide();
            signupPbox.Hide();
        }

        private void LoginScreenForm_Load(object sender, EventArgs e)
        {
            Stream fontStream = GetType().Assembly.GetManifestResourceStream("CircuitCraft.Resources.Font.SketchitMeansSketchit-85o2.ttf");

            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            fontStream.Close();
            unsafe
            {
                fixed (byte* pFontData = fontdata)
                {
                    pfc.AddMemoryFont((IntPtr)pFontData, fontdata.Length);
                }
            }
            titleText.Font = new Font(pfc.Families[0], 74, FontStyle.Regular);
        }

        private void LoginTXT_Click(object sender, EventArgs e)
        {
            loginScreenPbox.Hide();
            loginPbox.Show();
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
            loginScreenPbox.Hide();
            signupPbox.Show();
        }

        private void signupUserBtn_Click(object sender, EventArgs e)
        {
            // Sign Up Logic

            signupPbox.Hide();
            loginScreenPbox.Show();
        }

        private void exitTXT_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
