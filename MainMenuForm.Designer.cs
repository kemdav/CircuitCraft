namespace CircuitCraft
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            mainMenuBackgroundMedia = new LibVLCSharp.WinForms.VideoView();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            versionLABEL = new MaterialSkin.Controls.MaterialLabel();
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            pictureBox1 = new PictureBox();
            logoutButton = new MaterialSkin.Controls.MaterialButton();
            settingsButton = new MaterialSkin.Controls.MaterialButton();
            leaderboardButton = new MaterialSkin.Controls.MaterialButton();
            tutorialButton = new MaterialSkin.Controls.MaterialButton();
            playButton = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)mainMenuBackgroundMedia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuBackgroundMedia
            // 
            mainMenuBackgroundMedia.BackColor = Color.Black;
            mainMenuBackgroundMedia.Dock = DockStyle.Fill;
            mainMenuBackgroundMedia.Location = new Point(0, 0);
            mainMenuBackgroundMedia.MediaPlayer = null;
            mainMenuBackgroundMedia.Name = "mainMenuBackgroundMedia";
            mainMenuBackgroundMedia.Size = new Size(1280, 720);
            mainMenuBackgroundMedia.TabIndex = 23;
            mainMenuBackgroundMedia.Text = "videoView1";
            // 
            // bigLabel1
            // 
            bigLabel1.Anchor = AnchorStyles.None;
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.WhiteSmoke;
            bigLabel1.FlatStyle = FlatStyle.Popup;
            bigLabel1.Font = new Font("Swis721 Blk BT", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.CornflowerBlue;
            bigLabel1.Location = new Point(474, 119);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(298, 40);
            bigLabel1.TabIndex = 30;
            bigLabel1.Text = "CIRCUIT CRAFT";
            // 
            // versionLABEL
            // 
            versionLABEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            versionLABEL.AutoSize = true;
            versionLABEL.BackColor = Color.Transparent;
            versionLABEL.Depth = 0;
            versionLABEL.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            versionLABEL.Location = new Point(1177, 682);
            versionLABEL.MouseState = MaterialSkin.MouseState.HOVER;
            versionLABEL.Name = "versionLABEL";
            versionLABEL.Size = new Size(74, 19);
            versionLABEL.TabIndex = 29;
            versionLABEL.Text = "v0.1 BETA";
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
            hopeForm1.TabIndex = 31;
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(204, 271);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // logoutButton
            // 
            logoutButton.Anchor = AnchorStyles.None;
            logoutButton.AutoSize = false;
            logoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            logoutButton.Depth = 0;
            logoutButton.HighEmphasis = true;
            logoutButton.Icon = null;
            logoutButton.Location = new Point(26, 220);
            logoutButton.Margin = new Padding(4, 6, 4, 6);
            logoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            logoutButton.Name = "logoutButton";
            logoutButton.NoAccentTextColor = Color.Empty;
            logoutButton.Size = new Size(158, 36);
            logoutButton.TabIndex = 37;
            logoutButton.Text = "Logout";
            logoutButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            logoutButton.UseAccentColor = false;
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Anchor = AnchorStyles.None;
            settingsButton.AutoSize = false;
            settingsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            settingsButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            settingsButton.Depth = 0;
            settingsButton.HighEmphasis = true;
            settingsButton.Icon = null;
            settingsButton.Location = new Point(26, 172);
            settingsButton.Margin = new Padding(4, 6, 4, 6);
            settingsButton.MouseState = MaterialSkin.MouseState.HOVER;
            settingsButton.Name = "settingsButton";
            settingsButton.NoAccentTextColor = Color.Empty;
            settingsButton.Size = new Size(158, 36);
            settingsButton.TabIndex = 36;
            settingsButton.Text = "Settings";
            settingsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            settingsButton.UseAccentColor = false;
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // leaderboardButton
            // 
            leaderboardButton.Anchor = AnchorStyles.None;
            leaderboardButton.AutoSize = false;
            leaderboardButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            leaderboardButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            leaderboardButton.Depth = 0;
            leaderboardButton.HighEmphasis = true;
            leaderboardButton.Icon = null;
            leaderboardButton.Location = new Point(26, 124);
            leaderboardButton.Margin = new Padding(4, 6, 4, 6);
            leaderboardButton.MouseState = MaterialSkin.MouseState.HOVER;
            leaderboardButton.Name = "leaderboardButton";
            leaderboardButton.NoAccentTextColor = Color.Empty;
            leaderboardButton.Size = new Size(158, 36);
            leaderboardButton.TabIndex = 35;
            leaderboardButton.Text = "Leaderboard";
            leaderboardButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            leaderboardButton.UseAccentColor = false;
            leaderboardButton.UseVisualStyleBackColor = true;
            leaderboardButton.Click += leaderboardButton_Click;
            // 
            // tutorialButton
            // 
            tutorialButton.Anchor = AnchorStyles.None;
            tutorialButton.AutoSize = false;
            tutorialButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tutorialButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            tutorialButton.Depth = 0;
            tutorialButton.HighEmphasis = true;
            tutorialButton.Icon = null;
            tutorialButton.Location = new Point(26, 76);
            tutorialButton.Margin = new Padding(4, 6, 4, 6);
            tutorialButton.MouseState = MaterialSkin.MouseState.HOVER;
            tutorialButton.Name = "tutorialButton";
            tutorialButton.NoAccentTextColor = Color.Empty;
            tutorialButton.Size = new Size(158, 36);
            tutorialButton.TabIndex = 34;
            tutorialButton.Text = "Tutorial";
            tutorialButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            tutorialButton.UseAccentColor = false;
            tutorialButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.None;
            playButton.AutoSize = false;
            playButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            playButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            playButton.Depth = 0;
            playButton.HighEmphasis = true;
            playButton.Icon = null;
            playButton.Location = new Point(26, 28);
            playButton.Margin = new Padding(4, 6, 4, 6);
            playButton.MouseState = MaterialSkin.MouseState.HOVER;
            playButton.Name = "playButton";
            playButton.NoAccentTextColor = Color.Empty;
            playButton.Size = new Size(158, 36);
            playButton.TabIndex = 33;
            playButton.Text = "Play";
            playButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            playButton.UseAccentColor = false;
            playButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(settingsButton);
            panel1.Controls.Add(playButton);
            panel1.Controls.Add(logoutButton);
            panel1.Controls.Add(tutorialButton);
            panel1.Controls.Add(leaderboardButton);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(520, 282);
            panel1.Name = "panel1";
            panel1.Size = new Size(204, 271);
            panel1.TabIndex = 38;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1280, 720);
            Controls.Add(panel1);
            Controls.Add(hopeForm1);
            Controls.Add(bigLabel1);
            Controls.Add(versionLABEL);
            Controls.Add(mainMenuBackgroundMedia);
            ForeColor = SystemColors.ButtonShadow;
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenuForm";
            ((System.ComponentModel.ISupportInitialize)mainMenuBackgroundMedia).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView mainMenuBackgroundMedia;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private MaterialSkin.Controls.MaterialLabel versionLABEL;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton logoutButton;
        private MaterialSkin.Controls.MaterialButton settingsButton;
        private MaterialSkin.Controls.MaterialButton leaderboardButton;
        private MaterialSkin.Controls.MaterialButton tutorialButton;
        private MaterialSkin.Controls.MaterialButton playButton;
        private Panel panel1;
    }
}