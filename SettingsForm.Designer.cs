namespace CircuitCraft
{
    partial class SettingsForm
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
            airForm1 = new ReaLTaiizor.Forms.AirForm();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialSlider1 = new MaterialSkin.Controls.MaterialSlider();
            mainMenuButton = new MaterialSkin.Controls.MaterialButton();
            materialSlider2 = new MaterialSkin.Controls.MaterialSlider();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            tabPage2 = new TabPage();
            spaceMaximize1 = new ReaLTaiizor.Controls.SpaceMaximize();
            spaceMinimize1 = new ReaLTaiizor.Controls.SpaceMinimize();
            airForm1.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // airForm1
            // 
            airForm1.BackColor = Color.GhostWhite;
            airForm1.BorderStyle = FormBorderStyle.None;
            airForm1.Controls.Add(materialTabSelector1);
            airForm1.Controls.Add(materialTabControl1);
            airForm1.Controls.Add(spaceMaximize1);
            airForm1.Controls.Add(spaceMinimize1);
            airForm1.Customization = "AAAA/1paWv9ycnL/";
            airForm1.Dock = DockStyle.Fill;
            airForm1.Font = new Font("Segoe UI", 9F);
            airForm1.Image = null;
            airForm1.Location = new Point(0, 0);
            airForm1.MinimumSize = new Size(112, 35);
            airForm1.Movable = true;
            airForm1.Name = "airForm1";
            airForm1.NoRounding = false;
            airForm1.Sizable = true;
            airForm1.Size = new Size(1280, 720);
            airForm1.SmartBounds = true;
            airForm1.StartPosition = FormStartPosition.WindowsDefaultLocation;
            airForm1.TabIndex = 0;
            airForm1.TransparencyKey = Color.Fuchsia;
            airForm1.Transparent = false;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BackgroundImageLayout = ImageLayout.Center;
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Upper;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(87, 14);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(1082, 48);
            materialTabSelector1.TabIndex = 7;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            materialTabControl1.Anchor = AnchorStyles.None;
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.HotTrack = true;
            materialTabControl1.ImeMode = ImeMode.NoControl;
            materialTabControl1.ItemSize = new Size(88, 20);
            materialTabControl1.Location = new Point(94, 68);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.Padding = new Point(0, 0);
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1082, 600);
            materialTabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(192, 255, 255);
            tabPage1.Controls.Add(materialSlider1);
            tabPage1.Controls.Add(mainMenuButton);
            tabPage1.Controls.Add(materialSlider2);
            tabPage1.Controls.Add(bigLabel1);
            tabPage1.Controls.Add(materialComboBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1074, 572);
            tabPage1.TabIndex = 0;
            tabPage1.Text = " ";
            // 
            // materialSlider1
            // 
            materialSlider1.Anchor = AnchorStyles.None;
            materialSlider1.Depth = 0;
            materialSlider1.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialSlider1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialSlider1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialSlider1.Location = new Point(76, 96);
            materialSlider1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider1.Name = "materialSlider1";
            materialSlider1.Size = new Size(702, 40);
            materialSlider1.TabIndex = 2;
            materialSlider1.Text = "Music";
            // 
            // mainMenuButton
            // 
            mainMenuButton.Anchor = AnchorStyles.None;
            mainMenuButton.AutoSize = false;
            mainMenuButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainMenuButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mainMenuButton.Depth = 0;
            mainMenuButton.HighEmphasis = true;
            mainMenuButton.Icon = null;
            mainMenuButton.Location = new Point(76, 437);
            mainMenuButton.Margin = new Padding(4, 6, 4, 6);
            mainMenuButton.MouseState = MaterialSkin.MouseState.HOVER;
            mainMenuButton.Name = "mainMenuButton";
            mainMenuButton.NoAccentTextColor = Color.Empty;
            mainMenuButton.Size = new Size(702, 46);
            mainMenuButton.TabIndex = 6;
            mainMenuButton.Text = "Return to Main Menu";
            mainMenuButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mainMenuButton.UseAccentColor = false;
            mainMenuButton.UseVisualStyleBackColor = true;
            mainMenuButton.Click += mainMenuButton_Click;
            // 
            // materialSlider2
            // 
            materialSlider2.Anchor = AnchorStyles.None;
            materialSlider2.Depth = 0;
            materialSlider2.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialSlider2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialSlider2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialSlider2.Location = new Point(76, 142);
            materialSlider2.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider2.Name = "materialSlider2";
            materialSlider2.Size = new Size(702, 40);
            materialSlider2.TabIndex = 3;
            materialSlider2.Text = "Sound";
            // 
            // bigLabel1
            // 
            bigLabel1.Anchor = AnchorStyles.None;
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 25F);
            bigLabel1.ForeColor = Color.Black;
            bigLabel1.Location = new Point(76, 206);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(218, 46);
            bigLabel1.TabIndex = 5;
            bigLabel1.Text = "GUI SCALING";
            // 
            // materialComboBox1
            // 
            materialComboBox1.Anchor = AnchorStyles.None;
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.White;
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Items.AddRange(new object[] { "50%", "100%", "150%", "200%" });
            materialComboBox1.Location = new Point(325, 206);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(453, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1074, 572);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Account Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // spaceMaximize1
            // 
            spaceMaximize1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spaceMaximize1.Customization = "G4qM/3LEtP8yMjL/Kioq/yPJzP8bioz//v7+/yMjI/8qKir/";
            spaceMaximize1.DefaultAnchor = true;
            spaceMaximize1.DefaultLocation = true;
            spaceMaximize1.Font = new Font("Verdana", 8F);
            spaceMaximize1.Image = null;
            spaceMaximize1.Location = new Point(1230, 3);
            spaceMaximize1.Name = "spaceMaximize1";
            spaceMaximize1.NoRounding = false;
            spaceMaximize1.Size = new Size(23, 21);
            spaceMaximize1.TabIndex = 1;
            spaceMaximize1.Text = "+";
            spaceMaximize1.Transparent = false;
            spaceMaximize1.WindowState = FormWindowState.Normal;
            // 
            // spaceMinimize1
            // 
            spaceMinimize1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spaceMinimize1.Customization = "G4qM/3LEtP8yMjL/Kioq/yPJzP8bioz//v7+/yMjI/8qKir/";
            spaceMinimize1.DefaultAnchor = true;
            spaceMinimize1.DefaultLocation = true;
            spaceMinimize1.Font = new Font("Verdana", 8F);
            spaceMinimize1.Image = null;
            spaceMinimize1.Location = new Point(1206, 3);
            spaceMinimize1.Name = "spaceMinimize1";
            spaceMinimize1.NoRounding = false;
            spaceMinimize1.Size = new Size(23, 21);
            spaceMinimize1.TabIndex = 0;
            spaceMinimize1.Text = "_";
            spaceMinimize1.Transparent = false;
            spaceMinimize1.WindowState = FormWindowState.Normal;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(airForm1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1280, 720);
            Name = "SettingsForm";
            Text = "SettingsForm";
            TransparencyKey = Color.Fuchsia;
            airForm1.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.AirForm airForm1;
        private ReaLTaiizor.Controls.SpaceMaximize spaceMaximize1;
        private ReaLTaiizor.Controls.SpaceMinimize spaceMinimize1;
        private MaterialSkin.Controls.MaterialSlider materialSlider2;
        private MaterialSkin.Controls.MaterialSlider materialSlider1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private MaterialSkin.Controls.MaterialButton mainMenuButton;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
    }
}