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
            airForm1 = new ReaLTaiizor.Forms.AirForm();
            signUpPanel = new Panel();
            signUpButton = new MaterialSkin.Controls.MaterialButton();
            confirmPasswordTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            createPasswordTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            createUsernameTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            backButton = new MaterialSkin.Controls.MaterialButton();
            loginBttn = new MaterialSkin.Controls.MaterialButton();
            signUpBttn = new MaterialSkin.Controls.MaterialButton();
            usernameLoginTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            passwordLoginTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            loginPanel = new Panel();
            airForm1.SuspendLayout();
            signUpPanel.SuspendLayout();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // airForm1
            // 
            airForm1.BackColor = Color.AliceBlue;
            airForm1.BorderStyle = FormBorderStyle.None;
            airForm1.Controls.Add(loginPanel);
            airForm1.Controls.Add(signUpPanel);
            airForm1.Customization = "AAAA/1paWv9ycnL/";
            airForm1.Dock = DockStyle.Fill;
            airForm1.Font = new Font("Segoe UI", 9F);
            airForm1.Image = null;
            airForm1.Location = new Point(0, 0);
            airForm1.MinimumSize = new Size(112, 35);
            airForm1.Movable = true;
            airForm1.Name = "airForm1";
            airForm1.NoRounding = false;
            airForm1.Sizable = true;
            airForm1.Size = new Size(419, 579);
            airForm1.SmartBounds = true;
            airForm1.StartPosition = FormStartPosition.CenterScreen;
            airForm1.TabIndex = 21;
            airForm1.Text = "Login";
            airForm1.TransparencyKey = Color.Fuchsia;
            airForm1.Transparent = false;
            // 
            // signUpPanel
            // 
            signUpPanel.Controls.Add(signUpButton);
            signUpPanel.Controls.Add(confirmPasswordTbox);
            signUpPanel.Controls.Add(bigLabel2);
            signUpPanel.Controls.Add(createPasswordTbox);
            signUpPanel.Controls.Add(createUsernameTbox);
            signUpPanel.Controls.Add(backButton);
            signUpPanel.Location = new Point(0, 23);
            signUpPanel.Name = "signUpPanel";
            signUpPanel.Size = new Size(419, 553);
            signUpPanel.TabIndex = 7;
            // 
            // signUpButton
            // 
            signUpButton.AutoSize = false;
            signUpButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            signUpButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            signUpButton.Depth = 0;
            signUpButton.HighEmphasis = true;
            signUpButton.Icon = null;
            signUpButton.Location = new Point(134, 430);
            signUpButton.Margin = new Padding(4, 6, 4, 6);
            signUpButton.MouseState = MaterialSkin.MouseState.HOVER;
            signUpButton.Name = "signUpButton";
            signUpButton.NoAccentTextColor = Color.Empty;
            signUpButton.Size = new Size(133, 36);
            signUpButton.TabIndex = 15;
            signUpButton.Text = "SIGN UP";
            signUpButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            signUpButton.UseAccentColor = false;
            signUpButton.UseVisualStyleBackColor = true;
            signUpButton.Click += signUpButton_Click;
            // 
            // confirmPasswordTbox
            // 
            confirmPasswordTbox.AllowPromptAsInput = true;
            confirmPasswordTbox.AnimateReadOnly = false;
            confirmPasswordTbox.AsciiOnly = false;
            confirmPasswordTbox.BackgroundImageLayout = ImageLayout.None;
            confirmPasswordTbox.BeepOnError = false;
            confirmPasswordTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            confirmPasswordTbox.Depth = 0;
            confirmPasswordTbox.ErrorMessage = "THE PASSWORDS DOES NOT MATCH!";
            confirmPasswordTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            confirmPasswordTbox.HidePromptOnLeave = false;
            confirmPasswordTbox.HideSelection = true;
            confirmPasswordTbox.Hint = "Confirm Password";
            confirmPasswordTbox.InsertKeyMode = InsertKeyMode.Default;
            confirmPasswordTbox.LeadingIcon = null;
            confirmPasswordTbox.Location = new Point(59, 275);
            confirmPasswordTbox.Mask = "";
            confirmPasswordTbox.MaxLength = 32767;
            confirmPasswordTbox.MouseState = MaterialSkin.MouseState.OUT;
            confirmPasswordTbox.Name = "confirmPasswordTbox";
            confirmPasswordTbox.PasswordChar = '●';
            confirmPasswordTbox.PrefixSuffixText = null;
            confirmPasswordTbox.PromptChar = '_';
            confirmPasswordTbox.ReadOnly = false;
            confirmPasswordTbox.RejectInputOnFirstFailure = false;
            confirmPasswordTbox.ResetOnPrompt = true;
            confirmPasswordTbox.ResetOnSpace = true;
            confirmPasswordTbox.RightToLeft = RightToLeft.No;
            confirmPasswordTbox.SelectedText = "";
            confirmPasswordTbox.SelectionLength = 0;
            confirmPasswordTbox.SelectionStart = 0;
            confirmPasswordTbox.ShortcutsEnabled = true;
            confirmPasswordTbox.ShowAssistiveText = true;
            confirmPasswordTbox.Size = new Size(284, 64);
            confirmPasswordTbox.SkipLiterals = true;
            confirmPasswordTbox.TabIndex = 14;
            confirmPasswordTbox.TabStop = false;
            confirmPasswordTbox.TextAlign = HorizontalAlignment.Left;
            confirmPasswordTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            confirmPasswordTbox.TrailingIcon = null;
            confirmPasswordTbox.UseSystemPasswordChar = true;
            confirmPasswordTbox.ValidatingType = null;
            confirmPasswordTbox.Click += InformationTbox_Click;
            // 
            // bigLabel2
            // 
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = Color.Transparent;
            bigLabel2.FlatStyle = FlatStyle.Popup;
            bigLabel2.Font = new Font("Swis721 Blk BT", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = Color.CornflowerBlue;
            bigLabel2.Location = new Point(59, 19);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(298, 40);
            bigLabel2.TabIndex = 11;
            bigLabel2.Text = "CIRCUIT CRAFT";
            // 
            // createPasswordTbox
            // 
            createPasswordTbox.AllowPromptAsInput = true;
            createPasswordTbox.AnimateReadOnly = false;
            createPasswordTbox.AsciiOnly = false;
            createPasswordTbox.BackgroundImageLayout = ImageLayout.None;
            createPasswordTbox.BeepOnError = false;
            createPasswordTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            createPasswordTbox.Depth = 0;
            createPasswordTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            createPasswordTbox.HidePromptOnLeave = false;
            createPasswordTbox.HideSelection = true;
            createPasswordTbox.Hint = "Create Password";
            createPasswordTbox.InsertKeyMode = InsertKeyMode.Default;
            createPasswordTbox.LeadingIcon = null;
            createPasswordTbox.Location = new Point(59, 221);
            createPasswordTbox.Mask = "";
            createPasswordTbox.MaxLength = 32767;
            createPasswordTbox.MouseState = MaterialSkin.MouseState.OUT;
            createPasswordTbox.Name = "createPasswordTbox";
            createPasswordTbox.PasswordChar = '●';
            createPasswordTbox.PrefixSuffixText = null;
            createPasswordTbox.PromptChar = '_';
            createPasswordTbox.ReadOnly = false;
            createPasswordTbox.RejectInputOnFirstFailure = false;
            createPasswordTbox.ResetOnPrompt = true;
            createPasswordTbox.ResetOnSpace = true;
            createPasswordTbox.RightToLeft = RightToLeft.No;
            createPasswordTbox.SelectedText = "";
            createPasswordTbox.SelectionLength = 0;
            createPasswordTbox.SelectionStart = 0;
            createPasswordTbox.ShortcutsEnabled = true;
            createPasswordTbox.Size = new Size(284, 48);
            createPasswordTbox.SkipLiterals = true;
            createPasswordTbox.TabIndex = 10;
            createPasswordTbox.TabStop = false;
            createPasswordTbox.TextAlign = HorizontalAlignment.Left;
            createPasswordTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            createPasswordTbox.TrailingIcon = null;
            createPasswordTbox.UseSystemPasswordChar = true;
            createPasswordTbox.ValidatingType = null;
            createPasswordTbox.Click += InformationTbox_Click;
            // 
            // createUsernameTbox
            // 
            createUsernameTbox.AllowPromptAsInput = false;
            createUsernameTbox.AnimateReadOnly = false;
            createUsernameTbox.AsciiOnly = false;
            createUsernameTbox.BackgroundImageLayout = ImageLayout.None;
            createUsernameTbox.BeepOnError = true;
            createUsernameTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            createUsernameTbox.Depth = 0;
            createUsernameTbox.ErrorMessage = "USERNAME IS ALREADY TAKEN!";
            createUsernameTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            createUsernameTbox.HidePromptOnLeave = false;
            createUsernameTbox.HideSelection = true;
            createUsernameTbox.Hint = "Create Username";
            createUsernameTbox.InsertKeyMode = InsertKeyMode.Default;
            createUsernameTbox.LeadingIcon = null;
            createUsernameTbox.Location = new Point(59, 99);
            createUsernameTbox.Mask = "";
            createUsernameTbox.MaxLength = 32767;
            createUsernameTbox.MouseState = MaterialSkin.MouseState.OUT;
            createUsernameTbox.Name = "createUsernameTbox";
            createUsernameTbox.PasswordChar = '\0';
            createUsernameTbox.PrefixSuffixText = "Username";
            createUsernameTbox.PromptChar = '_';
            createUsernameTbox.ReadOnly = false;
            createUsernameTbox.RejectInputOnFirstFailure = false;
            createUsernameTbox.ResetOnPrompt = true;
            createUsernameTbox.ResetOnSpace = true;
            createUsernameTbox.RightToLeft = RightToLeft.No;
            createUsernameTbox.SelectedText = "";
            createUsernameTbox.SelectionLength = 0;
            createUsernameTbox.SelectionStart = 0;
            createUsernameTbox.ShortcutsEnabled = true;
            createUsernameTbox.ShowAssistiveText = true;
            createUsernameTbox.Size = new Size(284, 64);
            createUsernameTbox.SkipLiterals = true;
            createUsernameTbox.TabIndex = 9;
            createUsernameTbox.TabStop = false;
            createUsernameTbox.TextAlign = HorizontalAlignment.Left;
            createUsernameTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            createUsernameTbox.TrailingIcon = null;
            createUsernameTbox.UseSystemPasswordChar = false;
            createUsernameTbox.ValidatingType = null;
            createUsernameTbox.Click += InformationTbox_Click;
            createUsernameTbox.KeyPress += UsernameTbox_KeyPress;
            // 
            // backButton
            // 
            backButton.AutoSize = false;
            backButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            backButton.Depth = 0;
            backButton.HighEmphasis = true;
            backButton.Icon = null;
            backButton.Location = new Point(134, 478);
            backButton.Margin = new Padding(4, 6, 4, 6);
            backButton.MouseState = MaterialSkin.MouseState.HOVER;
            backButton.Name = "backButton";
            backButton.NoAccentTextColor = Color.Empty;
            backButton.Size = new Size(133, 36);
            backButton.TabIndex = 7;
            backButton.Text = "BACK TO LOGIN";
            backButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            backButton.UseAccentColor = false;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // loginBttn
            // 
            loginBttn.AutoSize = false;
            loginBttn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginBttn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            loginBttn.Depth = 0;
            loginBttn.HighEmphasis = true;
            loginBttn.Icon = null;
            loginBttn.Location = new Point(134, 427);
            loginBttn.Margin = new Padding(4, 6, 4, 6);
            loginBttn.MouseState = MaterialSkin.MouseState.HOVER;
            loginBttn.Name = "loginBttn";
            loginBttn.NoAccentTextColor = Color.Empty;
            loginBttn.Size = new Size(133, 36);
            loginBttn.TabIndex = 0;
            loginBttn.Text = "Login";
            loginBttn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            loginBttn.UseAccentColor = false;
            loginBttn.UseVisualStyleBackColor = true;
            loginBttn.Click += loginBttn_Click;
            // 
            // signUpBttn
            // 
            signUpBttn.AutoSize = false;
            signUpBttn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            signUpBttn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            signUpBttn.Depth = 0;
            signUpBttn.HighEmphasis = true;
            signUpBttn.Icon = null;
            signUpBttn.Location = new Point(276, 305);
            signUpBttn.Margin = new Padding(4, 6, 4, 6);
            signUpBttn.MouseState = MaterialSkin.MouseState.HOVER;
            signUpBttn.Name = "signUpBttn";
            signUpBttn.NoAccentTextColor = Color.Empty;
            signUpBttn.Size = new Size(66, 32);
            signUpBttn.TabIndex = 1;
            signUpBttn.Text = "Sign up";
            signUpBttn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            signUpBttn.UseAccentColor = false;
            signUpBttn.UseVisualStyleBackColor = true;
            signUpBttn.Click += signUpBttn_Click;
            // 
            // usernameLoginTbox
            // 
            usernameLoginTbox.AllowPromptAsInput = true;
            usernameLoginTbox.AnimateReadOnly = false;
            usernameLoginTbox.AsciiOnly = false;
            usernameLoginTbox.BackgroundImageLayout = ImageLayout.None;
            usernameLoginTbox.BeepOnError = true;
            usernameLoginTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            usernameLoginTbox.Depth = 0;
            usernameLoginTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            usernameLoginTbox.HidePromptOnLeave = false;
            usernameLoginTbox.HideSelection = true;
            usernameLoginTbox.Hint = "Username";
            usernameLoginTbox.InsertKeyMode = InsertKeyMode.Default;
            usernameLoginTbox.LeadingIcon = null;
            usernameLoginTbox.Location = new Point(59, 175);
            usernameLoginTbox.Mask = "";
            usernameLoginTbox.MaxLength = 32767;
            usernameLoginTbox.MouseState = MaterialSkin.MouseState.OUT;
            usernameLoginTbox.Name = "usernameLoginTbox";
            usernameLoginTbox.PasswordChar = '\0';
            usernameLoginTbox.PrefixSuffixText = "Username";
            usernameLoginTbox.PromptChar = '_';
            usernameLoginTbox.ReadOnly = false;
            usernameLoginTbox.RejectInputOnFirstFailure = false;
            usernameLoginTbox.ResetOnPrompt = true;
            usernameLoginTbox.ResetOnSpace = true;
            usernameLoginTbox.RightToLeft = RightToLeft.No;
            usernameLoginTbox.SelectedText = "";
            usernameLoginTbox.SelectionLength = 0;
            usernameLoginTbox.SelectionStart = 0;
            usernameLoginTbox.ShortcutsEnabled = true;
            usernameLoginTbox.ShowAssistiveText = true;
            usernameLoginTbox.Size = new Size(284, 64);
            usernameLoginTbox.SkipLiterals = true;
            usernameLoginTbox.TabIndex = 2;
            usernameLoginTbox.TabStop = false;
            usernameLoginTbox.TextAlign = HorizontalAlignment.Left;
            usernameLoginTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            usernameLoginTbox.TrailingIcon = null;
            usernameLoginTbox.UseSystemPasswordChar = false;
            usernameLoginTbox.ValidatingType = null;
            usernameLoginTbox.Click += InformationTbox_Click;
            usernameLoginTbox.KeyPress += UsernameTbox_KeyPress;
            usernameLoginTbox.TextChanged += InformationTbox_Click;
            // 
            // passwordLoginTbox
            // 
            passwordLoginTbox.AllowPromptAsInput = true;
            passwordLoginTbox.AnimateReadOnly = false;
            passwordLoginTbox.AsciiOnly = false;
            passwordLoginTbox.BackgroundImageLayout = ImageLayout.None;
            passwordLoginTbox.BeepOnError = true;
            passwordLoginTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            passwordLoginTbox.Depth = 0;
            passwordLoginTbox.ErrorMessage = "WRONG PASSWORD OR USERNAME!";
            passwordLoginTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            passwordLoginTbox.HidePromptOnLeave = false;
            passwordLoginTbox.HideSelection = true;
            passwordLoginTbox.Hint = "Password";
            passwordLoginTbox.InsertKeyMode = InsertKeyMode.Default;
            passwordLoginTbox.LeadingIcon = null;
            passwordLoginTbox.Location = new Point(58, 244);
            passwordLoginTbox.Mask = "";
            passwordLoginTbox.MaxLength = 32767;
            passwordLoginTbox.MouseState = MaterialSkin.MouseState.OUT;
            passwordLoginTbox.Name = "passwordLoginTbox";
            passwordLoginTbox.PasswordChar = '●';
            passwordLoginTbox.PrefixSuffixText = null;
            passwordLoginTbox.PromptChar = '_';
            passwordLoginTbox.ReadOnly = false;
            passwordLoginTbox.RejectInputOnFirstFailure = false;
            passwordLoginTbox.ResetOnPrompt = true;
            passwordLoginTbox.ResetOnSpace = true;
            passwordLoginTbox.RightToLeft = RightToLeft.No;
            passwordLoginTbox.SelectedText = "";
            passwordLoginTbox.SelectionLength = 0;
            passwordLoginTbox.SelectionStart = 0;
            passwordLoginTbox.ShortcutsEnabled = true;
            passwordLoginTbox.ShowAssistiveText = true;
            passwordLoginTbox.Size = new Size(284, 64);
            passwordLoginTbox.SkipLiterals = true;
            passwordLoginTbox.TabIndex = 3;
            passwordLoginTbox.TabStop = false;
            passwordLoginTbox.TextAlign = HorizontalAlignment.Left;
            passwordLoginTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            passwordLoginTbox.TrailingIcon = null;
            passwordLoginTbox.UseSystemPasswordChar = true;
            passwordLoginTbox.ValidatingType = null;
            passwordLoginTbox.Click += InformationTbox_Click;
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.FlatStyle = FlatStyle.Popup;
            bigLabel1.Font = new Font("Swis721 Blk BT", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.CornflowerBlue;
            bigLabel1.Location = new Point(59, 70);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(298, 40);
            bigLabel1.TabIndex = 4;
            bigLabel1.Text = "CIRCUIT CRAFT";
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(bigLabel1);
            loginPanel.Controls.Add(passwordLoginTbox);
            loginPanel.Controls.Add(usernameLoginTbox);
            loginPanel.Controls.Add(signUpBttn);
            loginPanel.Controls.Add(loginBttn);
            loginPanel.Location = new Point(0, 26);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(419, 553);
            loginPanel.TabIndex = 2;
            // 
            // LoginScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(419, 579);
            Controls.Add(airForm1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "LoginScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginScreen";
            TransparencyKey = Color.Fuchsia;
            Load += LoginScreenForm_Load;
            airForm1.ResumeLayout(false);
            signUpPanel.ResumeLayout(false);
            signUpPanel.PerformLayout();
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.AirForm airForm1;
        private Panel signUpPanel;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialMaskedTextBox confirmPasswordTbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private MaterialSkin.Controls.MaterialMaskedTextBox createPasswordTbox;
        private MaterialSkin.Controls.MaterialMaskedTextBox createUsernameTbox;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton backButton;
        private MaterialSkin.Controls.MaterialButton signUpButton;
        private Panel loginPanel;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox passwordLoginTbox;
        private MaterialSkin.Controls.MaterialMaskedTextBox usernameLoginTbox;
        private MaterialSkin.Controls.MaterialButton signUpBttn;
        private MaterialSkin.Controls.MaterialButton loginBttn;
    }
}