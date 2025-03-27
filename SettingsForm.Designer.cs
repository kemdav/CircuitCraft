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
            confirmBox = new Panel();
            confirmMessage = new MaterialSkin.Controls.MaterialLabel();
            confirmBoxYesButton = new MaterialSkin.Controls.MaterialButton();
            confirmBoxNoButton = new MaterialSkin.Controls.MaterialButton();
            materialTabControl2 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage3 = new TabPage();
            pictureBox4 = new PictureBox();
            bigLabel9 = new ReaLTaiizor.Controls.BigLabel();
            circuitsCompletedTxt = new ReaLTaiizor.Controls.BigLabel();
            pictureBox2 = new PictureBox();
            bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            ledsBurnedTxt = new ReaLTaiizor.Controls.BigLabel();
            resistorsBurnedTxt = new ReaLTaiizor.Controls.BigLabel();
            bigLabel7 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox3 = new PictureBox();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            ratingTxt = new ReaLTaiizor.Controls.BigLabel();
            pictureBox5 = new PictureBox();
            returnMainMenuButton = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            usernameTxt = new ReaLTaiizor.Controls.BigLabel();
            profilePbox = new PictureBox();
            resetButton = new MaterialSkin.Controls.MaterialButton();
            deleteButton = new MaterialSkin.Controls.MaterialButton();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            backgroundVideo = new LibVLCSharp.WinForms.VideoView();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            confirmBox.SuspendLayout();
            materialTabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profilePbox).BeginInit();
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
            materialTabControl1.Location = new Point(85, 60);
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
            tabPage2.Controls.Add(confirmBox);
            tabPage2.Controls.Add(materialTabControl2);
            tabPage2.Controls.Add(ratingTxt);
            tabPage2.Controls.Add(pictureBox5);
            tabPage2.Controls.Add(returnMainMenuButton);
            tabPage2.Controls.Add(materialButton1);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(usernameTxt);
            tabPage2.Controls.Add(profilePbox);
            tabPage2.Controls.Add(resetButton);
            tabPage2.Controls.Add(deleteButton);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1074, 610);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Account Settings";
            tabPage2.Click += tabPage2_Click;
            // 
            // confirmBox
            // 
            confirmBox.Controls.Add(confirmMessage);
            confirmBox.Controls.Add(confirmBoxYesButton);
            confirmBox.Controls.Add(confirmBoxNoButton);
            confirmBox.Location = new Point(664, 153);
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
            // 
            // materialTabControl2
            // 
            materialTabControl2.Controls.Add(tabPage3);
            materialTabControl2.Controls.Add(tabPage4);
            materialTabControl2.Controls.Add(tabPage5);
            materialTabControl2.Depth = 0;
            materialTabControl2.Location = new Point(-4, 217);
            materialTabControl2.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl2.Multiline = true;
            materialTabControl2.Name = "materialTabControl2";
            materialTabControl2.SelectedIndex = 0;
            materialTabControl2.Size = new Size(1078, 349);
            materialTabControl2.TabIndex = 20;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(pictureBox4);
            tabPage3.Controls.Add(bigLabel9);
            tabPage3.Controls.Add(circuitsCompletedTxt);
            tabPage3.Controls.Add(pictureBox2);
            tabPage3.Controls.Add(bigLabel4);
            tabPage3.Controls.Add(ledsBurnedTxt);
            tabPage3.Controls.Add(resistorsBurnedTxt);
            tabPage3.Controls.Add(bigLabel7);
            tabPage3.Controls.Add(pictureBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1070, 321);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Statistics";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(522, 30);
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
            bigLabel9.Location = new Point(653, 30);
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
            circuitsCompletedTxt.Location = new Point(653, 77);
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
            pictureBox2.Location = new Point(17, 30);
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
            bigLabel4.Location = new Point(148, 30);
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
            ledsBurnedTxt.Location = new Point(148, 202);
            ledsBurnedTxt.Name = "ledsBurnedTxt";
            ledsBurnedTxt.Size = new Size(38, 46);
            ledsBurnedTxt.TabIndex = 13;
            ledsBurnedTxt.Text = "0";
            // 
            // resistorsBurnedTxt
            // 
            resistorsBurnedTxt.Anchor = AnchorStyles.None;
            resistorsBurnedTxt.AutoSize = true;
            resistorsBurnedTxt.BackColor = Color.Transparent;
            resistorsBurnedTxt.Font = new Font("Segoe UI", 25F);
            resistorsBurnedTxt.ForeColor = Color.FromArgb(80, 80, 80);
            resistorsBurnedTxt.Location = new Point(148, 77);
            resistorsBurnedTxt.Name = "resistorsBurnedTxt";
            resistorsBurnedTxt.Size = new Size(38, 46);
            resistorsBurnedTxt.TabIndex = 10;
            resistorsBurnedTxt.Text = "0";
            // 
            // bigLabel7
            // 
            bigLabel7.Anchor = AnchorStyles.None;
            bigLabel7.AutoSize = true;
            bigLabel7.BackColor = Color.Transparent;
            bigLabel7.Font = new Font("Segoe UI", 25F);
            bigLabel7.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel7.Location = new Point(148, 155);
            bigLabel7.Name = "bigLabel7";
            bigLabel7.Size = new Size(232, 46);
            bigLabel7.TabIndex = 12;
            bigLabel7.Text = "LEDS BURNED";
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(17, 155);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(106, 93);
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1070, 321);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Change Username";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1070, 321);
            tabPage5.TabIndex = 2;
            tabPage5.Text = "Change Password";
            tabPage5.UseVisualStyleBackColor = true;
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
            // materialButton1
            // 
            materialButton1.Anchor = AnchorStyles.None;
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(17, 163);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(154, 36);
            materialButton1.TabIndex = 17;
            materialButton1.TabStop = false;
            materialButton1.Text = "CHANGE PROFILE";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 357);
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
            usernameTxt.Location = new Point(197, 35);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(376, 44);
            usernameTxt.TabIndex = 5;
            usernameTxt.Text = "USERNAME: GarlicButter";
            // 
            // profilePbox
            // 
            profilePbox.Anchor = AnchorStyles.None;
            profilePbox.BackgroundImage = Properties.Resources.Cat_kayden_pfp;
            profilePbox.BackgroundImageLayout = ImageLayout.Stretch;
            profilePbox.Location = new Point(17, 16);
            profilePbox.Name = "profilePbox";
            profilePbox.Size = new Size(154, 138);
            profilePbox.TabIndex = 4;
            profilePbox.TabStop = false;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.None;
            resetButton.AutoSize = false;
            resetButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resetButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            resetButton.Depth = 0;
            resetButton.HighEmphasis = true;
            resetButton.Icon = null;
            resetButton.Location = new Point(857, 48);
            resetButton.Margin = new Padding(4, 6, 4, 6);
            resetButton.MouseState = MaterialSkin.MouseState.HOVER;
            resetButton.Name = "resetButton";
            resetButton.NoAccentTextColor = Color.Empty;
            resetButton.Size = new Size(187, 36);
            resetButton.TabIndex = 2;
            resetButton.TabStop = false;
            resetButton.Text = "RESET ACCOUNT";
            resetButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            resetButton.UseAccentColor = false;
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
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
            deleteButton.Location = new Point(857, 96);
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
            Controls.Add(hopeForm1);
            Controls.Add(materialTabControl1);
            Controls.Add(backgroundVideo);
            Controls.Add(materialTabSelector1);
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
            confirmBox.ResumeLayout(false);
            confirmBox.PerformLayout();
            materialTabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)profilePbox).EndInit();
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
        private MaterialSkin.Controls.MaterialButton resetButton;
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
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private ReaLTaiizor.Controls.BigLabel ratingTxt;
        private PictureBox pictureBox5;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Panel confirmBox;
        private MaterialSkin.Controls.MaterialLabel confirmMessage;
        private MaterialSkin.Controls.MaterialButton confirmBoxYesButton;
        private MaterialSkin.Controls.MaterialButton confirmBoxNoButton;
    }
}