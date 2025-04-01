namespace CircuitCraft
{
    partial class MainGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            gameCanvas1 = new GameCanvas();
            circuitBlock1 = new CircuitBlock();
            SuspendLayout();
            // 
            // hopeForm1
            // 
            hopeForm1.ControlBoxColorH = Color.FromArgb(228, 231, 237);
            hopeForm1.ControlBoxColorHC = Color.FromArgb(245, 108, 108);
            hopeForm1.ControlBoxColorN = Color.White;
            hopeForm1.Dock = DockStyle.Top;
            hopeForm1.Font = new Font("Segoe UI", 12F);
            hopeForm1.ForeColor = Color.FromArgb(242, 246, 252);
            hopeForm1.Image = (Image)resources.GetObject("hopeForm1.Image");
            hopeForm1.Location = new Point(0, 0);
            hopeForm1.Name = "hopeForm1";
            hopeForm1.Size = new Size(1264, 40);
            hopeForm1.TabIndex = 0;
            hopeForm1.Text = "hopeForm1";
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // gameCanvas1
            // 
            gameCanvas1.BackColor = Color.FromArgb(224, 224, 224);
            gameCanvas1.CurrentBlockIndex = 0;
            gameCanvas1.Location = new Point(142, 109);
            gameCanvas1.Name = "gameCanvas1";
            gameCanvas1.Size = new Size(932, 503);
            gameCanvas1.TabIndex = 1;
            // 
            // circuitBlock1
            // 
            circuitBlock1.BackColor = Color.SkyBlue;
            circuitBlock1.CircuitElementHeight = 100;
            circuitBlock1.CircuitElementSprite = Properties.Resources.Cat_kayden_pfp;
            circuitBlock1.CircuitElementWidth = 100;
            circuitBlock1.CurrentElementIndex = 0;
            circuitBlock1.Location = new Point(334, 159);
            circuitBlock1.Name = "circuitBlock1";
            circuitBlock1.Size = new Size(100, 400);
            circuitBlock1.TabIndex = 2;
            // 
            // MainGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(circuitBlock1);
            Controls.Add(gameCanvas1);
            Controls.Add(hopeForm1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "MainGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainGame";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private GameCanvas gameCanvas1;
        private CircuitBlock circuitBlock1;
    }
}