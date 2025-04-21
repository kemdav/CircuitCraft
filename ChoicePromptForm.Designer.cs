namespace CircuitCraft
{
    partial class ChoicePromptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoicePromptForm));
            panel1 = new Panel();
            costLabel = new ReaLTaiizor.Controls.BigLabel();
            pictureBox2 = new PictureBox();
            cyberColorPicker1 = new ReaLTaiizor.Controls.CyberColorPicker();
            selectButton = new MaterialSkin.Controls.MaterialButton();
            cardDescription = new ReaLTaiizor.Controls.BigLabel();
            cardImagePbox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cardImagePbox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(costLabel);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(cyberColorPicker1);
            panel1.Controls.Add(selectButton);
            panel1.Controls.Add(cardDescription);
            panel1.Controls.Add(cardImagePbox);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 419);
            panel1.TabIndex = 1;
            // 
            // jouleCurrencyLabel
            // 
            costLabel.BackColor = Color.Transparent;
            costLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            costLabel.ForeColor = Color.FromArgb(80, 80, 80);
            costLabel.Location = new Point(78, 218);
            costLabel.Name = "jouleCurrencyLabel";
            costLabel.Size = new Size(169, 44);
            costLabel.TabIndex = 5;
            costLabel.Text = "1000 J";
            costLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(19, 217);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 47);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // cyberColorPicker1
            // 
            cyberColorPicker1.BackColor = Color.Transparent;
            cyberColorPicker1.ForeColor = Color.WhiteSmoke;
            cyberColorPicker1.Location = new Point(122, 239);
            cyberColorPicker1.Name = "cyberColorPicker1";
            cyberColorPicker1.SelectedColor = Color.Empty;
            cyberColorPicker1.Size = new Size(8, 8);
            cyberColorPicker1.TabIndex = 3;
            cyberColorPicker1.Tag = "Cyber";
            // 
            // selectButton
            // 
            selectButton.AutoSize = false;
            selectButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            selectButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            selectButton.Depth = 0;
            selectButton.HighEmphasis = true;
            selectButton.Icon = null;
            selectButton.Location = new Point(19, 366);
            selectButton.Margin = new Padding(4, 6, 4, 6);
            selectButton.MouseState = MaterialSkin.MouseState.HOVER;
            selectButton.Name = "selectButton";
            selectButton.NoAccentTextColor = Color.Empty;
            selectButton.Size = new Size(228, 36);
            selectButton.TabIndex = 2;
            selectButton.TabStop = false;
            selectButton.Text = "Select";
            selectButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            selectButton.UseAccentColor = false;
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // cardDescription
            // 
            cardDescription.BackColor = Color.Transparent;
            cardDescription.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cardDescription.ForeColor = Color.FromArgb(80, 80, 80);
            cardDescription.Location = new Point(31, 262);
            cardDescription.Name = "cardDescription";
            cardDescription.Size = new Size(216, 98);
            cardDescription.TabIndex = 1;
            cardDescription.Text = "Add one series vertical space\r\n";
            cardDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardImagePbox
            // 
            cardImagePbox.Image = (Image)resources.GetObject("cardImagePbox.Image");
            cardImagePbox.Location = new Point(19, 26);
            cardImagePbox.Name = "cardImagePbox";
            cardImagePbox.Size = new Size(228, 185);
            cardImagePbox.SizeMode = PictureBoxSizeMode.Zoom;
            cardImagePbox.TabIndex = 0;
            cardImagePbox.TabStop = false;
            // 
            // ChoicePromptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 419);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChoicePromptForm";
            Text = "ChoicePromptForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)cardImagePbox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton selectButton;
        private ReaLTaiizor.Controls.BigLabel cardDescription;
        private PictureBox cardImagePbox;
        private ReaLTaiizor.Controls.BigLabel costLabel;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.CyberColorPicker cyberColorPicker1;
    }
}