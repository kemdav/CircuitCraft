namespace CircuitCraft
{
    partial class LoadingForm
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
            loadProgressBar = new ReaLTaiizor.Controls.LostProgressBar();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            SuspendLayout();
            // 
            // loadProgressBar
            // 
            loadProgressBar.BackColor = Color.FromArgb(45, 45, 48);
            loadProgressBar.Color = Color.DodgerBlue;
            loadProgressBar.ForeColor = Color.FromArgb(63, 63, 70);
            loadProgressBar.Hover = false;
            loadProgressBar.Location = new Point(48, 334);
            loadProgressBar.Name = "loadProgressBar";
            loadProgressBar.Progress = 0;
            loadProgressBar.Size = new Size(692, 33);
            loadProgressBar.TabIndex = 0;
            loadProgressBar.Text = "lostProgressBar1";
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 25F);
            bigLabel1.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel1.Location = new Point(239, 380);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(303, 46);
            bigLabel1.TabIndex = 1;
            bigLabel1.Text = "LOADING ASSETS...";
            // 
            // bigLabel2
            // 
            bigLabel2.Anchor = AnchorStyles.None;
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = Color.Transparent;
            bigLabel2.FlatStyle = FlatStyle.Popup;
            bigLabel2.Font = new Font("Swis721 Blk BT", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = Color.CornflowerBlue;
            bigLabel2.Location = new Point(93, 99);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(599, 81);
            bigLabel2.TabIndex = 31;
            bigLabel2.Text = "CIRCUIT CRAFT";
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(bigLabel2);
            Controls.Add(bigLabel1);
            Controls.Add(loadProgressBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            Text = "LoadingForm";
            Load += LoadingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.LostProgressBar loadProgressBar;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
    }
}