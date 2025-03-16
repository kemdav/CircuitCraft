namespace CircuitCraft
{
    partial class LeaderboardsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaderboardsForm));
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "1", "Kem" }, -1, Color.Empty, Color.Empty, new Font("Sketchit Means Sketchit", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0));
            leaderboardPbox = new PictureBox();
            leaderboardLVIEW = new MaterialSkin.Controls.MaterialListView();
            RankCLMN = new ColumnHeader();
            UserCLMN = new ColumnHeader();
            leaderboardBackTXT = new Label();
            ((System.ComponentModel.ISupportInitialize)leaderboardPbox).BeginInit();
            SuspendLayout();
            // 
            // leaderboardPbox
            // 
            leaderboardPbox.Image = (Image)resources.GetObject("leaderboardPbox.Image");
            leaderboardPbox.Location = new Point(-1, -3);
            leaderboardPbox.Name = "leaderboardPbox";
            leaderboardPbox.Size = new Size(1264, 720);
            leaderboardPbox.SizeMode = PictureBoxSizeMode.Zoom;
            leaderboardPbox.TabIndex = 3;
            leaderboardPbox.TabStop = false;
            // 
            // leaderboardLVIEW
            // 
            leaderboardLVIEW.AutoSizeTable = false;
            leaderboardLVIEW.BackColor = Color.FromArgb(255, 255, 255);
            leaderboardLVIEW.BorderStyle = BorderStyle.None;
            leaderboardLVIEW.Columns.AddRange(new ColumnHeader[] { RankCLMN, UserCLMN });
            leaderboardLVIEW.Depth = 0;
            leaderboardLVIEW.FullRowSelect = true;
            leaderboardLVIEW.Items.AddRange(new ListViewItem[] { listViewItem1 });
            leaderboardLVIEW.Location = new Point(366, 86);
            leaderboardLVIEW.MinimumSize = new Size(200, 100);
            leaderboardLVIEW.MouseLocation = new Point(-1, -1);
            leaderboardLVIEW.MouseState = MaterialSkin.MouseState.OUT;
            leaderboardLVIEW.Name = "leaderboardLVIEW";
            leaderboardLVIEW.OwnerDraw = true;
            leaderboardLVIEW.Size = new Size(519, 109);
            leaderboardLVIEW.TabIndex = 4;
            leaderboardLVIEW.UseCompatibleStateImageBehavior = false;
            leaderboardLVIEW.View = View.Details;
            // 
            // RankCLMN
            // 
            RankCLMN.Text = "Rank";
            RankCLMN.Width = 80;
            // 
            // UserCLMN
            // 
            UserCLMN.Text = "Username";
            UserCLMN.Width = 130;
            // 
            // leaderboardBackTXT
            // 
            leaderboardBackTXT.BackColor = Color.Transparent;
            leaderboardBackTXT.Font = new Font("Sketchit Means Sketchit", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leaderboardBackTXT.Location = new Point(530, 532);
            leaderboardBackTXT.Name = "leaderboardBackTXT";
            leaderboardBackTXT.Size = new Size(227, 87);
            leaderboardBackTXT.TabIndex = 25;
            leaderboardBackTXT.Text = "Back";
            leaderboardBackTXT.TextAlign = ContentAlignment.MiddleCenter;
            leaderboardBackTXT.Click += leaderboardBackTXT_Click;
            // 
            // LeaderboardsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(leaderboardBackTXT);
            Controls.Add(leaderboardLVIEW);
            Controls.Add(leaderboardPbox);
            Name = "LeaderboardsForm";
            Text = "LeaderboardsForm";
            ((System.ComponentModel.ISupportInitialize)leaderboardPbox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox leaderboardPbox;
        private MaterialSkin.Controls.MaterialListView leaderboardLVIEW;
        private ColumnHeader RankCLMN;
        private ColumnHeader UserCLMN;
        private Label leaderboardBackTXT;
    }
}