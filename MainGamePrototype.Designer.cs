namespace CircuitCraft
{
    partial class MainGamePrototype
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGamePrototype));
            hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            gameCanvas = new GameCanvas();
            circuitBlock1 = new CircuitBlock();
            circuitBlock2 = new CircuitBlock();
            circuitBlock3 = new CircuitBlock();
            circuitBlock4 = new CircuitBlock();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            operatingCurrentProgress = new ReaLTaiizor.Controls.LostProgressBar();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox6 = new PictureBox();
            bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox7 = new PictureBox();
            lostProgressBar1 = new ReaLTaiizor.Controls.LostProgressBar();
            bigLabel5 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox11 = new PictureBox();
            bigLabel7 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel6 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel8 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox12 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
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
            hopeForm1.Image = null;
            hopeForm1.Location = new Point(0, 0);
            hopeForm1.Name = "hopeForm1";
            hopeForm1.Size = new Size(1280, 40);
            hopeForm1.TabIndex = 0;
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // gameCanvas
            // 
            gameCanvas.BackColor = Color.AliceBlue;
            gameCanvas.CircuitBlock = null;
            gameCanvas.CircuitElement = null;
            gameCanvas.CircuitElementOffset = 20;
            gameCanvas.CircuitSources = null;
            gameCanvas.CurrentBlockIndex = -1;
            gameCanvas.CurrentCircuitElementDropped = null;
            gameCanvas.CurrentCircuitElementDroppedResistance = 0D;
            gameCanvas.CurrentCircuitElementDroppedVoltage = 0D;
            gameCanvas.Location = new Point(0, 36);
            gameCanvas.MainGame = null;
            gameCanvas.Name = "gameCanvas";
            gameCanvas.OperatingCurrent = 0D;
            gameCanvas.OperatingCurrentTick = 0;
            gameCanvas.Size = new Size(1280, 685);
            gameCanvas.TabIndex = 1;
            // 
            // circuitBlock1
            // 
            circuitBlock1.BackColor = Color.Transparent;
            circuitBlock1.CircuitBlockConnectionType = CircuitBlockConnectionType.Series;
            circuitBlock1.CircuitElementHeight = 120;
            circuitBlock1.CurrentElementIndex = 0;
            circuitBlock1.Location = new Point(525, 185);
            circuitBlock1.Name = "circuitBlock1";
            circuitBlock1.Size = new Size(40, 480);
            circuitBlock1.TabIndex = 2;
            circuitBlock1.Visible = false;
            // 
            // circuitBlock2
            // 
            circuitBlock2.BackColor = Color.Transparent;
            circuitBlock2.CircuitBlockConnectionType = CircuitBlockConnectionType.Series;
            circuitBlock2.CircuitElementHeight = 120;
            circuitBlock2.CurrentElementIndex = 0;
            circuitBlock2.Location = new Point(571, 185);
            circuitBlock2.Name = "circuitBlock2";
            circuitBlock2.Size = new Size(40, 480);
            circuitBlock2.TabIndex = 3;
            circuitBlock2.Visible = false;
            // 
            // circuitBlock3
            // 
            circuitBlock3.BackColor = Color.Transparent;
            circuitBlock3.CircuitBlockConnectionType = CircuitBlockConnectionType.Series;
            circuitBlock3.CircuitElementHeight = 120;
            circuitBlock3.CurrentElementIndex = 0;
            circuitBlock3.Location = new Point(617, 185);
            circuitBlock3.Name = "circuitBlock3";
            circuitBlock3.Size = new Size(40, 480);
            circuitBlock3.TabIndex = 4;
            circuitBlock3.Visible = false;
            // 
            // circuitBlock4
            // 
            circuitBlock4.BackColor = Color.Transparent;
            circuitBlock4.CircuitBlockConnectionType = CircuitBlockConnectionType.Series;
            circuitBlock4.CircuitElementHeight = 120;
            circuitBlock4.CurrentElementIndex = 0;
            circuitBlock4.Location = new Point(663, 185);
            circuitBlock4.Name = "circuitBlock4";
            circuitBlock4.Size = new Size(40, 480);
            circuitBlock4.TabIndex = 5;
            circuitBlock4.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(459, 77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(311, 609);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(472, 88);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(287, 577);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // operatingCurrentProgress
            // 
            operatingCurrentProgress.BackColor = Color.FromArgb(45, 45, 48);
            operatingCurrentProgress.Color = Color.FromArgb(255, 128, 128);
            operatingCurrentProgress.ForeColor = Color.FromArgb(63, 63, 70);
            operatingCurrentProgress.Hover = false;
            operatingCurrentProgress.Location = new Point(787, 663);
            operatingCurrentProgress.Name = "operatingCurrentProgress";
            operatingCurrentProgress.Progress = 50;
            operatingCurrentProgress.Size = new Size(116, 23);
            operatingCurrentProgress.TabIndex = 27;
            operatingCurrentProgress.Text = "lostProgressBar1";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(787, 532);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(114, 125);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 26;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = SystemColors.ActiveCaption;
            pictureBox4.Location = new Point(765, 146);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(136, 333);
            pictureBox4.TabIndex = 28;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.ActiveCaption;
            pictureBox5.Location = new Point(330, 146);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(136, 171);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // bigLabel1
            // 
            bigLabel1.BackColor = SystemColors.ActiveCaption;
            bigLabel1.Font = new Font("Segoe UI", 25F);
            bigLabel1.ForeColor = Color.White;
            bigLabel1.Location = new Point(787, 155);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(104, 49);
            bigLabel1.TabIndex = 30;
            bigLabel1.Text = "NEXT";
            // 
            // bigLabel2
            // 
            bigLabel2.BackColor = SystemColors.ActiveCaption;
            bigLabel2.Font = new Font("Segoe UI", 25F);
            bigLabel2.ForeColor = Color.White;
            bigLabel2.Location = new Point(340, 155);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(113, 49);
            bigLabel2.TabIndex = 31;
            bigLabel2.Text = "HOLD";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(787, 207);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(91, 94);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 32;
            pictureBox6.TabStop = false;
            // 
            // bigLabel3
            // 
            bigLabel3.BackColor = Color.Transparent;
            bigLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel3.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel3.Location = new Point(849, 277);
            bigLabel3.Name = "bigLabel3";
            bigLabel3.Size = new Size(29, 24);
            bigLabel3.TabIndex = 33;
            bigLabel3.Text = "10";
            // 
            // bigLabel4
            // 
            bigLabel4.BackColor = Color.Transparent;
            bigLabel4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel4.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel4.Location = new Point(849, 392);
            bigLabel4.Name = "bigLabel4";
            bigLabel4.Size = new Size(29, 24);
            bigLabel4.TabIndex = 35;
            bigLabel4.Text = "15";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(787, 322);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(91, 94);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 34;
            pictureBox7.TabStop = false;
            // 
            // lostProgressBar1
            // 
            lostProgressBar1.BackColor = Color.FromArgb(45, 45, 48);
            lostProgressBar1.Color = Color.DodgerBlue;
            lostProgressBar1.ForeColor = Color.FromArgb(63, 63, 70);
            lostProgressBar1.Hover = false;
            lostProgressBar1.Location = new Point(0, 36);
            lostProgressBar1.Name = "lostProgressBar1";
            lostProgressBar1.Progress = 50;
            lostProgressBar1.Size = new Size(1280, 23);
            lostProgressBar1.TabIndex = 36;
            lostProgressBar1.Text = "lostProgressBar1";
            // 
            // bigLabel5
            // 
            bigLabel5.BackColor = Color.Transparent;
            bigLabel5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel5.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel5.Location = new Point(412, 277);
            bigLabel5.Name = "bigLabel5";
            bigLabel5.Size = new Size(29, 24);
            bigLabel5.TabIndex = 38;
            bigLabel5.Text = "5";
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(350, 207);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(91, 94);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 37;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Anchor = AnchorStyles.None;
            pictureBox9.BackgroundImage = (Image)resources.GetObject("pictureBox9.BackgroundImage");
            pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox9.Location = new Point(12, 65);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(59, 57);
            pictureBox9.TabIndex = 41;
            pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Anchor = AnchorStyles.None;
            pictureBox10.BackgroundImage = (Image)resources.GetObject("pictureBox10.BackgroundImage");
            pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox10.Location = new Point(77, 65);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(69, 57);
            pictureBox10.TabIndex = 39;
            pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            pictureBox11.Anchor = AnchorStyles.None;
            pictureBox11.BackgroundImage = (Image)resources.GetObject("pictureBox11.BackgroundImage");
            pictureBox11.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox11.Location = new Point(152, 65);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(63, 57);
            pictureBox11.TabIndex = 40;
            pictureBox11.TabStop = false;
            // 
            // bigLabel7
            // 
            bigLabel7.BackColor = SystemColors.ActiveCaption;
            bigLabel7.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel7.ForeColor = Color.White;
            bigLabel7.Location = new Point(12, 125);
            bigLabel7.Name = "bigLabel7";
            bigLabel7.Size = new Size(59, 37);
            bigLabel7.TabIndex = 43;
            bigLabel7.Text = "00";
            bigLabel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bigLabel6
            // 
            bigLabel6.BackColor = SystemColors.ActiveCaption;
            bigLabel6.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel6.ForeColor = Color.White;
            bigLabel6.Location = new Point(77, 125);
            bigLabel6.Name = "bigLabel6";
            bigLabel6.Size = new Size(69, 37);
            bigLabel6.TabIndex = 44;
            bigLabel6.Text = "00";
            bigLabel6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bigLabel8
            // 
            bigLabel8.BackColor = SystemColors.ActiveCaption;
            bigLabel8.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel8.ForeColor = Color.White;
            bigLabel8.Location = new Point(152, 125);
            bigLabel8.Name = "bigLabel8";
            bigLabel8.Size = new Size(63, 37);
            bigLabel8.TabIndex = 45;
            bigLabel8.Text = "00";
            bigLabel8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox12
            // 
            pictureBox12.Anchor = AnchorStyles.None;
            pictureBox12.BackColor = Color.AliceBlue;
            pictureBox12.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox12.Image = (Image)resources.GetObject("pictureBox12.Image");
            pictureBox12.Location = new Point(1223, 65);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(45, 40);
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox12.TabIndex = 46;
            pictureBox12.TabStop = false;
            // 
            // MainGamePrototype
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pictureBox12);
            Controls.Add(bigLabel8);
            Controls.Add(bigLabel6);
            Controls.Add(bigLabel7);
            Controls.Add(pictureBox9);
            Controls.Add(pictureBox10);
            Controls.Add(pictureBox11);
            Controls.Add(bigLabel5);
            Controls.Add(pictureBox8);
            Controls.Add(lostProgressBar1);
            Controls.Add(bigLabel4);
            Controls.Add(pictureBox7);
            Controls.Add(bigLabel3);
            Controls.Add(pictureBox6);
            Controls.Add(bigLabel2);
            Controls.Add(bigLabel1);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(operatingCurrentProgress);
            Controls.Add(pictureBox3);
            Controls.Add(circuitBlock4);
            Controls.Add(circuitBlock3);
            Controls.Add(circuitBlock2);
            Controls.Add(circuitBlock1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(gameCanvas);
            Controls.Add(hopeForm1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "MainGamePrototype";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainGamePrototype";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private GameCanvas gameCanvas;
        private CircuitBlock circuitBlock1;
        private CircuitBlock circuitBlock2;
        private CircuitBlock circuitBlock3;
        private CircuitBlock circuitBlock4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.LostProgressBar operatingCurrentProgress;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private PictureBox pictureBox6;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.BigLabel bigLabel4;
        private PictureBox pictureBox7;
        private ReaLTaiizor.Controls.LostProgressBar lostProgressBar1;
        private ReaLTaiizor.Controls.BigLabel bigLabel5;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private ReaLTaiizor.Controls.BigLabel bigLabel7;
        private ReaLTaiizor.Controls.BigLabel bigLabel6;
        private ReaLTaiizor.Controls.BigLabel bigLabel8;
        private PictureBox pictureBox12;
    }
}