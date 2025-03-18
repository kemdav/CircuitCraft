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
            mainMenuPbox = new PictureBox();
            playTXT = new Label();
            leaderboardsTXT = new Label();
            settingsTXT = new Label();
            tutorialTXT = new Label();
            logoutTXT = new Label();
            settingsPbox = new PictureBox();
            musicTXT = new Label();
            soundTXT = new Label();
            musicSlider = new ReaLTaiizor.Controls.ParrotSlider();
            settingsBackTXT = new Label();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)mainMenuPbox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingsPbox).BeginInit();
            SuspendLayout();
            // 
            // mainMenuPbox
            // 
            mainMenuPbox.Location = new Point(0, 0);
            mainMenuPbox.Name = "mainMenuPbox";
            mainMenuPbox.Size = new Size(1264, 720);
            mainMenuPbox.SizeMode = PictureBoxSizeMode.Zoom;
            mainMenuPbox.TabIndex = 2;
            mainMenuPbox.TabStop = false;
            // 
            // playTXT
            // 
            playTXT.BackColor = Color.Transparent;
            playTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playTXT.Location = new Point(442, 61);
            playTXT.Name = "playTXT";
            playTXT.Size = new Size(382, 87);
            playTXT.TabIndex = 5;
            playTXT.Text = "Play";
            playTXT.TextAlign = ContentAlignment.MiddleCenter;
            playTXT.Click += playTXT_Click;
            // 
            // leaderboardsTXT
            // 
            leaderboardsTXT.BackColor = Color.Transparent;
            leaderboardsTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leaderboardsTXT.Location = new Point(442, 290);
            leaderboardsTXT.Name = "leaderboardsTXT";
            leaderboardsTXT.Size = new Size(382, 87);
            leaderboardsTXT.TabIndex = 6;
            leaderboardsTXT.Text = "Leaderboards";
            leaderboardsTXT.TextAlign = ContentAlignment.MiddleCenter;
            leaderboardsTXT.Click += leaderboardsTXT_Click;
            // 
            // settingsTXT
            // 
            settingsTXT.BackColor = Color.Transparent;
            settingsTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingsTXT.Location = new Point(442, 405);
            settingsTXT.Name = "settingsTXT";
            settingsTXT.Size = new Size(382, 87);
            settingsTXT.TabIndex = 7;
            settingsTXT.Text = "Settings";
            settingsTXT.TextAlign = ContentAlignment.MiddleCenter;
            settingsTXT.Click += settingsTXT_Click;
            // 
            // tutorialTXT
            // 
            tutorialTXT.BackColor = Color.Transparent;
            tutorialTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tutorialTXT.Location = new Point(442, 176);
            tutorialTXT.Name = "tutorialTXT";
            tutorialTXT.Size = new Size(382, 87);
            tutorialTXT.TabIndex = 8;
            tutorialTXT.Text = "Tutorial";
            tutorialTXT.TextAlign = ContentAlignment.MiddleCenter;
            tutorialTXT.Click += tutorialTXT_Click;
            // 
            // logoutTXT
            // 
            logoutTXT.BackColor = Color.Transparent;
            logoutTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoutTXT.Location = new Point(442, 513);
            logoutTXT.Name = "logoutTXT";
            logoutTXT.Size = new Size(382, 87);
            logoutTXT.TabIndex = 9;
            logoutTXT.Text = "LOGOUT";
            logoutTXT.TextAlign = ContentAlignment.MiddleCenter;
            logoutTXT.Click += logoutTXT_Click;
            // 
            // settingsPbox
            // 
            settingsPbox.Image = (Image)resources.GetObject("settingsPbox.Image");
            settingsPbox.Location = new Point(-2, 0);
            settingsPbox.Name = "settingsPbox";
            settingsPbox.Size = new Size(1280, 720);
            settingsPbox.SizeMode = PictureBoxSizeMode.Zoom;
            settingsPbox.TabIndex = 10;
            settingsPbox.TabStop = false;
            // 
            // musicTXT
            // 
            musicTXT.BackColor = Color.Transparent;
            musicTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            musicTXT.Location = new Point(158, 110);
            musicTXT.Name = "musicTXT";
            musicTXT.Size = new Size(227, 87);
            musicTXT.TabIndex = 21;
            musicTXT.Text = "Music";
            musicTXT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // soundTXT
            // 
            soundTXT.BackColor = Color.Transparent;
            soundTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            soundTXT.Location = new Point(158, 219);
            soundTXT.Name = "soundTXT";
            soundTXT.Size = new Size(227, 87);
            soundTXT.TabIndex = 22;
            soundTXT.Text = "Sound";
            soundTXT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musicSlider
            // 
            musicSlider.BarThickness = 4;
            musicSlider.BigStepIncrement = 10;
            musicSlider.Colors = (List<Color>)resources.GetObject("musicSlider.Colors");
            musicSlider.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            musicSlider.FilledColor = Color.FromArgb(1, 119, 215);
            musicSlider.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            musicSlider.KnobColor = Color.Gray;
            musicSlider.KnobImage = Properties.Resources.title;
            musicSlider.Location = new Point(455, 132);
            musicSlider.Max = 100;
            musicSlider.Name = "musicSlider";
            musicSlider.Percentage = 50;
            musicSlider.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            musicSlider.Positions = (List<float>)resources.GetObject("musicSlider.Positions");
            musicSlider.QuickHopping = false;
            musicSlider.Size = new Size(716, 87);
            musicSlider.SliderStyle = ReaLTaiizor.Controls.ParrotSlider.Style.Windows10;
            musicSlider.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            musicSlider.TabIndex = 23;
            musicSlider.Text = "parrotSlider1";
            musicSlider.UnfilledColor = Color.FromArgb(26, 169, 219);
            // 
            // settingsBackTXT
            // 
            settingsBackTXT.BackColor = Color.Transparent;
            settingsBackTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingsBackTXT.Location = new Point(511, 467);
            settingsBackTXT.Name = "settingsBackTXT";
            settingsBackTXT.Size = new Size(227, 87);
            settingsBackTXT.TabIndex = 24;
            settingsBackTXT.Text = "Back";
            settingsBackTXT.TextAlign = ContentAlignment.MiddleCenter;
            settingsBackTXT.Click += settingsBackTXT_Click;
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Items.AddRange(new object[] { "1280x720", "1920x1080" });
            materialComboBox1.Location = new Point(858, 55);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(357, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 26;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1264, 1161);
            Controls.Add(materialComboBox1);
            Controls.Add(settingsBackTXT);
            Controls.Add(musicSlider);
            Controls.Add(soundTXT);
            Controls.Add(musicTXT);
            Controls.Add(logoutTXT);
            Controls.Add(tutorialTXT);
            Controls.Add(settingsTXT);
            Controls.Add(leaderboardsTXT);
            Controls.Add(playTXT);
            Controls.Add(mainMenuPbox);
            Controls.Add(settingsPbox);
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenuForm";
            Load += MainMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)mainMenuPbox).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingsPbox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mainMenuPbox;
        private Label playTXT;
        private Label leaderboardsTXT;
        private Label settingsTXT;
        private Label tutorialTXT;
        private Label logoutTXT;
        private PictureBox settingsPbox;
        private Label musicTXT;
        private Label soundTXT;
        private ReaLTaiizor.Controls.ParrotSlider musicSlider;
        private Label settingsBackTXT;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
    }
}