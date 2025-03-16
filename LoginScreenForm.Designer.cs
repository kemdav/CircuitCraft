namespace CircuitCraft
{
    partial class LoginScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreenForm));
            loginScreenPbox = new PictureBox();
            titleText = new Label();
            loginTXT = new Label();
            signupTXT = new Label();
            loginPbox = new PictureBox();
            usernameTbox = new TextBox();
            usernameText = new Label();
            passwordText = new Label();
            passwordTbox = new TextBox();
            loginUserText = new Label();
            signupPbox = new PictureBox();
            signupUserBtn = new Label();
            signupPassTbox = new TextBox();
            signupPassTXT = new Label();
            signupUserTbox = new TextBox();
            signupUserTXT = new Label();
            signupCPassTbox = new TextBox();
            signupCPassTXT = new Label();
            exitTXT = new Label();
            ((System.ComponentModel.ISupportInitialize)loginScreenPbox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loginPbox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)signupPbox).BeginInit();
            SuspendLayout();
            // 
            // loginScreenPbox
            // 
            loginScreenPbox.Image = (Image)resources.GetObject("loginScreenPbox.Image");
            loginScreenPbox.Location = new Point(0, -2);
            loginScreenPbox.Name = "loginScreenPbox";
            loginScreenPbox.Size = new Size(1280, 720);
            loginScreenPbox.SizeMode = PictureBoxSizeMode.Zoom;
            loginScreenPbox.TabIndex = 1;
            loginScreenPbox.TabStop = false;
            // 
            // titleText
            // 
            titleText.BackColor = Color.Transparent;
            titleText.Font = new Font("Sketchit Means Sketchit", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleText.Location = new Point(313, 158);
            titleText.Name = "titleText";
            titleText.Size = new Size(646, 87);
            titleText.TabIndex = 3;
            titleText.Text = "CIRCUIT CRAFT";
            // 
            // loginTXT
            // 
            loginTXT.BackColor = Color.Transparent;
            loginTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginTXT.Location = new Point(508, 303);
            loginTXT.Name = "loginTXT";
            loginTXT.Size = new Size(227, 87);
            loginTXT.TabIndex = 4;
            loginTXT.Text = "LOGIN";
            loginTXT.TextAlign = ContentAlignment.MiddleCenter;
            loginTXT.Click += LoginTXT_Click;
            // 
            // signupTXT
            // 
            signupTXT.BackColor = Color.Transparent;
            signupTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupTXT.Location = new Point(508, 409);
            signupTXT.Name = "signupTXT";
            signupTXT.Size = new Size(227, 87);
            signupTXT.TabIndex = 5;
            signupTXT.Text = "SIGN UP";
            signupTXT.TextAlign = ContentAlignment.MiddleCenter;
            signupTXT.Click += signupTXT_Click_1;
            // 
            // loginPbox
            // 
            loginPbox.Image = (Image)resources.GetObject("loginPbox.Image");
            loginPbox.Location = new Point(0, -2);
            loginPbox.Name = "loginPbox";
            loginPbox.Size = new Size(1280, 720);
            loginPbox.SizeMode = PictureBoxSizeMode.Zoom;
            loginPbox.TabIndex = 6;
            loginPbox.TabStop = false;
            // 
            // usernameTbox
            // 
            usernameTbox.BackColor = SystemColors.InactiveBorder;
            usernameTbox.Font = new Font("Smart Duck", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTbox.Location = new Point(448, 198);
            usernameTbox.MaxLength = 12;
            usernameTbox.Name = "usernameTbox";
            usernameTbox.Size = new Size(433, 45);
            usernameTbox.TabIndex = 8;
            usernameTbox.TextChanged += Tbox_TextChanged;
            usernameTbox.KeyPress += Tbox_KeyPress;
            // 
            // usernameText
            // 
            usernameText.AutoSize = true;
            usernameText.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameText.Location = new Point(197, 198);
            usernameText.Name = "usernameText";
            usernameText.Size = new Size(204, 50);
            usernameText.TabIndex = 7;
            usernameText.Text = "Username";
            usernameText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordText
            // 
            passwordText.AutoSize = true;
            passwordText.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordText.Location = new Point(197, 303);
            passwordText.Name = "passwordText";
            passwordText.Size = new Size(186, 50);
            passwordText.TabIndex = 9;
            passwordText.Text = "Password";
            passwordText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordTbox
            // 
            passwordTbox.BackColor = SystemColors.InactiveBorder;
            passwordTbox.Font = new Font("Smart Duck", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTbox.Location = new Point(448, 310);
            passwordTbox.MaxLength = 12;
            passwordTbox.Name = "passwordTbox";
            passwordTbox.Size = new Size(433, 45);
            passwordTbox.TabIndex = 10;
            passwordTbox.UseSystemPasswordChar = true;
            passwordTbox.TextChanged += Tbox_TextChanged;
            passwordTbox.KeyPress += Tbox_KeyPress;
            // 
            // loginUserText
            // 
            loginUserText.AutoSize = true;
            loginUserText.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginUserText.Location = new Point(559, 461);
            loginUserText.Name = "loginUserText";
            loginUserText.Size = new Size(136, 50);
            loginUserText.TabIndex = 11;
            loginUserText.Text = "LOGIN";
            loginUserText.TextAlign = ContentAlignment.MiddleCenter;
            loginUserText.Click += loginUserText_Click;
            // 
            // signupPbox
            // 
            signupPbox.Image = (Image)resources.GetObject("signupPbox.Image");
            signupPbox.Location = new Point(-8, -20);
            signupPbox.Name = "signupPbox";
            signupPbox.Size = new Size(1280, 720);
            signupPbox.SizeMode = PictureBoxSizeMode.Zoom;
            signupPbox.TabIndex = 12;
            signupPbox.TabStop = false;
            // 
            // signupUserBtn
            // 
            signupUserBtn.AutoSize = true;
            signupUserBtn.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupUserBtn.Location = new Point(559, 525);
            signupUserBtn.Name = "signupUserBtn";
            signupUserBtn.Size = new Size(172, 50);
            signupUserBtn.TabIndex = 17;
            signupUserBtn.Text = "SIGN UP";
            signupUserBtn.TextAlign = ContentAlignment.MiddleCenter;
            signupUserBtn.Click += signupUserBtn_Click;
            // 
            // signupPassTbox
            // 
            signupPassTbox.BackColor = SystemColors.InactiveBorder;
            signupPassTbox.Font = new Font("Smart Duck", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupPassTbox.Location = new Point(541, 296);
            signupPassTbox.MaxLength = 12;
            signupPassTbox.Name = "signupPassTbox";
            signupPassTbox.Size = new Size(433, 45);
            signupPassTbox.TabIndex = 16;
            signupPassTbox.UseSystemPasswordChar = true;
            // 
            // signupPassTXT
            // 
            signupPassTXT.AutoSize = true;
            signupPassTXT.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupPassTXT.Location = new Point(179, 291);
            signupPassTXT.Name = "signupPassTXT";
            signupPassTXT.Size = new Size(186, 50);
            signupPassTXT.TabIndex = 15;
            signupPassTXT.Text = "Password";
            signupPassTXT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // signupUserTbox
            // 
            signupUserTbox.BackColor = SystemColors.InactiveBorder;
            signupUserTbox.Font = new Font("Smart Duck", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupUserTbox.Location = new Point(541, 184);
            signupUserTbox.MaxLength = 12;
            signupUserTbox.Name = "signupUserTbox";
            signupUserTbox.Size = new Size(433, 45);
            signupUserTbox.TabIndex = 14;
            // 
            // signupUserTXT
            // 
            signupUserTXT.AutoSize = true;
            signupUserTXT.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupUserTXT.Location = new Point(179, 184);
            signupUserTXT.Name = "signupUserTXT";
            signupUserTXT.Size = new Size(204, 50);
            signupUserTXT.TabIndex = 13;
            signupUserTXT.Text = "Username";
            signupUserTXT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // signupCPassTbox
            // 
            signupCPassTbox.BackColor = SystemColors.InactiveBorder;
            signupCPassTbox.Font = new Font("Smart Duck", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupCPassTbox.Location = new Point(541, 380);
            signupCPassTbox.MaxLength = 12;
            signupCPassTbox.Name = "signupCPassTbox";
            signupCPassTbox.Size = new Size(433, 45);
            signupCPassTbox.TabIndex = 19;
            signupCPassTbox.UseSystemPasswordChar = true;
            // 
            // signupCPassTXT
            // 
            signupCPassTXT.AutoSize = true;
            signupCPassTXT.Font = new Font("Sketchit Means Sketchit", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupCPassTXT.Location = new Point(178, 380);
            signupCPassTXT.Name = "signupCPassTXT";
            signupCPassTXT.Size = new Size(341, 50);
            signupCPassTXT.TabIndex = 18;
            signupCPassTXT.Text = "Confirm Password";
            signupCPassTXT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exitTXT
            // 
            exitTXT.BackColor = Color.Transparent;
            exitTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitTXT.Location = new Point(508, 511);
            exitTXT.Name = "exitTXT";
            exitTXT.Size = new Size(227, 87);
            exitTXT.TabIndex = 20;
            exitTXT.Text = "EXIT";
            exitTXT.TextAlign = ContentAlignment.MiddleCenter;
            exitTXT.Click += exitTXT_Click;
            // 
            // LoginScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(1264, 681);
            Controls.Add(exitTXT);
            Controls.Add(signupCPassTbox);
            Controls.Add(signupCPassTXT);
            Controls.Add(signupUserBtn);
            Controls.Add(signupPassTbox);
            Controls.Add(signupPassTXT);
            Controls.Add(signupUserTbox);
            Controls.Add(signupUserTXT);
            Controls.Add(loginUserText);
            Controls.Add(passwordTbox);
            Controls.Add(passwordText);
            Controls.Add(usernameTbox);
            Controls.Add(usernameText);
            Controls.Add(signupTXT);
            Controls.Add(loginTXT);
            Controls.Add(titleText);
            Controls.Add(signupPbox);
            Controls.Add(loginScreenPbox);
            Controls.Add(loginPbox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)loginScreenPbox).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginPbox).EndInit();
            ((System.ComponentModel.ISupportInitialize)signupPbox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox loginScreenPbox;
        private Label titleText;
        private Label loginTXT;
        private Label signupTXT;
        private PictureBox loginPbox;
        private TextBox usernameTbox;
        private Label usernameText;
        private Label passwordText;
        private TextBox passwordTbox;
        private Label loginUserText;
        private PictureBox signupPbox;
        private Label signupUserBtn;
        private TextBox signupPassTbox;
        private Label signupPassTXT;
        private TextBox signupUserTbox;
        private Label signupUserTXT;
        private TextBox signupCPassTbox;
        private Label signupCPassTXT;
        private Label exitTXT;
    }
}