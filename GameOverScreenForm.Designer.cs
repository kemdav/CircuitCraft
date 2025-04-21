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
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            playAgainButton = new MaterialSkin.Controls.MaterialButton();
            mainMenuButton = new MaterialSkin.Controls.MaterialButton();
            gameOverMessage = new ReaLTaiizor.Controls.BigLabel();
            SuspendLayout();
            // 
            // bigLabel1
            // 
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.Black;
            bigLabel1.Location = new Point(68, 25);
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
            playAgainButton.Location = new Point(160, 221);
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
            mainMenuButton.Location = new Point(160, 269);
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
            gameOverMessage.Location = new Point(32, 110);
            gameOverMessage.Name = "gameOverMessage";
            gameOverMessage.Size = new Size(510, 93);
            gameOverMessage.TabIndex = 3;
            gameOverMessage.Text = "Um.mmm You did not power the LED";
            gameOverMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameOverScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 320);
            Controls.Add(gameOverMessage);
            Controls.Add(mainMenuButton);
            Controls.Add(playAgainButton);
            Controls.Add(bigLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameOverScreenForm";
            Text = "GameOverScreenForm";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private MaterialSkin.Controls.MaterialButton playAgainButton;
        private MaterialSkin.Controls.MaterialButton mainMenuButton;
        private ReaLTaiizor.Controls.BigLabel gameOverMessage;
    }
}