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
            hopeForm1 = new HopeForm();
            pnlTopBar = new System.Windows.Forms.Panel();
            picPauseButton = new PictureBox();
            lblTime = new BigLabel();
            lblLevel = new BigLabel();
            lblScore = new BigLabel();
            pnlHoldArea = new System.Windows.Forms.Panel();
            btnRemoveComponent = new System.Windows.Forms.Button();
            pnlHoldElementContainer = new System.Windows.Forms.Panel();
            lblHoldElementValue = new BigLabel();
            picHoldElement = new PictureBox();
            lblHoldTitle = new BigLabel();
            pnlNextArea = new System.Windows.Forms.Panel();
            pnlNextElement2Container = new System.Windows.Forms.Panel();
            lblNextElementValue2 = new BigLabel();
            picNextElement2 = new PictureBox();
            pnlNextElement1Container = new System.Windows.Forms.Panel();
            lblNextElementValue1 = new BigLabel();
            picNextElement1 = new PictureBox();
            lblNextTitle = new BigLabel();
            pnlBottomStatus = new System.Windows.Forms.Panel();
            operatingCurrentProgressBar = new VerticalProgressBar();
            lblMaxThreshold = new BigLabel();
            lblMinThreshold = new BigLabel();
            progressBarWarningLow = new LostProgressBar();
            progressBarWarningHigh = new LostProgressBar();
            lblCurrentValue = new BigLabel();
            picLedStatus = new PictureBox();
            panelGameCanvasContainer = new System.Windows.Forms.Panel();
            gameCanvas = new GameCanvas();
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPauseButton).BeginInit();
            pnlHoldArea.SuspendLayout();
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
            hopeForm1.Size = new Size(1008, 40);
            hopeForm1.TabIndex = 0;
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(218, 225, 232);
            pnlTopBar.Controls.Add(picPauseButton);
            pnlTopBar.Controls.Add(lblTime);
            pnlTopBar.Controls.Add(lblLevel);
            pnlTopBar.Controls.Add(lblScore);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 40);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1008, 55);
            pnlTopBar.TabIndex = 1;
            // 
            // picPauseButton
            // 
            picPauseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picPauseButton.BackColor = Color.Transparent;
            picPauseButton.Cursor = Cursors.Hand;
            picPauseButton.Image = (Image)resources.GetObject("picPauseButton.Image");
            picPauseButton.Location = new Point(951, 8);
            picPauseButton.Name = "picPauseButton";
            picPauseButton.Size = new Size(40, 40);
            picPauseButton.SizeMode = PictureBoxSizeMode.Zoom;
            picPauseButton.TabIndex = 46;
            picPauseButton.TabStop = false;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top;
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(80, 80, 80);
            lblTime.Location = new Point(456, 15);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(99, 25);
            lblTime.TabIndex = 2;
            lblTime.Text = "Time: 1:30";
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
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lblScore.ForeColor = Color.FromArgb(80, 80, 80);
            lblScore.Location = new Point(12, 15);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(80, 25);
            lblScore.TabIndex = 0;
            lblScore.Text = "Score: 0";
            // 
            // pnlHoldArea
            // 
            pnlHoldArea.BackColor = Color.FromArgb(208, 215, 222);
            pnlHoldArea.Controls.Add(btnRemoveComponent);
            pnlHoldArea.Controls.Add(pnlHoldElementContainer);
            pnlHoldArea.Controls.Add(lblHoldTitle);
            pnlHoldArea.Dock = DockStyle.Left;
            pnlHoldArea.Location = new Point(0, 95);
            pnlHoldArea.MaximumSize = new Size(160, 0);
            pnlHoldArea.MinimumSize = new Size(160, 0);
            pnlHoldArea.Name = "pnlHoldArea";
            pnlHoldArea.Padding = new Padding(10);
            pnlHoldArea.Size = new Size(160, 535);
            pnlHoldArea.TabIndex = 2;
            // 
            // btnRemoveComponent
            // 
            btnRemoveComponent.BackColor = Color.FromArgb(255, 192, 192);
            btnRemoveComponent.FlatStyle = FlatStyle.Flat;
            btnRemoveComponent.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveComponent.ForeColor = Color.FromArgb(192, 0, 0);
            btnRemoveComponent.Location = new Point(18, 233);
            btnRemoveComponent.Name = "btnRemoveComponent";
            btnRemoveComponent.Size = new Size(124, 40);
            btnRemoveComponent.TabIndex = 40;
            btnRemoveComponent.Text = "Remove Mode";
            btnRemoveComponent.UseVisualStyleBackColor = false;
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
            lblHoldElementValue.Text = "5 Ω";
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
            pnlNextArea.Controls.Add(pnlNextElement2Container);
            pnlNextArea.Controls.Add(pnlNextElement1Container);
            pnlNextArea.Controls.Add(lblNextTitle);
            pnlNextArea.Dock = DockStyle.Right;
            pnlNextArea.Location = new Point(848, 95);
            pnlNextArea.MaximumSize = new Size(160, 0);
            pnlNextArea.MinimumSize = new Size(160, 0);
            pnlNextArea.Name = "pnlNextArea";
            pnlNextArea.Padding = new Padding(10);
            pnlNextArea.Size = new Size(160, 535);
            pnlNextArea.TabIndex = 3;
            // 
            // pnlNextElement2Container
            // 
            pnlNextElement2Container.BackColor = Color.FromArgb(240, 240, 240);
            pnlNextElement2Container.BorderStyle = BorderStyle.FixedSingle;
            pnlNextElement2Container.Controls.Add(lblNextElementValue2);
            pnlNextElement2Container.Controls.Add(picNextElement2);
            pnlNextElement2Container.Location = new Point(15, 195);
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
            pnlNextElement1Container.Location = new Point(15, 59);
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
            pnlBottomStatus.Controls.Add(operatingCurrentProgressBar);
            pnlBottomStatus.Controls.Add(lblMaxThreshold);
            pnlBottomStatus.Controls.Add(lblMinThreshold);
            pnlBottomStatus.Controls.Add(progressBarWarningLow);
            pnlBottomStatus.Controls.Add(progressBarWarningHigh);
            pnlBottomStatus.Controls.Add(lblCurrentValue);
            pnlBottomStatus.Controls.Add(picLedStatus);
            pnlBottomStatus.Dock = DockStyle.Bottom;
            pnlBottomStatus.ForeColor = Color.White;
            pnlBottomStatus.Location = new Point(0, 630);
            pnlBottomStatus.Name = "pnlBottomStatus";
            pnlBottomStatus.Size = new Size(1008, 90);
            pnlBottomStatus.TabIndex = 4;
            // 
            // operatingCurrentProgressBar
            // 
            operatingCurrentProgressBar.Location = new Point(412, 24);
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
            lblMaxThreshold.Location = new Point(412, 8);
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
            lblMinThreshold.Location = new Point(412, 69);
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
            progressBarWarningLow.Location = new Point(603, 55);
            progressBarWarningLow.Name = "progressBarWarningLow";
            progressBarWarningLow.Progress = 0;
            progressBarWarningLow.Size = new Size(141, 12);
            progressBarWarningLow.TabIndex = 29;
            progressBarWarningLow.Text = "lowWarn";
            progressBarWarningLow.Visible = false;
            // 
            // progressBarWarningHigh
            // 
            progressBarWarningHigh.Anchor = AnchorStyles.Bottom;
            progressBarWarningHigh.BackColor = Color.FromArgb(45, 45, 48);
            progressBarWarningHigh.Color = Color.FromArgb(255, 128, 0);
            progressBarWarningHigh.ForeColor = Color.FromArgb(63, 63, 70);
            progressBarWarningHigh.Hover = false;
            progressBarWarningHigh.Location = new Point(603, 21);
            progressBarWarningHigh.Name = "progressBarWarningHigh";
            progressBarWarningHigh.Progress = 0;
            progressBarWarningHigh.Size = new Size(141, 12);
            progressBarWarningHigh.TabIndex = 28;
            progressBarWarningHigh.Text = "highWarn";
            progressBarWarningHigh.Visible = false;
            // 
            // lblCurrentValue
            // 
            lblCurrentValue.Anchor = AnchorStyles.Bottom;
            lblCurrentValue.BackColor = Color.Transparent;
            lblCurrentValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentValue.ForeColor = Color.White;
            lblCurrentValue.Location = new Point(472, 24);
            lblCurrentValue.Name = "lblCurrentValue";
            lblCurrentValue.Size = new Size(125, 40);
            lblCurrentValue.TabIndex = 1;
            lblCurrentValue.Text = "--- mA";
            lblCurrentValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLedStatus
            // 
            picLedStatus.Anchor = AnchorStyles.Bottom;
            picLedStatus.Location = new Point(296, 8);
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
            panelGameCanvasContainer.Controls.Add(gameCanvas);
            panelGameCanvasContainer.Dock = DockStyle.Fill;
            panelGameCanvasContainer.Location = new Point(160, 95);
            panelGameCanvasContainer.Name = "panelGameCanvasContainer";
            panelGameCanvasContainer.Padding = new Padding(5);
            panelGameCanvasContainer.Size = new Size(688, 535);
            panelGameCanvasContainer.TabIndex = 5;
            // 
            // gameCanvas
            // 
            gameCanvas.BackColor = Color.WhiteSmoke;
            gameCanvas.CircuitBlock = null;
            gameCanvas.CircuitElement = null;
            gameCanvas.CircuitElementDiodeSprite = (Image)resources.GetObject("gameCanvas.CircuitElementDiodeSprite");
            gameCanvas.CircuitElementOffset = 0;
            gameCanvas.CircuitElementResistorSprite = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite");
            gameCanvas.CircuitElementSourceSprite = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite");
            gameCanvas.CircuitSources = null;
            gameCanvas.CurrentBlockIndex = -1;
            gameCanvas.CurrentCircuitElementDropped = null;
            gameCanvas.CurrentCircuitElementDroppedOrientation = 0;
            gameCanvas.CurrentCircuitElementDroppedResistance = 0D;
            gameCanvas.CurrentCircuitElementDroppedType = CircuitElementType.Source;
            gameCanvas.CurrentCircuitElementDroppedVoltage = 0D;
            gameCanvas.Dock = DockStyle.Fill;
            gameCanvas.Location = new Point(5, 5);
            gameCanvas.MainGame = null;
            gameCanvas.MinimumOperatingCurrent = 0D;
            gameCanvas.MinimumOperatingCurrentTick = 0;
            gameCanvas.Name = "gameCanvas";
            gameCanvas.OperatingCurrent = 0D;
            gameCanvas.OperatingCurrentTick = 0;
            gameCanvas.Size = new Size(674, 521);
            gameCanvas.TabIndex = 1;
            // 
            // MainGamePrototype
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 240, 245);
            ClientSize = new Size(1008, 720);
            Controls.Add(panelGameCanvasContainer);
            Controls.Add(pnlNextArea);
            Controls.Add(pnlHoldArea);
            Controls.Add(pnlBottomStatus);
            Controls.Add(pnlTopBar);
            Controls.Add(hopeForm1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(190, 40);
            Name = "MainGamePrototype";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CircuitCraft";
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPauseButton).EndInit();
            pnlHoldArea.ResumeLayout(false);
            pnlHoldArea.PerformLayout();
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
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private System.Windows.Forms.Panel pnlTopBar;
        private ReaLTaiizor.Controls.BigLabel lblScore;
        private ReaLTaiizor.Controls.BigLabel lblLevel;
        private ReaLTaiizor.Controls.BigLabel lblTime;
        private System.Windows.Forms.PictureBox picPauseButton;
        private System.Windows.Forms.Panel pnlHoldArea;
        private System.Windows.Forms.Panel pnlNextArea;
        private System.Windows.Forms.Panel pnlBottomStatus;
        private System.Windows.Forms.Panel panelGameCanvasContainer;
        private GameCanvas gameCanvas; // Your main game canvas
        private ReaLTaiizor.Controls.BigLabel lblHoldTitle;
        private System.Windows.Forms.Panel pnlHoldElementContainer;
        private ReaLTaiizor.Controls.BigLabel lblHoldElementValue;
        private System.Windows.Forms.PictureBox picHoldElement;
        private System.Windows.Forms.Button btnRemoveComponent;
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
    }
}