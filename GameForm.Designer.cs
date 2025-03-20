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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            circuitGrid = new GridControl();
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            panel1 = new Panel();
            wireButton = new MaterialSkin.Controls.MaterialButton();
            batteryButton = new MaterialSkin.Controls.MaterialButton();
            resistorButton = new MaterialSkin.Controls.MaterialButton();
            ledButton = new MaterialSkin.Controls.MaterialButton();
            deleteButton = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            cyberProgressBar1 = new ReaLTaiizor.Controls.CyberProgressBar();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
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
            circuitGrid.Size = new Size(1280, 575);
            circuitGrid.TabIndex = 0;
            // 
            // hopeForm1
            // 
            hopeForm1.ControlBoxColorH = Color.FromArgb(228, 231, 237);
            hopeForm1.ControlBoxColorHC = Color.FromArgb(245, 108, 108);
            hopeForm1.ControlBoxColorN = Color.White;
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
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(circuitGrid);
            panel1.Location = new Point(0, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(1280, 575);
            panel1.TabIndex = 2;
            // 
            // wireButton
            // 
            wireButton.AutoSize = false;
            wireButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wireButton.BackgroundImage = (Image)resources.GetObject("wireButton.BackgroundImage");
            wireButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            wireButton.Depth = 0;
            wireButton.HighEmphasis = true;
            wireButton.Icon = null;
            wireButton.Location = new Point(25, 49);
            wireButton.Margin = new Padding(4, 6, 4, 6);
            wireButton.MouseState = MaterialSkin.MouseState.HOVER;
            wireButton.Name = "wireButton";
            wireButton.NoAccentTextColor = Color.Empty;
            wireButton.Size = new Size(99, 67);
            wireButton.TabIndex = 3;
            wireButton.Text = "WIRE";
            wireButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            wireButton.UseAccentColor = false;
            wireButton.UseVisualStyleBackColor = true;
            wireButton.Click += toolButton_Click;
            // 
            // batteryButton
            // 
            batteryButton.AutoSize = false;
            batteryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            batteryButton.BackgroundImage = (Image)resources.GetObject("batteryButton.BackgroundImage");
            batteryButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            batteryButton.Depth = 0;
            batteryButton.HighEmphasis = true;
            batteryButton.Icon = null;
            batteryButton.Location = new Point(122, 49);
            batteryButton.Margin = new Padding(4, 6, 4, 6);
            batteryButton.MouseState = MaterialSkin.MouseState.HOVER;
            batteryButton.Name = "batteryButton";
            batteryButton.NoAccentTextColor = Color.Empty;
            batteryButton.Size = new Size(99, 67);
            batteryButton.TabIndex = 4;
            batteryButton.Text = "BATTERY";
            batteryButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            batteryButton.UseAccentColor = false;
            batteryButton.UseVisualStyleBackColor = true;
            batteryButton.Click += toolButton_Click;
            // 
            // resistorButton
            // 
            resistorButton.AutoSize = false;
            resistorButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resistorButton.BackgroundImage = (Image)resources.GetObject("resistorButton.BackgroundImage");
            resistorButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            resistorButton.Depth = 0;
            resistorButton.HighEmphasis = true;
            resistorButton.Icon = null;
            resistorButton.Location = new Point(317, 49);
            resistorButton.Margin = new Padding(4, 6, 4, 6);
            resistorButton.MouseState = MaterialSkin.MouseState.HOVER;
            resistorButton.Name = "resistorButton";
            resistorButton.NoAccentTextColor = Color.Empty;
            resistorButton.Size = new Size(99, 67);
            resistorButton.TabIndex = 5;
            resistorButton.TabStop = false;
            resistorButton.Text = "RESISTOR";
            resistorButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            resistorButton.UseAccentColor = false;
            resistorButton.UseVisualStyleBackColor = true;
            resistorButton.Click += toolButton_Click;
            // 
            // ledButton
            // 
            ledButton.AutoSize = false;
            ledButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ledButton.BackgroundImage = (Image)resources.GetObject("ledButton.BackgroundImage");
            ledButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ledButton.Depth = 0;
            ledButton.HighEmphasis = true;
            ledButton.Icon = null;
            ledButton.Location = new Point(220, 49);
            ledButton.Margin = new Padding(4, 6, 4, 6);
            ledButton.MouseState = MaterialSkin.MouseState.HOVER;
            ledButton.Name = "ledButton";
            ledButton.NoAccentTextColor = Color.Empty;
            ledButton.Size = new Size(99, 67);
            ledButton.TabIndex = 6;
            ledButton.Text = "LED";
            ledButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            ledButton.UseAccentColor = false;
            ledButton.UseVisualStyleBackColor = true;
            ledButton.Click += toolButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.AutoSize = false;
            deleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            deleteButton.BackgroundImage = (Image)resources.GetObject("deleteButton.BackgroundImage");
            deleteButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            deleteButton.Depth = 0;
            deleteButton.HighEmphasis = true;
            deleteButton.Icon = null;
            deleteButton.Location = new Point(414, 49);
            deleteButton.Margin = new Padding(4, 6, 4, 6);
            deleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            deleteButton.Name = "deleteButton";
            deleteButton.NoAccentTextColor = Color.Empty;
            deleteButton.Size = new Size(100, 67);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "DELETE";
            deleteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            deleteButton.UseAccentColor = false;
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += toolButton_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(562, 63);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(319, 41);
            materialLabel1.TabIndex = 8;
            materialLabel1.Text = "Objective: Turn on the LED using the resistor with unknown resistance!";
            // 
            // cyberProgressBar1
            // 
            cyberProgressBar1.Alpha = 50;
            cyberProgressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cyberProgressBar1.BackColor = Color.Transparent;
            cyberProgressBar1.Background = true;
            cyberProgressBar1.Background_WidthPen = 3F;
            cyberProgressBar1.BackgroundPen = true;
            cyberProgressBar1.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberProgressBar1.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberProgressBar1.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberProgressBar1.ColorBackground_Pen = Color.LightGray;
            cyberProgressBar1.ColorBackground_Value_1 = Color.FromArgb(28, 200, 238);
            cyberProgressBar1.ColorBackground_Value_2 = Color.FromArgb(100, 208, 232);
            cyberProgressBar1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberProgressBar1.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberProgressBar1.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberProgressBar1.ColorProgressBar = Color.Red;
            cyberProgressBar1.ColorValue_Transparency = 200;
            cyberProgressBar1.CyberProgressBarStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberProgressBar1.Font = new Font("Arial", 11F);
            cyberProgressBar1.ForeColor = Color.FromArgb(245, 245, 245);
            cyberProgressBar1.Lighting = false;
            cyberProgressBar1.LinearGradient_Background = false;
            cyberProgressBar1.LinearGradient_Value = false;
            cyberProgressBar1.LinearGradientPen = false;
            cyberProgressBar1.Location = new Point(929, 63);
            cyberProgressBar1.Maximum = 100;
            cyberProgressBar1.Minimum = 0;
            cyberProgressBar1.Name = "cyberProgressBar1";
            cyberProgressBar1.PenWidth = 10;
            cyberProgressBar1.ProgressText = true;
            cyberProgressBar1.RGB = false;
            cyberProgressBar1.Rounding = true;
            cyberProgressBar1.RoundingInt = 70;
            cyberProgressBar1.Size = new Size(319, 34);
            cyberProgressBar1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberProgressBar1.StartDrawingValue = 0;
            cyberProgressBar1.TabIndex = 9;
            cyberProgressBar1.Tag = "Cyber";
            cyberProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberProgressBar1.Timer_RGB = 300;
            cyberProgressBar1.Value = 100;
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(1056, 100);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(59, 23);
            materialLabel2.TabIndex = 9;
            materialLabel2.Text = "HEALTH";
            // 
            // materialLabel3
            // 
            materialLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(924, 123);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(336, 19);
            materialLabel3.TabIndex = 10;
            materialLabel3.Text = "Circuits Completed: 3            Current Rating: 234";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(cyberProgressBar1);
            Controls.Add(materialLabel1);
            Controls.Add(deleteButton);
            Controls.Add(resistorButton);
            Controls.Add(batteryButton);
            Controls.Add(ledButton);
            Controls.Add(wireButton);
            Controls.Add(hopeForm1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GridControl circuitGrid;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton wireButton;
        private MaterialSkin.Controls.MaterialButton batteryButton;
        private MaterialSkin.Controls.MaterialButton resistorButton;
        private MaterialSkin.Controls.MaterialButton ledButton;
        private MaterialSkin.Controls.MaterialButton deleteButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.CyberProgressBar cyberProgressBar1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}