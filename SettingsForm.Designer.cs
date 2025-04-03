namespace CircuitCraft
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialButton6 = new MaterialSkin.Controls.MaterialButton();
            musicSlider = new MaterialSkin.Controls.MaterialSlider();
            mainMenuButton = new MaterialSkin.Controls.MaterialButton();
            soundSlider = new MaterialSkin.Controls.MaterialSlider();
            tabPage2 = new TabPage();
            accountSettingsPanel = new Panel();
            deleteButton = new MaterialSkin.Controls.MaterialButton();
            changePasswordButton = new MaterialSkin.Controls.MaterialButton();
            usernameTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            pictureBox4 = new PictureBox();
            bigLabel9 = new ReaLTaiizor.Controls.BigLabel();
            circuitsCompletedTxt = new ReaLTaiizor.Controls.BigLabel();
            pictureBox2 = new PictureBox();
            bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            ledsBurnedTxt = new ReaLTaiizor.Controls.BigLabel();
            ratingTxt = new ReaLTaiizor.Controls.BigLabel();
            resistorsBurnedTxt = new ReaLTaiizor.Controls.BigLabel();
            pictureBox5 = new PictureBox();
            bigLabel7 = new ReaLTaiizor.Controls.BigLabel();
            returnMainMenuButton = new MaterialSkin.Controls.MaterialButton();
            pictureBox3 = new PictureBox();
            changeProfilePicButton = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            usernameTxt = new ReaLTaiizor.Controls.BigLabel();
            profilePbox = new PictureBox();
            confirmBox = new Panel();
            confirmMessage = new MaterialSkin.Controls.MaterialLabel();
            confirmBoxYesButton = new MaterialSkin.Controls.MaterialButton();
            confirmBoxNoButton = new MaterialSkin.Controls.MaterialButton();
            changePasswordPanel = new Panel();
            changePasswordCurrentPasswordTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            changePasswordCancelButton = new MaterialSkin.Controls.MaterialButton();
            changePasswordConfirmButton = new MaterialSkin.Controls.MaterialButton();
            changePasswordConfirmPasswordTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            changePasswordCreatePasswordTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            backgroundVideo = new LibVLCSharp.WinForms.VideoView();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            accountSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profilePbox).BeginInit();
            confirmBox.SuspendLayout();
            changePasswordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backgroundVideo).BeginInit();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Anchor = AnchorStyles.None;
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.HotTrack = true;
            materialTabControl1.ImeMode = ImeMode.NoControl;
            materialTabControl1.ItemSize = new Size(88, 20);
            materialTabControl1.Location = new Point(85, 82);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.Padding = new Point(0, 0);
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1082, 638);
            materialTabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(materialButton6);
            tabPage1.Controls.Add(musicSlider);
            tabPage1.Controls.Add(mainMenuButton);
            tabPage1.Controls.Add(soundSlider);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1074, 610);
            tabPage1.TabIndex = 0;
            tabPage1.Text = " Game Settings";
            // 
            // materialButton6
            // 
            materialButton6.Anchor = AnchorStyles.None;
            materialButton6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton6.Depth = 0;
            materialButton6.HighEmphasis = true;
            materialButton6.Icon = null;
            materialButton6.Location = new Point(452, 565);
            materialButton6.Margin = new Padding(4, 6, 4, 6);
            materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton6.Name = "materialButton6";
            materialButton6.NoAccentTextColor = Color.Empty;
            materialButton6.Size = new Size(186, 36);
            materialButton6.TabIndex = 13;
            materialButton6.TabStop = false;
            materialButton6.Text = "RETURN TO MAIN MENU";
            materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton6.UseAccentColor = false;
            materialButton6.UseVisualStyleBackColor = true;
            materialButton6.Click += mainMenuButton_Click;
            // 
            // musicSlider
            // 
            musicSlider.Anchor = AnchorStyles.None;
            musicSlider.Depth = 0;
            musicSlider.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            musicSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            musicSlider.ForeColor = Color.FromArgb(222, 0, 0, 0);
            musicSlider.Location = new Point(190, 191);
            musicSlider.MouseState = MaterialSkin.MouseState.HOVER;
            musicSlider.Name = "musicSlider";
            musicSlider.Size = new Size(702, 40);
            musicSlider.TabIndex = 2;
            musicSlider.Text = "Music";
            // 
            // mainMenuButton
            // 
            mainMenuButton.Anchor = AnchorStyles.None;
            mainMenuButton.AutoSize = false;
            mainMenuButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainMenuButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mainMenuButton.Depth = 0;
            mainMenuButton.HighEmphasis = true;
            mainMenuButton.Icon = null;
            mainMenuButton.Location = new Point(513, 673);
            mainMenuButton.Margin = new Padding(4, 6, 4, 6);
            mainMenuButton.MouseState = MaterialSkin.MouseState.HOVER;
            mainMenuButton.Name = "mainMenuButton";
            mainMenuButton.NoAccentTextColor = Color.Empty;
            mainMenuButton.Size = new Size(702, 46);
            mainMenuButton.TabIndex = 6;
            mainMenuButton.Text = "Return to Main Menu";
            mainMenuButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mainMenuButton.UseAccentColor = false;
            mainMenuButton.UseVisualStyleBackColor = true;
            // 
            // soundSlider
            // 
            soundSlider.Anchor = AnchorStyles.None;
            soundSlider.Depth = 0;
            soundSlider.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            soundSlider.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            soundSlider.ForeColor = Color.FromArgb(222, 0, 0, 0);
            soundSlider.Location = new Point(190, 249);
            soundSlider.MouseState = MaterialSkin.MouseState.HOVER;
            soundSlider.Name = "soundSlider";
            soundSlider.Size = new Size(702, 40);
            soundSlider.TabIndex = 3;
            soundSlider.Text = "Sound";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(accountSettingsPanel);
            tabPage2.Controls.Add(usernameTextBox);
            tabPage2.Controls.Add(pictureBox4);
            tabPage2.Controls.Add(bigLabel9);
            tabPage2.Controls.Add(circuitsCompletedTxt);
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(bigLabel4);
            tabPage2.Controls.Add(ledsBurnedTxt);
            tabPage2.Controls.Add(ratingTxt);
            tabPage2.Controls.Add(resistorsBurnedTxt);
            tabPage2.Controls.Add(pictureBox5);
            tabPage2.Controls.Add(bigLabel7);
            tabPage2.Controls.Add(returnMainMenuButton);
            tabPage2.Controls.Add(pictureBox3);
            tabPage2.Controls.Add(changeProfilePicButton);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(usernameTxt);
            tabPage2.Controls.Add(profilePbox);
            tabPage2.Controls.Add(confirmBox);
            tabPage2.Controls.Add(changePasswordPanel);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1074, 610);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Account Settings";
            tabPage2.Click += tabPage2_Click;
            // 
            // accountSettingsPanel
            // 
            accountSettingsPanel.Controls.Add(deleteButton);
            accountSettingsPanel.Controls.Add(changePasswordButton);
            accountSettingsPanel.Location = new Point(839, 16);
            accountSettingsPanel.Name = "accountSettingsPanel";
            accountSettingsPanel.Size = new Size(200, 100);
            accountSettingsPanel.TabIndex = 25;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.None;
            deleteButton.AutoSize = false;
            deleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            deleteButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            deleteButton.Depth = 0;
            deleteButton.HighEmphasis = true;
            deleteButton.Icon = null;
            deleteButton.Location = new Point(4, 13);
            deleteButton.Margin = new Padding(4, 6, 4, 6);
            deleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            deleteButton.Name = "deleteButton";
            deleteButton.NoAccentTextColor = Color.Empty;
            deleteButton.Size = new Size(187, 36);
            deleteButton.TabIndex = 1;
            deleteButton.TabStop = false;
            deleteButton.Text = "DELETE ACCOUNT";
            deleteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            deleteButton.UseAccentColor = false;
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // changePasswordButton
            // 
            changePasswordButton.Anchor = AnchorStyles.None;
            changePasswordButton.AutoSize = false;
            changePasswordButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            changePasswordButton.Depth = 0;
            changePasswordButton.HighEmphasis = true;
            changePasswordButton.Icon = null;
            changePasswordButton.Location = new Point(4, 58);
            changePasswordButton.Margin = new Padding(4, 6, 4, 6);
            changePasswordButton.MouseState = MaterialSkin.MouseState.HOVER;
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.NoAccentTextColor = Color.Empty;
            changePasswordButton.Size = new Size(187, 36);
            changePasswordButton.TabIndex = 5;
            changePasswordButton.TabStop = false;
            changePasswordButton.Text = "CHANGE PASSWORD";
            changePasswordButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            changePasswordButton.UseAccentColor = false;
            changePasswordButton.UseVisualStyleBackColor = true;
            changePasswordButton.Click += changePasswordButton_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.AllowPromptAsInput = true;
            usernameTextBox.AnimateReadOnly = false;
            usernameTextBox.AsciiOnly = false;
            usernameTextBox.BackgroundImageLayout = ImageLayout.None;
            usernameTextBox.BeepOnError = false;
            usernameTextBox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            usernameTextBox.Depth = 0;
            usernameTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            usernameTextBox.HidePromptOnLeave = false;
            usernameTextBox.HideSelection = true;
            usernameTextBox.InsertKeyMode = InsertKeyMode.Default;
            usernameTextBox.LeadingIcon = null;
            usernameTextBox.Location = new Point(393, 18);
            usernameTextBox.Mask = "";
            usernameTextBox.MaxLength = 32767;
            usernameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PasswordChar = '\0';
            usernameTextBox.PrefixSuffixText = null;
            usernameTextBox.PromptChar = '_';
            usernameTextBox.ReadOnly = false;
            usernameTextBox.RejectInputOnFirstFailure = false;
            usernameTextBox.ResetOnPrompt = true;
            usernameTextBox.ResetOnSpace = true;
            usernameTextBox.RightToLeft = RightToLeft.No;
            usernameTextBox.SelectedText = "";
            usernameTextBox.SelectionLength = 0;
            usernameTextBox.SelectionStart = 0;
            usernameTextBox.ShortcutsEnabled = true;
            usernameTextBox.ShowAssistiveText = true;
            usernameTextBox.Size = new Size(250, 64);
            usernameTextBox.SkipLiterals = true;
            usernameTextBox.TabIndex = 23;
            usernameTextBox.TabStop = false;
            usernameTextBox.TextAlign = HorizontalAlignment.Left;
            usernameTextBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            usernameTextBox.TrailingIcon = null;
            usernameTextBox.UseSystemPasswordChar = false;
            usernameTextBox.ValidatingType = null;
            usernameTextBox.KeyPress += usernameTextBox_KeyPress;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(553, 312);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(106, 93);
            pictureBox4.TabIndex = 14;
            pictureBox4.TabStop = false;
            // 
            // bigLabel9
            // 
            bigLabel9.Anchor = AnchorStyles.None;
            bigLabel9.AutoSize = true;
            bigLabel9.BackColor = Color.Transparent;
            bigLabel9.Font = new Font("Segoe UI", 25F);
            bigLabel9.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel9.Location = new Point(684, 312);
            bigLabel9.Name = "bigLabel9";
            bigLabel9.Size = new Size(355, 46);
            bigLabel9.TabIndex = 15;
            bigLabel9.Text = "CIRCUITS COMPLETED";
            // 
            // circuitsCompletedTxt
            // 
            circuitsCompletedTxt.Anchor = AnchorStyles.None;
            circuitsCompletedTxt.AutoSize = true;
            circuitsCompletedTxt.BackColor = Color.Transparent;
            circuitsCompletedTxt.Font = new Font("Segoe UI", 25F);
            circuitsCompletedTxt.ForeColor = Color.FromArgb(80, 80, 80);
            circuitsCompletedTxt.Location = new Point(684, 359);
            circuitsCompletedTxt.Name = "circuitsCompletedTxt";
            circuitsCompletedTxt.Size = new Size(38, 46);
            circuitsCompletedTxt.TabIndex = 16;
            circuitsCompletedTxt.Text = "0";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(48, 312);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(106, 93);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // bigLabel4
            // 
            bigLabel4.Anchor = AnchorStyles.None;
            bigLabel4.AutoSize = true;
            bigLabel4.BackColor = Color.Transparent;
            bigLabel4.Font = new Font("Segoe UI", 25F);
            bigLabel4.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel4.Location = new Point(179, 312);
            bigLabel4.Name = "bigLabel4";
            bigLabel4.Size = new Size(319, 46);
            bigLabel4.TabIndex = 9;
            bigLabel4.Text = "RESISTORS BURNED";
            // 
            // ledsBurnedTxt
            // 
            ledsBurnedTxt.Anchor = AnchorStyles.None;
            ledsBurnedTxt.AutoSize = true;
            ledsBurnedTxt.BackColor = Color.Transparent;
            ledsBurnedTxt.Font = new Font("Segoe UI", 25F);
            ledsBurnedTxt.ForeColor = Color.FromArgb(80, 80, 80);
            ledsBurnedTxt.Location = new Point(179, 484);
            ledsBurnedTxt.Name = "ledsBurnedTxt";
            ledsBurnedTxt.Size = new Size(38, 46);
            ledsBurnedTxt.TabIndex = 13;
            ledsBurnedTxt.Text = "0";
            // 
            // ratingTxt
            // 
            ratingTxt.Anchor = AnchorStyles.None;
            ratingTxt.AutoSize = true;
            ratingTxt.BackColor = Color.Transparent;
            ratingTxt.Font = new Font("Segoe UI", 25F);
            ratingTxt.ForeColor = Color.FromArgb(80, 80, 80);
            ratingTxt.Location = new Point(261, 85);
            ratingTxt.Name = "ratingTxt";
            ratingTxt.Size = new Size(205, 46);
            ratingTxt.TabIndex = 19;
            ratingTxt.Text = "RATING: 483";
            // 
            // resistorsBurnedTxt
            // 
            resistorsBurnedTxt.Anchor = AnchorStyles.None;
            resistorsBurnedTxt.AutoSize = true;
            resistorsBurnedTxt.BackColor = Color.Transparent;
            resistorsBurnedTxt.Font = new Font("Segoe UI", 25F);
            resistorsBurnedTxt.ForeColor = Color.FromArgb(80, 80, 80);
            resistorsBurnedTxt.Location = new Point(179, 359);
            resistorsBurnedTxt.Name = "resistorsBurnedTxt";
            resistorsBurnedTxt.Size = new Size(38, 46);
            resistorsBurnedTxt.TabIndex = 10;
            resistorsBurnedTxt.Text = "0";
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.None;
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(197, 82);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(58, 48);
            pictureBox5.TabIndex = 18;
            pictureBox5.TabStop = false;
            // 
            // bigLabel7
            // 
            bigLabel7.Anchor = AnchorStyles.None;
            bigLabel7.AutoSize = true;
            bigLabel7.BackColor = Color.Transparent;
            bigLabel7.Font = new Font("Segoe UI", 25F);
            bigLabel7.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel7.Location = new Point(179, 437);
            bigLabel7.Name = "bigLabel7";
            bigLabel7.Size = new Size(232, 46);
            bigLabel7.TabIndex = 12;
            bigLabel7.Text = "LEDS BURNED";
            // 
            // returnMainMenuButton
            // 
            returnMainMenuButton.Anchor = AnchorStyles.None;
            returnMainMenuButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            returnMainMenuButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            returnMainMenuButton.Depth = 0;
            returnMainMenuButton.HighEmphasis = true;
            returnMainMenuButton.Icon = null;
            returnMainMenuButton.Location = new Point(442, 571);
            returnMainMenuButton.Margin = new Padding(4, 6, 4, 6);
            returnMainMenuButton.MouseState = MaterialSkin.MouseState.HOVER;
            returnMainMenuButton.Name = "returnMainMenuButton";
            returnMainMenuButton.NoAccentTextColor = Color.Empty;
            returnMainMenuButton.Size = new Size(186, 36);
            returnMainMenuButton.TabIndex = 10;
            returnMainMenuButton.TabStop = false;
            returnMainMenuButton.Text = "RETURN TO MAIN MENU";
            returnMainMenuButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            returnMainMenuButton.UseAccentColor = false;
            returnMainMenuButton.UseVisualStyleBackColor = true;
            returnMainMenuButton.Click += mainMenuButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(48, 437);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(106, 93);
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // changeProfilePicButton
            // 
            changeProfilePicButton.Anchor = AnchorStyles.None;
            changeProfilePicButton.AutoSize = false;
            changeProfilePicButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changeProfilePicButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            changeProfilePicButton.Depth = 0;
            changeProfilePicButton.HighEmphasis = true;
            changeProfilePicButton.Icon = null;
            changeProfilePicButton.Location = new Point(17, 163);
            changeProfilePicButton.Margin = new Padding(4, 6, 4, 6);
            changeProfilePicButton.MouseState = MaterialSkin.MouseState.HOVER;
            changeProfilePicButton.Name = "changeProfilePicButton";
            changeProfilePicButton.NoAccentTextColor = Color.Empty;
            changeProfilePicButton.Size = new Size(154, 36);
            changeProfilePicButton.TabIndex = 17;
            changeProfilePicButton.TabStop = false;
            changeProfilePicButton.Text = "CHANGE PROFILE";
            changeProfilePicButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            changeProfilePicButton.UseAccentColor = false;
            changeProfilePicButton.UseVisualStyleBackColor = true;
            changeProfilePicButton.Click += changeProfilePicButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 451);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 8;
            // 
            // usernameTxt
            // 
            usernameTxt.Anchor = AnchorStyles.None;
            usernameTxt.AutoSize = true;
            usernameTxt.BackColor = Color.Transparent;
            usernameTxt.Font = new Font("Segoe UI Emoji", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTxt.ForeColor = Color.FromArgb(80, 80, 80);
            usernameTxt.Location = new Point(181, 18);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(206, 44);
            usernameTxt.TabIndex = 5;
            usernameTxt.Text = "USERNAME: ";
            // 
            // profilePbox
            // 
            profilePbox.Anchor = AnchorStyles.None;
            profilePbox.BackgroundImageLayout = ImageLayout.Stretch;
            profilePbox.Location = new Point(17, 16);
            profilePbox.Name = "profilePbox";
            profilePbox.Size = new Size(154, 138);
            profilePbox.TabIndex = 4;
            profilePbox.TabStop = false;
            // 
            // confirmBox
            // 
            confirmBox.Controls.Add(confirmMessage);
            confirmBox.Controls.Add(confirmBoxYesButton);
            confirmBox.Controls.Add(confirmBoxNoButton);
            confirmBox.Location = new Point(668, 12);
            confirmBox.Name = "confirmBox";
            confirmBox.Size = new Size(380, 70);
            confirmBox.TabIndex = 22;
            // 
            // confirmMessage
            // 
            confirmMessage.AutoSize = true;
            confirmMessage.Depth = 0;
            confirmMessage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            confirmMessage.Location = new Point(4, 6);
            confirmMessage.MouseState = MaterialSkin.MouseState.HOVER;
            confirmMessage.Name = "confirmMessage";
            confirmMessage.Size = new Size(317, 19);
            confirmMessage.TabIndex = 5;
            confirmMessage.Text = "Are you sure you want to reset your account?";
            // 
            // confirmBoxYesButton
            // 
            confirmBoxYesButton.Anchor = AnchorStyles.None;
            confirmBoxYesButton.AutoSize = false;
            confirmBoxYesButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            confirmBoxYesButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            confirmBoxYesButton.Depth = 0;
            confirmBoxYesButton.HighEmphasis = true;
            confirmBoxYesButton.Icon = null;
            confirmBoxYesButton.Location = new Point(4, 28);
            confirmBoxYesButton.Margin = new Padding(4, 6, 4, 6);
            confirmBoxYesButton.MouseState = MaterialSkin.MouseState.HOVER;
            confirmBoxYesButton.Name = "confirmBoxYesButton";
            confirmBoxYesButton.NoAccentTextColor = Color.Empty;
            confirmBoxYesButton.Size = new Size(187, 36);
            confirmBoxYesButton.TabIndex = 4;
            confirmBoxYesButton.TabStop = false;
            confirmBoxYesButton.Text = "YES";
            confirmBoxYesButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            confirmBoxYesButton.UseAccentColor = false;
            confirmBoxYesButton.UseVisualStyleBackColor = true;
            confirmBoxYesButton.Click += confirmBoxYesButton_Click;
            // 
            // confirmBoxNoButton
            // 
            confirmBoxNoButton.Anchor = AnchorStyles.None;
            confirmBoxNoButton.AutoSize = false;
            confirmBoxNoButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            confirmBoxNoButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            confirmBoxNoButton.Depth = 0;
            confirmBoxNoButton.HighEmphasis = true;
            confirmBoxNoButton.Icon = null;
            confirmBoxNoButton.Location = new Point(189, 28);
            confirmBoxNoButton.Margin = new Padding(4, 6, 4, 6);
            confirmBoxNoButton.MouseState = MaterialSkin.MouseState.HOVER;
            confirmBoxNoButton.Name = "confirmBoxNoButton";
            confirmBoxNoButton.NoAccentTextColor = Color.Empty;
            confirmBoxNoButton.Size = new Size(187, 36);
            confirmBoxNoButton.TabIndex = 3;
            confirmBoxNoButton.TabStop = false;
            confirmBoxNoButton.Text = "NO";
            confirmBoxNoButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            confirmBoxNoButton.UseAccentColor = false;
            confirmBoxNoButton.UseVisualStyleBackColor = true;
            confirmBoxNoButton.Click += confirmBoxNoButton_Click;
            // 
            // changePasswordPanel
            // 
            changePasswordPanel.Controls.Add(changePasswordCurrentPasswordTbox);
            changePasswordPanel.Controls.Add(changePasswordCancelButton);
            changePasswordPanel.Controls.Add(changePasswordConfirmButton);
            changePasswordPanel.Controls.Add(changePasswordConfirmPasswordTbox);
            changePasswordPanel.Controls.Add(changePasswordCreatePasswordTbox);
            changePasswordPanel.Location = new Point(649, 16);
            changePasswordPanel.Name = "changePasswordPanel";
            changePasswordPanel.Size = new Size(416, 283);
            changePasswordPanel.TabIndex = 24;
            // 
            // changePasswordCurrentPasswordTbox
            // 
            changePasswordCurrentPasswordTbox.AllowPromptAsInput = true;
            changePasswordCurrentPasswordTbox.AnimateReadOnly = false;
            changePasswordCurrentPasswordTbox.AsciiOnly = false;
            changePasswordCurrentPasswordTbox.BackgroundImageLayout = ImageLayout.None;
            changePasswordCurrentPasswordTbox.BeepOnError = false;
            changePasswordCurrentPasswordTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            changePasswordCurrentPasswordTbox.Depth = 0;
            changePasswordCurrentPasswordTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            changePasswordCurrentPasswordTbox.HidePromptOnLeave = false;
            changePasswordCurrentPasswordTbox.HideSelection = true;
            changePasswordCurrentPasswordTbox.Hint = "Current Password";
            changePasswordCurrentPasswordTbox.InsertKeyMode = InsertKeyMode.Default;
            changePasswordCurrentPasswordTbox.LeadingIcon = null;
            changePasswordCurrentPasswordTbox.Location = new Point(19, 3);
            changePasswordCurrentPasswordTbox.Mask = "";
            changePasswordCurrentPasswordTbox.MaxLength = 32767;
            changePasswordCurrentPasswordTbox.MouseState = MaterialSkin.MouseState.OUT;
            changePasswordCurrentPasswordTbox.Name = "changePasswordCurrentPasswordTbox";
            changePasswordCurrentPasswordTbox.PasswordChar = '\0';
            changePasswordCurrentPasswordTbox.PrefixSuffixText = null;
            changePasswordCurrentPasswordTbox.PromptChar = '_';
            changePasswordCurrentPasswordTbox.ReadOnly = false;
            changePasswordCurrentPasswordTbox.RejectInputOnFirstFailure = false;
            changePasswordCurrentPasswordTbox.ResetOnPrompt = true;
            changePasswordCurrentPasswordTbox.ResetOnSpace = true;
            changePasswordCurrentPasswordTbox.RightToLeft = RightToLeft.No;
            changePasswordCurrentPasswordTbox.SelectedText = "";
            changePasswordCurrentPasswordTbox.SelectionLength = 0;
            changePasswordCurrentPasswordTbox.SelectionStart = 0;
            changePasswordCurrentPasswordTbox.ShortcutsEnabled = true;
            changePasswordCurrentPasswordTbox.ShowAssistiveText = true;
            changePasswordCurrentPasswordTbox.Size = new Size(382, 64);
            changePasswordCurrentPasswordTbox.SkipLiterals = true;
            changePasswordCurrentPasswordTbox.TabIndex = 7;
            changePasswordCurrentPasswordTbox.TabStop = false;
            changePasswordCurrentPasswordTbox.TextAlign = HorizontalAlignment.Left;
            changePasswordCurrentPasswordTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            changePasswordCurrentPasswordTbox.TrailingIcon = null;
            changePasswordCurrentPasswordTbox.UseSystemPasswordChar = false;
            changePasswordCurrentPasswordTbox.ValidatingType = null;
            changePasswordCurrentPasswordTbox.Enter += AccountTbox_Click;
            // 
            // changePasswordCancelButton
            // 
            changePasswordCancelButton.Anchor = AnchorStyles.None;
            changePasswordCancelButton.AutoSize = false;
            changePasswordCancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordCancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            changePasswordCancelButton.Depth = 0;
            changePasswordCancelButton.HighEmphasis = true;
            changePasswordCancelButton.Icon = null;
            changePasswordCancelButton.Location = new Point(214, 220);
            changePasswordCancelButton.Margin = new Padding(4, 6, 4, 6);
            changePasswordCancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            changePasswordCancelButton.Name = "changePasswordCancelButton";
            changePasswordCancelButton.NoAccentTextColor = Color.Empty;
            changePasswordCancelButton.Size = new Size(187, 36);
            changePasswordCancelButton.TabIndex = 6;
            changePasswordCancelButton.TabStop = false;
            changePasswordCancelButton.Text = "CANCEL";
            changePasswordCancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            changePasswordCancelButton.UseAccentColor = false;
            changePasswordCancelButton.UseVisualStyleBackColor = true;
            changePasswordCancelButton.Click += changePasswordCancelButton_Click;
            // 
            // changePasswordConfirmButton
            // 
            changePasswordConfirmButton.Anchor = AnchorStyles.None;
            changePasswordConfirmButton.AutoSize = false;
            changePasswordConfirmButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            changePasswordConfirmButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            changePasswordConfirmButton.Depth = 0;
            changePasswordConfirmButton.HighEmphasis = true;
            changePasswordConfirmButton.Icon = null;
            changePasswordConfirmButton.Location = new Point(19, 220);
            changePasswordConfirmButton.Margin = new Padding(4, 6, 4, 6);
            changePasswordConfirmButton.MouseState = MaterialSkin.MouseState.HOVER;
            changePasswordConfirmButton.Name = "changePasswordConfirmButton";
            changePasswordConfirmButton.NoAccentTextColor = Color.Empty;
            changePasswordConfirmButton.Size = new Size(187, 36);
            changePasswordConfirmButton.TabIndex = 5;
            changePasswordConfirmButton.TabStop = false;
            changePasswordConfirmButton.Text = "CHANGE PASSWORD";
            changePasswordConfirmButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            changePasswordConfirmButton.UseAccentColor = false;
            changePasswordConfirmButton.UseVisualStyleBackColor = true;
            changePasswordConfirmButton.Click += changePasswordConfirmButton_Click;
            // 
            // changePasswordConfirmPasswordTbox
            // 
            changePasswordConfirmPasswordTbox.AllowPromptAsInput = true;
            changePasswordConfirmPasswordTbox.AnimateReadOnly = false;
            changePasswordConfirmPasswordTbox.AsciiOnly = false;
            changePasswordConfirmPasswordTbox.BackgroundImageLayout = ImageLayout.None;
            changePasswordConfirmPasswordTbox.BeepOnError = false;
            changePasswordConfirmPasswordTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            changePasswordConfirmPasswordTbox.Depth = 0;
            changePasswordConfirmPasswordTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            changePasswordConfirmPasswordTbox.HidePromptOnLeave = false;
            changePasswordConfirmPasswordTbox.HideSelection = true;
            changePasswordConfirmPasswordTbox.Hint = "Confirm New Password";
            changePasswordConfirmPasswordTbox.InsertKeyMode = InsertKeyMode.Default;
            changePasswordConfirmPasswordTbox.LeadingIcon = null;
            changePasswordConfirmPasswordTbox.Location = new Point(19, 135);
            changePasswordConfirmPasswordTbox.Mask = "";
            changePasswordConfirmPasswordTbox.MaxLength = 32767;
            changePasswordConfirmPasswordTbox.MouseState = MaterialSkin.MouseState.OUT;
            changePasswordConfirmPasswordTbox.Name = "changePasswordConfirmPasswordTbox";
            changePasswordConfirmPasswordTbox.PasswordChar = '\0';
            changePasswordConfirmPasswordTbox.PrefixSuffixText = null;
            changePasswordConfirmPasswordTbox.PromptChar = '_';
            changePasswordConfirmPasswordTbox.ReadOnly = false;
            changePasswordConfirmPasswordTbox.RejectInputOnFirstFailure = false;
            changePasswordConfirmPasswordTbox.ResetOnPrompt = true;
            changePasswordConfirmPasswordTbox.ResetOnSpace = true;
            changePasswordConfirmPasswordTbox.RightToLeft = RightToLeft.No;
            changePasswordConfirmPasswordTbox.SelectedText = "";
            changePasswordConfirmPasswordTbox.SelectionLength = 0;
            changePasswordConfirmPasswordTbox.SelectionStart = 0;
            changePasswordConfirmPasswordTbox.ShortcutsEnabled = true;
            changePasswordConfirmPasswordTbox.ShowAssistiveText = true;
            changePasswordConfirmPasswordTbox.Size = new Size(382, 64);
            changePasswordConfirmPasswordTbox.SkipLiterals = true;
            changePasswordConfirmPasswordTbox.TabIndex = 1;
            changePasswordConfirmPasswordTbox.TabStop = false;
            changePasswordConfirmPasswordTbox.TextAlign = HorizontalAlignment.Left;
            changePasswordConfirmPasswordTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            changePasswordConfirmPasswordTbox.TrailingIcon = null;
            changePasswordConfirmPasswordTbox.UseSystemPasswordChar = false;
            changePasswordConfirmPasswordTbox.ValidatingType = null;
            changePasswordConfirmPasswordTbox.Enter += AccountTbox_Click;
            // 
            // changePasswordCreatePasswordTbox
            // 
            changePasswordCreatePasswordTbox.AllowPromptAsInput = true;
            changePasswordCreatePasswordTbox.AnimateReadOnly = false;
            changePasswordCreatePasswordTbox.AsciiOnly = false;
            changePasswordCreatePasswordTbox.BackgroundImageLayout = ImageLayout.None;
            changePasswordCreatePasswordTbox.BeepOnError = false;
            changePasswordCreatePasswordTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            changePasswordCreatePasswordTbox.Depth = 0;
            changePasswordCreatePasswordTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            changePasswordCreatePasswordTbox.HidePromptOnLeave = false;
            changePasswordCreatePasswordTbox.HideSelection = true;
            changePasswordCreatePasswordTbox.Hint = "New Password";
            changePasswordCreatePasswordTbox.InsertKeyMode = InsertKeyMode.Default;
            changePasswordCreatePasswordTbox.LeadingIcon = null;
            changePasswordCreatePasswordTbox.Location = new Point(19, 86);
            changePasswordCreatePasswordTbox.Mask = "";
            changePasswordCreatePasswordTbox.MaxLength = 32767;
            changePasswordCreatePasswordTbox.MouseState = MaterialSkin.MouseState.OUT;
            changePasswordCreatePasswordTbox.Name = "changePasswordCreatePasswordTbox";
            changePasswordCreatePasswordTbox.PasswordChar = '\0';
            changePasswordCreatePasswordTbox.PrefixSuffixText = null;
            changePasswordCreatePasswordTbox.PromptChar = '_';
            changePasswordCreatePasswordTbox.ReadOnly = false;
            changePasswordCreatePasswordTbox.RejectInputOnFirstFailure = false;
            changePasswordCreatePasswordTbox.ResetOnPrompt = true;
            changePasswordCreatePasswordTbox.ResetOnSpace = true;
            changePasswordCreatePasswordTbox.RightToLeft = RightToLeft.No;
            changePasswordCreatePasswordTbox.SelectedText = "";
            changePasswordCreatePasswordTbox.SelectionLength = 0;
            changePasswordCreatePasswordTbox.SelectionStart = 0;
            changePasswordCreatePasswordTbox.ShortcutsEnabled = true;
            changePasswordCreatePasswordTbox.ShowAssistiveText = true;
            changePasswordCreatePasswordTbox.Size = new Size(382, 64);
            changePasswordCreatePasswordTbox.SkipLiterals = true;
            changePasswordCreatePasswordTbox.TabIndex = 0;
            changePasswordCreatePasswordTbox.TabStop = false;
            changePasswordCreatePasswordTbox.TextAlign = HorizontalAlignment.Left;
            changePasswordCreatePasswordTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            changePasswordCreatePasswordTbox.TrailingIcon = null;
            changePasswordCreatePasswordTbox.UseSystemPasswordChar = false;
            changePasswordCreatePasswordTbox.ValidatingType = null;
            changePasswordCreatePasswordTbox.Enter += AccountTbox_Click;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.Anchor = AnchorStyles.None;
            materialTabSelector1.BackgroundImageLayout = ImageLayout.Center;
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Upper;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(85, 46);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(1082, 48);
            materialTabSelector1.TabIndex = 9;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // hopeForm1
            // 
            hopeForm1.ControlBoxColorH = Color.FromArgb(228, 231, 237);
            hopeForm1.ControlBoxColorHC = Color.FromArgb(245, 108, 108);
            hopeForm1.ControlBoxColorN = Color.White;
            hopeForm1.Dock = DockStyle.Top;
            hopeForm1.Font = new Font("Segoe UI", 12F);
            hopeForm1.ForeColor = Color.FromArgb(242, 246, 252);
            hopeForm1.Image = null;
            hopeForm1.Location = new Point(0, 0);
            hopeForm1.Name = "hopeForm1";
            hopeForm1.Size = new Size(1280, 40);
            hopeForm1.TabIndex = 11;
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // backgroundVideo
            // 
            backgroundVideo.BackColor = Color.Black;
            backgroundVideo.Dock = DockStyle.Fill;
            backgroundVideo.Location = new Point(0, 0);
            backgroundVideo.MediaPlayer = null;
            backgroundVideo.Name = "backgroundVideo";
            backgroundVideo.Size = new Size(1280, 720);
            backgroundVideo.TabIndex = 12;
            backgroundVideo.Text = "videoView1";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1280, 720);
            Controls.Add(materialTabSelector1);
            Controls.Add(hopeForm1);
            Controls.Add(materialTabControl1);
            Controls.Add(backgroundVideo);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            accountSettingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)profilePbox).EndInit();
            confirmBox.ResumeLayout(false);
            confirmBox.PerformLayout();
            changePasswordPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)backgroundVideo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialSlider musicSlider;
        private MaterialSkin.Controls.MaterialButton mainMenuButton;
        private MaterialSkin.Controls.MaterialSlider soundSlider;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialButton returnMainMenuButton;
        private TabPage tabPage2;
        private PictureBox profilePbox;
        private MaterialSkin.Controls.MaterialButton deleteButton;
        private ReaLTaiizor.Controls.BigLabel usernameTxt;
        private ReaLTaiizor.Controls.BigLabel bigLabel4;
        private Label label1;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.BigLabel resistorsBurnedTxt;
        private ReaLTaiizor.Controls.BigLabel ledsBurnedTxt;
        private ReaLTaiizor.Controls.BigLabel bigLabel7;
        private PictureBox pictureBox3;
        private ReaLTaiizor.Controls.BigLabel circuitsCompletedTxt;
        private ReaLTaiizor.Controls.BigLabel bigLabel9;
        private PictureBox pictureBox4;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private LibVLCSharp.WinForms.VideoView backgroundVideo;
        private MaterialSkin.Controls.MaterialButton changeProfilePicButton;
        private ReaLTaiizor.Controls.BigLabel ratingTxt;
        private PictureBox pictureBox5;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private Panel confirmBox;
        private MaterialSkin.Controls.MaterialLabel confirmMessage;
        private MaterialSkin.Controls.MaterialButton confirmBoxYesButton;
        private MaterialSkin.Controls.MaterialButton confirmBoxNoButton;
        private MaterialSkin.Controls.MaterialButton changePasswordButton;
        private MaterialSkin.Controls.MaterialMaskedTextBox usernameTextBox;
        private Panel accountSettingsPanel;
        private Panel changePasswordPanel;
        private MaterialSkin.Controls.MaterialMaskedTextBox changePasswordCurrentPasswordTbox;
        private MaterialSkin.Controls.MaterialButton changePasswordCancelButton;
        private MaterialSkin.Controls.MaterialButton changePasswordConfirmButton;
        private MaterialSkin.Controls.MaterialMaskedTextBox changePasswordConfirmPasswordTbox;
        private MaterialSkin.Controls.MaterialMaskedTextBox changePasswordCreatePasswordTbox;
    }
}