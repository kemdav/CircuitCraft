// Add these using directives if not already present
using System.Windows.Forms;
using System.Drawing;
using ReaLTaiizor.Controls; // Assuming these are the namespaces
using ReaLTaiizor.Forms;
using CircuitCraft; // Your project's namespace

namespace CircuitCraft // Ensure this namespace matches your project
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
                // Dispose custom GDI resources if you created any (like Brushes)
                // particleBrush?.Dispose();
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
            pnlTopBar = new System.Windows.Forms.Panel();
            mainMenuButton = new PictureBox();
            restartButton = new PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox2 = new PictureBox();
            jouleCurrencyLabel = new BigLabel();
            pauseResumeButton = new PictureBox();
            lblTime = new BigLabel();
            lblLevel = new BigLabel();
            lblRating = new BigLabel();
            pnlHoldArea = new System.Windows.Forms.Panel();
            holdCooldownLabel = new BigLabel();
            holdCooldownProgressBar = new LostProgressBar();
            panelVoltageArea = new System.Windows.Forms.Panel();
            initialVoltageSourceLabel = new BigLabel();
            pictureBox1 = new PictureBox();
            pnlHoldElementContainer = new System.Windows.Forms.Panel();
            lblHoldElementValue = new BigLabel();
            picHoldElement = new PictureBox();
            lblHoldTitle = new BigLabel();
            pnlNextArea = new System.Windows.Forms.Panel();
            nextComponentProgressBar = new LostProgressBar();
            pnlNextElement2Container = new System.Windows.Forms.Panel();
            lblNextElementValue2 = new BigLabel();
            picNextElement2 = new PictureBox();
            pnlNextElement1Container = new System.Windows.Forms.Panel();
            lblNextElementValue1 = new BigLabel();
            picNextElement1 = new PictureBox();
            lblNextTitle = new BigLabel();
            pnlBottomStatus = new System.Windows.Forms.Panel();
            warningTimerLabel = new BigLabel();
            operatingCurrentProgressBar = new VerticalProgressBar();
            lblMaxThreshold = new BigLabel();
            lblMinThreshold = new BigLabel();
            progressBarWarningLow = new LostProgressBar();
            progressBarWarningHigh = new LostProgressBar();
            lblCurrentValue = new BigLabel();
            picLedStatus = new PictureBox();
            panelGameCanvasContainer = new System.Windows.Forms.Panel();
            gameMessageLabel = new BigLabel();
            gameCanvas = new GameCanvas();
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainMenuButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)restartButton).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pauseResumeButton).BeginInit();
            pnlHoldArea.SuspendLayout();
            panelVoltageArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlHoldElementContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHoldElement).BeginInit();
            pnlNextArea.SuspendLayout();
            pnlNextElement2Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNextElement2).BeginInit();
            pnlNextElement1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNextElement1).BeginInit();
            pnlBottomStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLedStatus).BeginInit();
            panelGameCanvasContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(218, 225, 232);
            pnlTopBar.Controls.Add(mainMenuButton);
            pnlTopBar.Controls.Add(restartButton);
            pnlTopBar.Controls.Add(panel1);
            pnlTopBar.Controls.Add(pauseResumeButton);
            pnlTopBar.Controls.Add(lblTime);
            pnlTopBar.Controls.Add(lblLevel);
            pnlTopBar.Controls.Add(lblRating);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1920, 55);
            pnlTopBar.TabIndex = 1;
            // 
            // mainMenuButton
            // 
            mainMenuButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mainMenuButton.BackColor = Color.Transparent;
            mainMenuButton.Cursor = Cursors.Hand;
            mainMenuButton.Image = (Image)resources.GetObject("mainMenuButton.Image");
            mainMenuButton.Location = new Point(1771, 9);
            mainMenuButton.Name = "mainMenuButton";
            mainMenuButton.Size = new Size(40, 40);
            mainMenuButton.SizeMode = PictureBoxSizeMode.Zoom;
            mainMenuButton.TabIndex = 50;
            mainMenuButton.TabStop = false;
            mainMenuButton.Click += mainMenuButton_Click;
            // 
            // restartButton
            // 
            restartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            restartButton.BackColor = Color.Transparent;
            restartButton.Cursor = Cursors.Hand;
            restartButton.Image = (Image)resources.GetObject("restartButton.Image");
            restartButton.Location = new Point(1817, 9);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(40, 40);
            restartButton.SizeMode = PictureBoxSizeMode.Zoom;
            restartButton.TabIndex = 49;
            restartButton.TabStop = false;
            restartButton.Click += restartButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(jouleCurrencyLabel);
            panel1.Location = new Point(868, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(182, 51);
            panel1.TabIndex = 48;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 47);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // jouleCurrencyLabel
            // 
            jouleCurrencyLabel.Anchor = AnchorStyles.Top;
            jouleCurrencyLabel.AutoSize = true;
            jouleCurrencyLabel.BackColor = Color.Transparent;
            jouleCurrencyLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jouleCurrencyLabel.ForeColor = Color.FromArgb(80, 80, 80);
            jouleCurrencyLabel.Location = new Point(62, 12);
            jouleCurrencyLabel.Name = "jouleCurrencyLabel";
            jouleCurrencyLabel.Size = new Size(23, 25);
            jouleCurrencyLabel.TabIndex = 47;
            jouleCurrencyLabel.Text = "0";
            jouleCurrencyLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pauseResumeButton
            // 
            pauseResumeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pauseResumeButton.BackColor = Color.Transparent;
            pauseResumeButton.Cursor = Cursors.Hand;
            pauseResumeButton.Image = (Image)resources.GetObject("pauseResumeButton.Image");
            pauseResumeButton.Location = new Point(1863, 9);
            pauseResumeButton.Name = "pauseResumeButton";
            pauseResumeButton.Size = new Size(40, 40);
            pauseResumeButton.SizeMode = PictureBoxSizeMode.Zoom;
            pauseResumeButton.TabIndex = 46;
            pauseResumeButton.TabStop = false;
            pauseResumeButton.Click += pauseResumeButton_Click;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top;
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(80, 80, 80);
            lblTime.Location = new Point(1567, 15);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(150, 25);
            lblTime.TabIndex = 2;
            lblTime.Text = "Time Left: 1:30 s";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lblLevel.ForeColor = Color.FromArgb(80, 80, 80);
            lblLevel.Location = new Point(187, 15);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(74, 25);
            lblLevel.TabIndex = 1;
            lblLevel.Text = "Level: 1";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.BackColor = Color.Transparent;
            lblRating.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lblRating.ForeColor = Color.FromArgb(80, 80, 80);
            lblRating.Location = new Point(12, 15);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(89, 25);
            lblRating.TabIndex = 0;
            lblRating.Text = "Rating: 0";
            // 
            // pnlHoldArea
            // 
            pnlHoldArea.BackColor = Color.FromArgb(208, 215, 222);
            pnlHoldArea.Controls.Add(holdCooldownLabel);
            pnlHoldArea.Controls.Add(holdCooldownProgressBar);
            pnlHoldArea.Controls.Add(panelVoltageArea);
            pnlHoldArea.Controls.Add(pnlHoldElementContainer);
            pnlHoldArea.Controls.Add(lblHoldTitle);
            pnlHoldArea.Dock = DockStyle.Left;
            pnlHoldArea.Location = new Point(0, 55);
            pnlHoldArea.MaximumSize = new Size(160, 0);
            pnlHoldArea.MinimumSize = new Size(160, 0);
            pnlHoldArea.Name = "pnlHoldArea";
            pnlHoldArea.Padding = new Padding(10);
            pnlHoldArea.Size = new Size(160, 887);
            pnlHoldArea.TabIndex = 2;
            // 
            // holdCooldownLabel
            // 
            holdCooldownLabel.BackColor = Color.Transparent;
            holdCooldownLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            holdCooldownLabel.ForeColor = Color.DarkGreen;
            holdCooldownLabel.Location = new Point(5, 221);
            holdCooldownLabel.Name = "holdCooldownLabel";
            holdCooldownLabel.Size = new Size(149, 32);
            holdCooldownLabel.TabIndex = 43;
            holdCooldownLabel.Text = "Ready!";
            holdCooldownLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // holdCooldownProgressBar
            // 
            holdCooldownProgressBar.BackColor = Color.FromArgb(45, 45, 48);
            holdCooldownProgressBar.Color = Color.DodgerBlue;
            holdCooldownProgressBar.ForeColor = Color.FromArgb(63, 63, 70);
            holdCooldownProgressBar.Hover = false;
            holdCooldownProgressBar.Location = new Point(13, 195);
            holdCooldownProgressBar.Name = "holdCooldownProgressBar";
            holdCooldownProgressBar.Progress = 100;
            holdCooldownProgressBar.Size = new Size(134, 23);
            holdCooldownProgressBar.TabIndex = 42;
            holdCooldownProgressBar.Text = "lostProgressBar1";
            // 
            // panelVoltageArea
            // 
            panelVoltageArea.BorderStyle = BorderStyle.FixedSingle;
            panelVoltageArea.Controls.Add(initialVoltageSourceLabel);
            panelVoltageArea.Controls.Add(pictureBox1);
            panelVoltageArea.Location = new Point(12, 715);
            panelVoltageArea.Name = "panelVoltageArea";
            panelVoltageArea.Size = new Size(135, 135);
            panelVoltageArea.TabIndex = 41;
            // 
            // initialVoltageSourceLabel
            // 
            initialVoltageSourceLabel.BackColor = Color.Transparent;
            initialVoltageSourceLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            initialVoltageSourceLabel.ForeColor = Color.FromArgb(80, 80, 80);
            initialVoltageSourceLabel.Location = new Point(8, 5);
            initialVoltageSourceLabel.Name = "initialVoltageSourceLabel";
            initialVoltageSourceLabel.Size = new Size(122, 24);
            initialVoltageSourceLabel.TabIndex = 39;
            initialVoltageSourceLabel.Text = "0 V";
            initialVoltageSourceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlHoldElementContainer
            // 
            pnlHoldElementContainer.BackColor = Color.FromArgb(240, 240, 240);
            pnlHoldElementContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlHoldElementContainer.Controls.Add(lblHoldElementValue);
            pnlHoldElementContainer.Controls.Add(picHoldElement);
            pnlHoldElementContainer.Location = new Point(15, 59);
            pnlHoldElementContainer.Name = "pnlHoldElementContainer";
            pnlHoldElementContainer.Size = new Size(130, 130);
            pnlHoldElementContainer.TabIndex = 39;
            // 
            // lblHoldElementValue
            // 
            lblHoldElementValue.BackColor = Color.Transparent;
            lblHoldElementValue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblHoldElementValue.ForeColor = Color.FromArgb(80, 80, 80);
            lblHoldElementValue.Location = new Point(3, 99);
            lblHoldElementValue.Name = "lblHoldElementValue";
            lblHoldElementValue.Size = new Size(122, 24);
            lblHoldElementValue.TabIndex = 38;
            lblHoldElementValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picHoldElement
            // 
            picHoldElement.BackColor = Color.Transparent;
            picHoldElement.Location = new Point(19, 3);
            picHoldElement.Name = "picHoldElement";
            picHoldElement.Size = new Size(91, 94);
            picHoldElement.SizeMode = PictureBoxSizeMode.Zoom;
            picHoldElement.TabIndex = 37;
            picHoldElement.TabStop = false;
            // 
            // lblHoldTitle
            // 
            lblHoldTitle.AutoSize = true;
            lblHoldTitle.BackColor = Color.Transparent;
            lblHoldTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoldTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblHoldTitle.Location = new Point(44, 10);
            lblHoldTitle.Name = "lblHoldTitle";
            lblHoldTitle.Size = new Size(71, 30);
            lblHoldTitle.TabIndex = 31;
            lblHoldTitle.Text = "HOLD";
            lblHoldTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNextArea
            // 
            pnlNextArea.BackColor = Color.FromArgb(208, 215, 222);
            pnlNextArea.Controls.Add(nextComponentProgressBar);
            pnlNextArea.Controls.Add(pnlNextElement2Container);
            pnlNextArea.Controls.Add(pnlNextElement1Container);
            pnlNextArea.Controls.Add(lblNextTitle);
            pnlNextArea.Dock = DockStyle.Right;
            pnlNextArea.Location = new Point(1760, 55);
            pnlNextArea.MaximumSize = new Size(160, 0);
            pnlNextArea.MinimumSize = new Size(160, 0);
            pnlNextArea.Name = "pnlNextArea";
            pnlNextArea.Padding = new Padding(10);
            pnlNextArea.Size = new Size(160, 887);
            pnlNextArea.TabIndex = 3;
            // 
            // nextComponentProgressBar
            // 
            nextComponentProgressBar.BackColor = Color.FromArgb(45, 45, 48);
            nextComponentProgressBar.Color = Color.DodgerBlue;
            nextComponentProgressBar.ForeColor = Color.FromArgb(63, 63, 70);
            nextComponentProgressBar.Hover = false;
            nextComponentProgressBar.Location = new Point(11, 43);
            nextComponentProgressBar.Name = "nextComponentProgressBar";
            nextComponentProgressBar.Progress = 0;
            nextComponentProgressBar.Size = new Size(134, 23);
            nextComponentProgressBar.TabIndex = 43;
            nextComponentProgressBar.Text = "lostProgressBar1";
            // 
            // pnlNextElement2Container
            // 
            pnlNextElement2Container.BackColor = Color.FromArgb(240, 240, 240);
            pnlNextElement2Container.BorderStyle = BorderStyle.FixedSingle;
            pnlNextElement2Container.Controls.Add(lblNextElementValue2);
            pnlNextElement2Container.Controls.Add(picNextElement2);
            pnlNextElement2Container.Location = new Point(13, 208);
            pnlNextElement2Container.Name = "pnlNextElement2Container";
            pnlNextElement2Container.Size = new Size(130, 130);
            pnlNextElement2Container.TabIndex = 41;
            // 
            // lblNextElementValue2
            // 
            lblNextElementValue2.BackColor = Color.Transparent;
            lblNextElementValue2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNextElementValue2.ForeColor = Color.FromArgb(80, 80, 80);
            lblNextElementValue2.Location = new Point(3, 99);
            lblNextElementValue2.Name = "lblNextElementValue2";
            lblNextElementValue2.Size = new Size(122, 24);
            lblNextElementValue2.TabIndex = 35;
            lblNextElementValue2.Text = "15 Ω";
            lblNextElementValue2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picNextElement2
            // 
            picNextElement2.BackColor = Color.Transparent;
            picNextElement2.Location = new Point(19, 3);
            picNextElement2.Name = "picNextElement2";
            picNextElement2.Size = new Size(91, 94);
            picNextElement2.SizeMode = PictureBoxSizeMode.Zoom;
            picNextElement2.TabIndex = 34;
            picNextElement2.TabStop = false;
            // 
            // pnlNextElement1Container
            // 
            pnlNextElement1Container.BackColor = Color.FromArgb(240, 240, 240);
            pnlNextElement1Container.BorderStyle = BorderStyle.FixedSingle;
            pnlNextElement1Container.Controls.Add(lblNextElementValue1);
            pnlNextElement1Container.Controls.Add(picNextElement1);
            pnlNextElement1Container.Location = new Point(13, 72);
            pnlNextElement1Container.Name = "pnlNextElement1Container";
            pnlNextElement1Container.Size = new Size(130, 130);
            pnlNextElement1Container.TabIndex = 40;
            // 
            // lblNextElementValue1
            // 
            lblNextElementValue1.BackColor = Color.Transparent;
            lblNextElementValue1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNextElementValue1.ForeColor = Color.FromArgb(80, 80, 80);
            lblNextElementValue1.Location = new Point(3, 99);
            lblNextElementValue1.Name = "lblNextElementValue1";
            lblNextElementValue1.Size = new Size(122, 24);
            lblNextElementValue1.TabIndex = 33;
            lblNextElementValue1.Text = "10 Ω";
            lblNextElementValue1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picNextElement1
            // 
            picNextElement1.BackColor = Color.Transparent;
            picNextElement1.Location = new Point(19, 3);
            picNextElement1.Name = "picNextElement1";
            picNextElement1.Size = new Size(91, 94);
            picNextElement1.SizeMode = PictureBoxSizeMode.Zoom;
            picNextElement1.TabIndex = 32;
            picNextElement1.TabStop = false;
            // 
            // lblNextTitle
            // 
            lblNextTitle.AutoSize = true;
            lblNextTitle.BackColor = Color.Transparent;
            lblNextTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblNextTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblNextTitle.Location = new Point(41, 10);
            lblNextTitle.Name = "lblNextTitle";
            lblNextTitle.Size = new Size(67, 30);
            lblNextTitle.TabIndex = 30;
            lblNextTitle.Text = "NEXT";
            lblNextTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBottomStatus
            // 
            pnlBottomStatus.BackColor = Color.FromArgb(64, 64, 64);
            pnlBottomStatus.Controls.Add(warningTimerLabel);
            pnlBottomStatus.Controls.Add(operatingCurrentProgressBar);
            pnlBottomStatus.Controls.Add(lblMaxThreshold);
            pnlBottomStatus.Controls.Add(lblMinThreshold);
            pnlBottomStatus.Controls.Add(progressBarWarningLow);
            pnlBottomStatus.Controls.Add(progressBarWarningHigh);
            pnlBottomStatus.Controls.Add(lblCurrentValue);
            pnlBottomStatus.Controls.Add(picLedStatus);
            pnlBottomStatus.Dock = DockStyle.Bottom;
            pnlBottomStatus.ForeColor = Color.White;
            pnlBottomStatus.Location = new Point(0, 942);
            pnlBottomStatus.Name = "pnlBottomStatus";
            pnlBottomStatus.Size = new Size(1920, 90);
            pnlBottomStatus.TabIndex = 4;
            // 
            // warningTimerLabel
            // 
            warningTimerLabel.BackColor = Color.Transparent;
            warningTimerLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            warningTimerLabel.ForeColor = Color.White;
            warningTimerLabel.Location = new Point(1249, 8);
            warningTimerLabel.Name = "warningTimerLabel";
            warningTimerLabel.Size = new Size(534, 73);
            warningTimerLabel.TabIndex = 33;
            warningTimerLabel.Text = "5";
            warningTimerLabel.TextAlign = ContentAlignment.MiddleCenter;
            warningTimerLabel.Visible = false;
            // 
            // operatingCurrentProgressBar
            // 
            operatingCurrentProgressBar.Anchor = AnchorStyles.Bottom;
            operatingCurrentProgressBar.Location = new Point(868, 26);
            operatingCurrentProgressBar.Name = "operatingCurrentProgressBar";
            operatingCurrentProgressBar.Size = new Size(47, 40);
            operatingCurrentProgressBar.Style = ProgressBarStyle.Continuous;
            operatingCurrentProgressBar.TabIndex = 32;
            operatingCurrentProgressBar.Value = 50;
            // 
            // lblMaxThreshold
            // 
            lblMaxThreshold.Anchor = AnchorStyles.Bottom;
            lblMaxThreshold.AutoSize = true;
            lblMaxThreshold.BackColor = Color.Transparent;
            lblMaxThreshold.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaxThreshold.ForeColor = Color.FromArgb(255, 128, 128);
            lblMaxThreshold.Location = new Point(868, 8);
            lblMaxThreshold.Name = "lblMaxThreshold";
            lblMaxThreshold.Size = new Size(49, 13);
            lblMaxThreshold.TabIndex = 31;
            lblMaxThreshold.Text = "MAX ----";
            // 
            // lblMinThreshold
            // 
            lblMinThreshold.Anchor = AnchorStyles.Bottom;
            lblMinThreshold.AutoSize = true;
            lblMinThreshold.BackColor = Color.Transparent;
            lblMinThreshold.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMinThreshold.ForeColor = Color.FromArgb(160, 192, 255);
            lblMinThreshold.Location = new Point(868, 69);
            lblMinThreshold.Name = "lblMinThreshold";
            lblMinThreshold.Size = new Size(47, 13);
            lblMinThreshold.TabIndex = 30;
            lblMinThreshold.Text = "MIN ----";
            // 
            // progressBarWarningLow
            // 
            progressBarWarningLow.Anchor = AnchorStyles.Bottom;
            progressBarWarningLow.BackColor = Color.FromArgb(45, 45, 48);
            progressBarWarningLow.Color = Color.SteelBlue;
            progressBarWarningLow.ForeColor = Color.FromArgb(63, 63, 70);
            progressBarWarningLow.Hover = false;
            progressBarWarningLow.Location = new Point(1089, 52);
            progressBarWarningLow.Name = "progressBarWarningLow";
            progressBarWarningLow.Progress = 0;
            progressBarWarningLow.Size = new Size(141, 12);
            progressBarWarningLow.TabIndex = 29;
            progressBarWarningLow.Text = "lowWarn";
            // 
            // progressBarWarningHigh
            // 
            progressBarWarningHigh.Anchor = AnchorStyles.Bottom;
            progressBarWarningHigh.BackColor = Color.FromArgb(45, 45, 48);
            progressBarWarningHigh.Color = Color.FromArgb(255, 128, 0);
            progressBarWarningHigh.ForeColor = Color.FromArgb(63, 63, 70);
            progressBarWarningHigh.Hover = false;
            progressBarWarningHigh.Location = new Point(1089, 24);
            progressBarWarningHigh.Name = "progressBarWarningHigh";
            progressBarWarningHigh.Progress = 0;
            progressBarWarningHigh.Size = new Size(141, 12);
            progressBarWarningHigh.TabIndex = 28;
            progressBarWarningHigh.Text = "highWarn";
            // 
            // lblCurrentValue
            // 
            lblCurrentValue.Anchor = AnchorStyles.Bottom;
            lblCurrentValue.BackColor = Color.Transparent;
            lblCurrentValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentValue.ForeColor = Color.White;
            lblCurrentValue.Location = new Point(928, 24);
            lblCurrentValue.Name = "lblCurrentValue";
            lblCurrentValue.Size = new Size(155, 40);
            lblCurrentValue.TabIndex = 1;
            lblCurrentValue.Text = "--- mA";
            lblCurrentValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLedStatus
            // 
            picLedStatus.Anchor = AnchorStyles.Bottom;
            picLedStatus.BackColor = Color.White;
            picLedStatus.Image = (Image)resources.GetObject("picLedStatus.Image");
            picLedStatus.Location = new Point(752, 8);
            picLedStatus.Name = "picLedStatus";
            picLedStatus.Size = new Size(74, 74);
            picLedStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picLedStatus.TabIndex = 26;
            picLedStatus.TabStop = false;
            // 
            // panelGameCanvasContainer
            // 
            panelGameCanvasContainer.BackColor = Color.FromArgb(40, 40, 40);
            panelGameCanvasContainer.BorderStyle = BorderStyle.Fixed3D;
            panelGameCanvasContainer.Controls.Add(gameMessageLabel);
            panelGameCanvasContainer.Controls.Add(gameCanvas);
            panelGameCanvasContainer.Dock = DockStyle.Fill;
            panelGameCanvasContainer.Location = new Point(160, 55);
            panelGameCanvasContainer.Name = "panelGameCanvasContainer";
            panelGameCanvasContainer.Padding = new Padding(5);
            panelGameCanvasContainer.Size = new Size(1600, 887);
            panelGameCanvasContainer.TabIndex = 5;
            // 
            // gameMessageLabel
            // 
            gameMessageLabel.Anchor = AnchorStyles.Top;
            gameMessageLabel.AutoSize = true;
            gameMessageLabel.BackColor = Color.Black;
            gameMessageLabel.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameMessageLabel.ForeColor = Color.White;
            gameMessageLabel.Location = new Point(590, 57);
            gameMessageLabel.Name = "gameMessageLabel";
            gameMessageLabel.Size = new Size(495, 128);
            gameMessageLabel.TabIndex = 6;
            gameMessageLabel.Text = "bigLabel1";
            gameMessageLabel.Visible = false;
            // 
            // gameCanvas
            // 
            gameCanvas.BackColor = Color.WhiteSmoke;
            gameCanvas.CircuitBlock = null;
            gameCanvas.CircuitElement = null;
            gameCanvas.CircuitElementDiodeSprite = (Image)resources.GetObject("gameCanvas.CircuitElementDiodeSprite");
            gameCanvas.CircuitElementOffset = 0;
            gameCanvas.CircuitElementResistorSprite1 = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite1");
            gameCanvas.CircuitElementResistorSprite2 = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite2");
            gameCanvas.CircuitElementResistorSprite3 = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite3");
            gameCanvas.CircuitElementResistorSprite4 = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite4");
            gameCanvas.CircuitElementResistorSprite5 = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite5");
            gameCanvas.CircuitElementSourceSprite1 = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite1");
            gameCanvas.CircuitElementSourceSprite2 = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite2");
            gameCanvas.CircuitElementSourceSprite3 = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite3");
            gameCanvas.CircuitElementSourceSprite4 = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite4");
            gameCanvas.CircuitElementSourceSprite5 = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite5");
            gameCanvas.CircuitSources = null;
            gameCanvas.CurrentBlockIndex = -1;
            gameCanvas.CurrentCircuitElementDropped = null;
            gameCanvas.CurrentCircuitElementDroppedOrientation = 0;
            gameCanvas.CurrentCircuitElementDroppedResistance = 0D;
            gameCanvas.CurrentCircuitElementDroppedType = CircuitElementType.Source;
            gameCanvas.CurrentCircuitElementDroppedVoltage = 0D;
            gameCanvas.CurrentLevel = 1;
            gameCanvas.CurrentValueLabel = lblCurrentValue;
            gameCanvas.DiodeIncreaseChanceCardCost = 0;
            gameCanvas.DiodeIncreaseChanceCardDescription = "Increase Diode Spawn Rate by 10%";
            gameCanvas.DiodeIncreaseChanceCardImage = (Image)resources.GetObject("gameCanvas.DiodeIncreaseChanceCardImage");
            gameCanvas.Dock = DockStyle.Fill;
            gameCanvas.GameMessageLabel = gameMessageLabel;
            gameCanvas.GameOverPrompt = null;
            gameCanvas.GameState = GameState.BranchUnlocking;
            gameCanvas.HoldComponentLabel = lblHoldElementValue;
            gameCanvas.HoldComponentPbox = picHoldElement;
            gameCanvas.HoldCooldownLabel = holdCooldownLabel;
            gameCanvas.HoldCooldownProgressbar = holdCooldownProgressBar;
            gameCanvas.IncreaseInitialVoltageCardCost = 0;
            gameCanvas.IncreaseInitialVoltageCardDescription = "Increase Initial Voltage by 1V";
            gameCanvas.IncreaseInitialVoltageCardImage = (Image)resources.GetObject("gameCanvas.IncreaseInitialVoltageCardImage");
            gameCanvas.InitialVoltageValueLabel = initialVoltageSourceLabel;
            gameCanvas.JouleCurrency = 0;
            gameCanvas.JouleCurrencyLabel = jouleCurrencyLabel;
            gameCanvas.LedBurnedCount = 0;
            gameCanvas.LevelLabel = lblLevel;
            gameCanvas.Location = new Point(5, 5);
            gameCanvas.LockedCircuitBlockImage = (Image)resources.GetObject("gameCanvas.LockedCircuitBlockImage");
            gameCanvas.MainGame = null;
            gameCanvas.MainGamePrototype = null;
            gameCanvas.MaintainTimerLabel = lblTime;
            gameCanvas.MinimumOperatingCurrent = 0D;
            gameCanvas.MinimumOperatingCurrentTick = 0;
            gameCanvas.Name = "gameCanvas";
            gameCanvas.NextComponentLabel1 = lblNextElementValue1;
            gameCanvas.NextComponentLabel2 = lblNextElementValue2;
            gameCanvas.NextComponentPictureBox1 = picNextElement1;
            gameCanvas.NextComponentPictureBox2 = picNextElement2;
            gameCanvas.NextComponentProgressbar = nextComponentProgressBar;
            gameCanvas.OperatingCurrent = 0D;
            gameCanvas.OperatingCurrentMaxLabel = lblMaxThreshold;
            gameCanvas.OperatingCurrentMinLabel = lblMinThreshold;
            gameCanvas.OperatingCurrentProgressBar = operatingCurrentProgressBar;
            gameCanvas.OperatingCurrentTick = 0;
            gameCanvas.ParallelCircuitBlockCardCost = 10;
            gameCanvas.ParallelCircuitBlockCardDescription = "Unlock a Parallel Circuit Branch";
            gameCanvas.ParallelCircuitBlockCardImage = (Image)resources.GetObject("gameCanvas.ParallelCircuitBlockCardImage");
            gameCanvas.ParallelCircuitBlockImage = (Image)resources.GetObject("gameCanvas.ParallelCircuitBlockImage");
            gameCanvas.PauseButtonImage = (Image)resources.GetObject("gameCanvas.PauseButtonImage");
            gameCanvas.PlayButtonImage = (Image)resources.GetObject("gameCanvas.PlayButtonImage");
            gameCanvas.RatingLabel = lblRating;
            gameCanvas.ResistanceValueMultiplier = 2D;
            gameCanvas.ResistorIncreaseChanceCardCost = 0;
            gameCanvas.ResistorIncreaseChanceCardDescription = "Increase Resistor Spawn Rate by 10%";
            gameCanvas.ResistorIncreaseChanceCardImage = (Image)resources.GetObject("gameCanvas.ResistorIncreaseChanceCardImage");
            gameCanvas.SeriesCircuitBlockCardCost = 10;
            gameCanvas.SeriesCircuitBlockCardDescription = "Unlock a Series Circuit Branch";
            gameCanvas.SeriesCircuitBlockCardImage = (Image)resources.GetObject("gameCanvas.SeriesCircuitBlockCardImage");
            gameCanvas.SeriesCircuitBlockImage = (Image)resources.GetObject("gameCanvas.SeriesCircuitBlockImage");
            gameCanvas.ShowChoicesPrompt = null;
            gameCanvas.Size = new Size(1586, 873);
            gameCanvas.SourceIncreaseChanceCardCost = 0;
            gameCanvas.SourceIncreaseChanceCardDescription = "Increase Battery Spawn Rate by 10%";
            gameCanvas.SourceIncreaseChanceCardImage = (Image)resources.GetObject("gameCanvas.SourceIncreaseChanceCardImage");
            gameCanvas.SourceValueMultiplier = 0.2D;
            gameCanvas.SourceVoltage = 0D;
            gameCanvas.TabIndex = 1;
            gameCanvas.timeLeftToMaintainInSeconds = 60;
            gameCanvas.TrashCircuitBlockCardCost = 10;
            gameCanvas.TrashCircuitBlockCardDescription = "Unlock a Disposable Circuit Branch";
            gameCanvas.TrashCircuitBlockCardImage = (Image)resources.GetObject("gameCanvas.TrashCircuitBlockCardImage");
            gameCanvas.TrashCircuitBlockImage = (Image)resources.GetObject("gameCanvas.TrashCircuitBlockImage");
            gameCanvas.WarningHighProgressBar = progressBarWarningHigh;
            gameCanvas.WarningLowProgressBar = progressBarWarningLow;
            gameCanvas.WarningTimerLabel = warningTimerLabel;
            gameCanvas.WillUseHoldCircuitElement = false;
            gameCanvas.Load += gameCanvas_Load;
            // 
            // MainGamePrototype
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 240, 245);
            ClientSize = new Size(1920, 1032);
            Controls.Add(panelGameCanvasContainer);
            Controls.Add(pnlNextArea);
            Controls.Add(pnlHoldArea);
            Controls.Add(pnlBottomStatus);
            Controls.Add(pnlTopBar);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "MainGamePrototype";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CircuitCraft";
            Shown += MainGamePrototype_Shown;
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainMenuButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)restartButton).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pauseResumeButton).EndInit();
            pnlHoldArea.ResumeLayout(false);
            pnlHoldArea.PerformLayout();
            panelVoltageArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlHoldElementContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHoldElement).EndInit();
            pnlNextArea.ResumeLayout(false);
            pnlNextArea.PerformLayout();
            pnlNextElement2Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNextElement2).EndInit();
            pnlNextElement1Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNextElement1).EndInit();
            pnlBottomStatus.ResumeLayout(false);
            pnlBottomStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLedStatus).EndInit();
            panelGameCanvasContainer.ResumeLayout(false);
            panelGameCanvasContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlTopBar;
        private ReaLTaiizor.Controls.BigLabel lblRating;
        private ReaLTaiizor.Controls.BigLabel lblLevel;
        private ReaLTaiizor.Controls.BigLabel lblTime;
        private System.Windows.Forms.PictureBox pauseResumeButton;
        private System.Windows.Forms.Panel pnlHoldArea;
        private System.Windows.Forms.Panel pnlNextArea;
        private System.Windows.Forms.Panel pnlBottomStatus;
        private System.Windows.Forms.Panel panelGameCanvasContainer;
        private GameCanvas gameCanvas; // Your main game canvas
        private ReaLTaiizor.Controls.BigLabel lblHoldTitle;
        private System.Windows.Forms.Panel pnlHoldElementContainer;
        private ReaLTaiizor.Controls.BigLabel lblHoldElementValue;
        private System.Windows.Forms.PictureBox picHoldElement;
        private System.Windows.Forms.Panel pnlNextElement2Container;
        private ReaLTaiizor.Controls.BigLabel lblNextElementValue2;
        private System.Windows.Forms.PictureBox picNextElement2;
        private System.Windows.Forms.Panel pnlNextElement1Container;
        private ReaLTaiizor.Controls.BigLabel lblNextElementValue1;
        private System.Windows.Forms.PictureBox picNextElement1;
        private ReaLTaiizor.Controls.BigLabel lblNextTitle;
        private System.Windows.Forms.PictureBox picLedStatus;
        private ReaLTaiizor.Controls.BigLabel lblCurrentValue;
        private ReaLTaiizor.Controls.LostProgressBar progressBarWarningLow;
        private ReaLTaiizor.Controls.LostProgressBar progressBarWarningHigh;
        private BigLabel lblMaxThreshold;
        private BigLabel lblMinThreshold;
        private VerticalProgressBar operatingCurrentProgressBar;
        private System.Windows.Forms.Panel panelVoltageArea;
        private BigLabel initialVoltageSourceLabel;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private BigLabel jouleCurrencyLabel;
        private PictureBox pictureBox2;
        private BigLabel holdCooldownLabel;
        private LostProgressBar holdCooldownProgressBar;
        private LostProgressBar nextComponentProgressBar;
        private BigLabel gameMessageLabel;
        private BigLabel warningTimerLabel;
        private PictureBox restartButton;
        private PictureBox mainMenuButton;
    }
}