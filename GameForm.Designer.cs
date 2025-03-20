namespace CircuitCraft
{
    partial class GameForm
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
            circuitGrid = new GridControl();
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            panel1 = new Panel();
            panel2 = new Panel();
            hopeForm1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // circuitGrid
            // 
            circuitGrid.BackColor = Color.White;
            circuitGrid.Dock = DockStyle.Fill;
            circuitGrid.GridSize = 60;
            circuitGrid.Location = new Point(0, 0);
            circuitGrid.Name = "circuitGrid";
            circuitGrid.Size = new Size(1280, 618);
            circuitGrid.TabIndex = 0;
            // 
            // hopeForm1
            // 
            hopeForm1.ControlBoxColorH = Color.FromArgb(228, 231, 237);
            hopeForm1.ControlBoxColorHC = Color.FromArgb(245, 108, 108);
            hopeForm1.ControlBoxColorN = Color.White;
            hopeForm1.Controls.Add(panel2);
            hopeForm1.Dock = DockStyle.Top;
            hopeForm1.Font = new Font("Segoe UI", 12F);
            hopeForm1.ForeColor = Color.FromArgb(242, 246, 252);
            hopeForm1.Image = null;
            hopeForm1.Location = new Point(0, 0);
            hopeForm1.Name = "hopeForm1";
            hopeForm1.Size = new Size(1280, 40);
            hopeForm1.TabIndex = 1;
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // panel1
            // 
            panel1.Controls.Add(circuitGrid);
            panel1.Location = new Point(0, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(1280, 618);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(1280, 70);
            panel2.TabIndex = 3;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panel1);
            Controls.Add(hopeForm1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            hopeForm1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GridControl circuitGrid;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private Panel panel2;
        private Panel panel1;
    }
}