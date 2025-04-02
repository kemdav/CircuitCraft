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
            gameCanvas = new GameCanvas();
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
            // gameCanvas
            // 
            gameCanvas.BackColor = Color.FromArgb(224, 224, 224);
            gameCanvas.CircuitElementOffset = 20;
            gameCanvas.CircuitElementResistorSprite = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite");
            gameCanvas.CurrentBlockIndex = 0;
            gameCanvas.Location = new Point(12, 46);
            gameCanvas.Name = "gameCanvas";
            gameCanvas.Size = new Size(1240, 612);
            gameCanvas.TabIndex = 3;
            // 
            // MainGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(gameCanvas);
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
        private GameCanvas gameCanvas;
    }
}