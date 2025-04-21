namespace CircuitCraft
{
    partial class GameOverScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverScreenForm));
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            playAgainButton = new MaterialSkin.Controls.MaterialButton();
            mainMenuButton = new MaterialSkin.Controls.MaterialButton();
            gameOverMessage = new ReaLTaiizor.Controls.BigLabel();
            pictureBox1 = new PictureBox();
            ratingChangeLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox2 = new PictureBox();
            ledBurnedChangeLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox3 = new PictureBox();
            ledUnpoweredChangeLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox4 = new PictureBox();
            highestLevelChangeLabel = new ReaLTaiizor.Controls.BigLabel();
            jouleLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox5 = new PictureBox();
            diodeLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox6 = new PictureBox();
            overflowLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // bigLabel1
            // 
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.Black;
            bigLabel1.Location = new Point(133, 9);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(442, 85);
            bigLabel1.TabIndex = 0;
            bigLabel1.Text = "GAME OVER!";
            // 
            // playAgainButton
            // 
            playAgainButton.AutoSize = false;
            playAgainButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            playAgainButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            playAgainButton.Depth = 0;
            playAgainButton.HighEmphasis = true;
            playAgainButton.Icon = null;
            playAgainButton.Location = new Point(219, 528);
            playAgainButton.Margin = new Padding(4, 6, 4, 6);
            playAgainButton.MouseState = MaterialSkin.MouseState.HOVER;
            playAgainButton.Name = "playAgainButton";
            playAgainButton.NoAccentTextColor = Color.Empty;
            playAgainButton.Size = new Size(263, 36);
            playAgainButton.TabIndex = 1;
            playAgainButton.TabStop = false;
            playAgainButton.Text = "PLAY AGAIN";
            playAgainButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            playAgainButton.UseAccentColor = false;
            playAgainButton.UseVisualStyleBackColor = true;
            playAgainButton.Click += playAgainButton_Click;
            // 
            // mainMenuButton
            // 
            mainMenuButton.AutoSize = false;
            mainMenuButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainMenuButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mainMenuButton.Depth = 0;
            mainMenuButton.HighEmphasis = true;
            mainMenuButton.Icon = null;
            mainMenuButton.Location = new Point(219, 576);
            mainMenuButton.Margin = new Padding(4, 6, 4, 6);
            mainMenuButton.MouseState = MaterialSkin.MouseState.HOVER;
            mainMenuButton.Name = "mainMenuButton";
            mainMenuButton.NoAccentTextColor = Color.Empty;
            mainMenuButton.Size = new Size(263, 36);
            mainMenuButton.TabIndex = 2;
            mainMenuButton.TabStop = false;
            mainMenuButton.Text = "BACK TO MAIN MENU";
            mainMenuButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mainMenuButton.UseAccentColor = false;
            mainMenuButton.UseVisualStyleBackColor = true;
            mainMenuButton.Click += mainMenuButton_Click;
            // 
            // gameOverMessage
            // 
            gameOverMessage.BackColor = Color.Transparent;
            gameOverMessage.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gameOverMessage.ForeColor = Color.IndianRed;
            gameOverMessage.Location = new Point(90, 94);
            gameOverMessage.Name = "gameOverMessage";
            gameOverMessage.Size = new Size(510, 104);
            gameOverMessage.TabIndex = 3;
            gameOverMessage.Text = "Um.mmm You did not power the LED";
            gameOverMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 217);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(68, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // ratingChangeLabel
            // 
            ratingChangeLabel.BackColor = Color.Transparent;
            ratingChangeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ratingChangeLabel.ForeColor = Color.Black;
            ratingChangeLabel.Location = new Point(155, 217);
            ratingChangeLabel.Name = "ratingChangeLabel";
            ratingChangeLabel.Size = new Size(155, 60);
            ratingChangeLabel.TabIndex = 5;
            ratingChangeLabel.Text = "20 -> 45";
            ratingChangeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(402, 217);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(68, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // ledBurnedChangeLabel
            // 
            ledBurnedChangeLabel.BackColor = Color.Transparent;
            ledBurnedChangeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ledBurnedChangeLabel.ForeColor = Color.Black;
            ledBurnedChangeLabel.Location = new Point(498, 217);
            ledBurnedChangeLabel.Name = "ledBurnedChangeLabel";
            ledBurnedChangeLabel.Size = new Size(155, 60);
            ledBurnedChangeLabel.TabIndex = 7;
            ledBurnedChangeLabel.Text = "20 -> 45";
            ledBurnedChangeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(59, 447);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(68, 60);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // ledUnpoweredChangeLabel
            // 
            ledUnpoweredChangeLabel.BackColor = Color.Transparent;
            ledUnpoweredChangeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ledUnpoweredChangeLabel.ForeColor = Color.Black;
            ledUnpoweredChangeLabel.Location = new Point(155, 447);
            ledUnpoweredChangeLabel.Name = "ledUnpoweredChangeLabel";
            ledUnpoweredChangeLabel.Size = new Size(155, 60);
            ledUnpoweredChangeLabel.TabIndex = 9;
            ledUnpoweredChangeLabel.Text = "20 -> 45";
            ledUnpoweredChangeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(59, 293);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(68, 60);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // highestLevelChangeLabel
            // 
            highestLevelChangeLabel.BackColor = Color.Transparent;
            highestLevelChangeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            highestLevelChangeLabel.ForeColor = Color.Black;
            highestLevelChangeLabel.Location = new Point(155, 296);
            highestLevelChangeLabel.Name = "highestLevelChangeLabel";
            highestLevelChangeLabel.Size = new Size(155, 60);
            highestLevelChangeLabel.TabIndex = 11;
            highestLevelChangeLabel.Text = "20 -> 45";
            highestLevelChangeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // jouleLabel
            // 
            jouleLabel.BackColor = Color.Transparent;
            jouleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jouleLabel.ForeColor = Color.Black;
            jouleLabel.Location = new Point(155, 371);
            jouleLabel.Name = "jouleLabel";
            jouleLabel.Size = new Size(155, 60);
            jouleLabel.TabIndex = 13;
            jouleLabel.Text = "20 -> 45";
            jouleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(59, 371);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(68, 60);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 12;
            pictureBox5.TabStop = false;
            // 
            // diodeLabel
            // 
            diodeLabel.BackColor = Color.Transparent;
            diodeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            diodeLabel.ForeColor = Color.Black;
            diodeLabel.Location = new Point(498, 293);
            diodeLabel.Name = "diodeLabel";
            diodeLabel.Size = new Size(155, 60);
            diodeLabel.TabIndex = 15;
            diodeLabel.Text = "20 -> 45";
            diodeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(402, 293);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(68, 60);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 14;
            pictureBox6.TabStop = false;
            // 
            // overflowLabel
            // 
            overflowLabel.BackColor = Color.Transparent;
            overflowLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            overflowLabel.ForeColor = Color.Black;
            overflowLabel.Location = new Point(498, 371);
            overflowLabel.Name = "overflowLabel";
            overflowLabel.Size = new Size(155, 60);
            overflowLabel.TabIndex = 17;
            overflowLabel.Text = "20 -> 45";
            overflowLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(402, 371);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(68, 60);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 16;
            pictureBox7.TabStop = false;
            // 
            // GameOverScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 655);
            Controls.Add(overflowLabel);
            Controls.Add(pictureBox7);
            Controls.Add(diodeLabel);
            Controls.Add(pictureBox6);
            Controls.Add(jouleLabel);
            Controls.Add(pictureBox5);
            Controls.Add(highestLevelChangeLabel);
            Controls.Add(pictureBox4);
            Controls.Add(ledUnpoweredChangeLabel);
            Controls.Add(pictureBox3);
            Controls.Add(ledBurnedChangeLabel);
            Controls.Add(pictureBox2);
            Controls.Add(ratingChangeLabel);
            Controls.Add(pictureBox1);
            Controls.Add(gameOverMessage);
            Controls.Add(mainMenuButton);
            Controls.Add(playAgainButton);
            Controls.Add(bigLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameOverScreenForm";
            Text = "GameOverScreenForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private MaterialSkin.Controls.MaterialButton playAgainButton;
        private MaterialSkin.Controls.MaterialButton mainMenuButton;
        private ReaLTaiizor.Controls.BigLabel gameOverMessage;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.BigLabel ratingChangeLabel;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.BigLabel ledBurnedChangeLabel;
        private PictureBox pictureBox3;
        private ReaLTaiizor.Controls.BigLabel ledUnpoweredChangeLabel;
        private PictureBox pictureBox4;
        private ReaLTaiizor.Controls.BigLabel highestLevelChangeLabel;
        private ReaLTaiizor.Controls.BigLabel jouleLabel;
        private PictureBox pictureBox5;
        private ReaLTaiizor.Controls.BigLabel diodeLabel;
        private PictureBox pictureBox6;
        private ReaLTaiizor.Controls.BigLabel overflowLabel;
        private PictureBox pictureBox7;
    }
}