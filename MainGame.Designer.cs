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
            circuitSourceLabel = new MaterialSkin.Controls.MaterialLabel();
            loadCurrentLabel = new MaterialSkin.Controls.MaterialLabel();
            loadVoltageLabel = new MaterialSkin.Controls.MaterialLabel();
            loadPowerLabel = new MaterialSkin.Controls.MaterialLabel();
            loadResistanceLabel = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            dropResistorTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            circuitSourceTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            loadResistanceTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            dropResistorLabel = new MaterialSkin.Controls.MaterialLabel();
            circuitCompletedButton = new MaterialSkin.Controls.MaterialButton();
            resistorBurnedButton = new MaterialSkin.Controls.MaterialButton();
            ledBurnedButton = new MaterialSkin.Controls.MaterialButton();
            circuitCompletedLabel = new MaterialSkin.Controls.MaterialLabel();
            resistorBurnedLabel = new MaterialSkin.Controls.MaterialLabel();
            ledBurnedLabel = new MaterialSkin.Controls.MaterialLabel();
            ratingLabel = new MaterialSkin.Controls.MaterialLabel();
            dropSourceTbox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            dropVoltageLabel = new MaterialSkin.Controls.MaterialLabel();
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
            hopeForm1.Size = new Size(1264, 40);
            hopeForm1.TabIndex = 0;
            hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
            // 
            // gameCanvas
            // 
            gameCanvas.BackColor = Color.FromArgb(224, 224, 224);
            gameCanvas.CircuitBlock = null;
            gameCanvas.CircuitElement = null;
            gameCanvas.CircuitElementOffset = 20;
            gameCanvas.CircuitElementResistorSprite = (Image)resources.GetObject("gameCanvas.CircuitElementResistorSprite");
            gameCanvas.CircuitElementSourceSprite = (Image)resources.GetObject("gameCanvas.CircuitElementSourceSprite");
            gameCanvas.CircuitSources = null;
            gameCanvas.CurrentBlockIndex = 0;
            gameCanvas.CurrentCircuitElementDropped = null;
            gameCanvas.CurrentCircuitElementDroppedResistance = 0D;
            gameCanvas.CurrentCircuitElementDroppedVoltage = 0D;
            gameCanvas.Location = new Point(12, 46);
            gameCanvas.MainGame = null;
            gameCanvas.Name = "gameCanvas";
            gameCanvas.Size = new Size(1240, 612);
            gameCanvas.TabIndex = 3;
            // 
            // circuitSourceLabel
            // 
            circuitSourceLabel.Depth = 0;
            circuitSourceLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            circuitSourceLabel.Location = new Point(945, 182);
            circuitSourceLabel.MouseState = MaterialSkin.MouseState.HOVER;
            circuitSourceLabel.Name = "circuitSourceLabel";
            circuitSourceLabel.Size = new Size(292, 23);
            circuitSourceLabel.TabIndex = 4;
            circuitSourceLabel.Text = "Source: ";
            // 
            // loadCurrentLabel
            // 
            loadCurrentLabel.Depth = 0;
            loadCurrentLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loadCurrentLabel.Location = new Point(945, 205);
            loadCurrentLabel.MouseState = MaterialSkin.MouseState.HOVER;
            loadCurrentLabel.Name = "loadCurrentLabel";
            loadCurrentLabel.Size = new Size(292, 23);
            loadCurrentLabel.TabIndex = 5;
            loadCurrentLabel.Text = "Load Current: ";
            // 
            // loadVoltageLabel
            // 
            loadVoltageLabel.Depth = 0;
            loadVoltageLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loadVoltageLabel.Location = new Point(945, 228);
            loadVoltageLabel.MouseState = MaterialSkin.MouseState.HOVER;
            loadVoltageLabel.Name = "loadVoltageLabel";
            loadVoltageLabel.Size = new Size(292, 23);
            loadVoltageLabel.TabIndex = 6;
            loadVoltageLabel.Text = "Load Voltage: ";
            // 
            // loadPowerLabel
            // 
            loadPowerLabel.Depth = 0;
            loadPowerLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loadPowerLabel.Location = new Point(945, 251);
            loadPowerLabel.MouseState = MaterialSkin.MouseState.HOVER;
            loadPowerLabel.Name = "loadPowerLabel";
            loadPowerLabel.Size = new Size(292, 23);
            loadPowerLabel.TabIndex = 7;
            loadPowerLabel.Text = "Load Power: ";
            // 
            // loadResistanceLabel
            // 
            loadResistanceLabel.Depth = 0;
            loadResistanceLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loadResistanceLabel.Location = new Point(945, 274);
            loadResistanceLabel.MouseState = MaterialSkin.MouseState.HOVER;
            loadResistanceLabel.Name = "loadResistanceLabel";
            loadResistanceLabel.Size = new Size(292, 23);
            loadResistanceLabel.TabIndex = 8;
            loadResistanceLabel.Text = "Load Resistance: ";
            // 
            // materialLabel1
            // 
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(945, 46);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(292, 132);
            materialLabel1.TabIndex = 9;
            materialLabel1.Text = "G - Spawn Falling Resistor\r\nS - Spawn Falling Source\r\nC - Clear Circuit Elements\r\nP - Pause Timer\r\nO - Start Timer\r\nA - Move Circuit Element Left\r\nD - Move Circuit Element Right";
            // 
            // dropResistorTbox
            // 
            dropResistorTbox.AllowPromptAsInput = true;
            dropResistorTbox.AnimateReadOnly = false;
            dropResistorTbox.AsciiOnly = false;
            dropResistorTbox.BackgroundImageLayout = ImageLayout.None;
            dropResistorTbox.BeepOnError = false;
            dropResistorTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            dropResistorTbox.Depth = 0;
            dropResistorTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dropResistorTbox.HidePromptOnLeave = false;
            dropResistorTbox.HideSelection = true;
            dropResistorTbox.Hint = "Resistor Dropping Resistance";
            dropResistorTbox.InsertKeyMode = InsertKeyMode.Default;
            dropResistorTbox.LeadingIcon = null;
            dropResistorTbox.Location = new Point(945, 420);
            dropResistorTbox.Mask = "";
            dropResistorTbox.MaxLength = 32767;
            dropResistorTbox.MouseState = MaterialSkin.MouseState.OUT;
            dropResistorTbox.Name = "dropResistorTbox";
            dropResistorTbox.PasswordChar = '\0';
            dropResistorTbox.PrefixSuffixText = null;
            dropResistorTbox.PromptChar = '_';
            dropResistorTbox.ReadOnly = false;
            dropResistorTbox.RejectInputOnFirstFailure = false;
            dropResistorTbox.ResetOnPrompt = true;
            dropResistorTbox.ResetOnSpace = true;
            dropResistorTbox.RightToLeft = RightToLeft.No;
            dropResistorTbox.SelectedText = "";
            dropResistorTbox.SelectionLength = 0;
            dropResistorTbox.SelectionStart = 0;
            dropResistorTbox.ShortcutsEnabled = true;
            dropResistorTbox.ShowAssistiveText = true;
            dropResistorTbox.Size = new Size(250, 64);
            dropResistorTbox.SkipLiterals = true;
            dropResistorTbox.TabIndex = 10;
            dropResistorTbox.TabStop = false;
            dropResistorTbox.TextAlign = HorizontalAlignment.Left;
            dropResistorTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            dropResistorTbox.TrailingIcon = null;
            dropResistorTbox.UseSystemPasswordChar = false;
            dropResistorTbox.ValidatingType = null;
            dropResistorTbox.KeyPress += dropResistorTbox_KeyPress;
            // 
            // circuitSourceTbox
            // 
            circuitSourceTbox.AllowPromptAsInput = true;
            circuitSourceTbox.AnimateReadOnly = false;
            circuitSourceTbox.AsciiOnly = false;
            circuitSourceTbox.BackgroundImageLayout = ImageLayout.None;
            circuitSourceTbox.BeepOnError = false;
            circuitSourceTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            circuitSourceTbox.Depth = 0;
            circuitSourceTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            circuitSourceTbox.HidePromptOnLeave = false;
            circuitSourceTbox.HideSelection = true;
            circuitSourceTbox.Hint = "Circuit Voltage Source";
            circuitSourceTbox.InsertKeyMode = InsertKeyMode.Default;
            circuitSourceTbox.LeadingIcon = null;
            circuitSourceTbox.Location = new Point(945, 503);
            circuitSourceTbox.Mask = "";
            circuitSourceTbox.MaxLength = 32767;
            circuitSourceTbox.MouseState = MaterialSkin.MouseState.OUT;
            circuitSourceTbox.Name = "circuitSourceTbox";
            circuitSourceTbox.PasswordChar = '\0';
            circuitSourceTbox.PrefixSuffixText = null;
            circuitSourceTbox.PromptChar = '_';
            circuitSourceTbox.ReadOnly = false;
            circuitSourceTbox.RejectInputOnFirstFailure = false;
            circuitSourceTbox.ResetOnPrompt = true;
            circuitSourceTbox.ResetOnSpace = true;
            circuitSourceTbox.RightToLeft = RightToLeft.No;
            circuitSourceTbox.SelectedText = "";
            circuitSourceTbox.SelectionLength = 0;
            circuitSourceTbox.SelectionStart = 0;
            circuitSourceTbox.ShortcutsEnabled = true;
            circuitSourceTbox.ShowAssistiveText = true;
            circuitSourceTbox.Size = new Size(250, 64);
            circuitSourceTbox.SkipLiterals = true;
            circuitSourceTbox.TabIndex = 11;
            circuitSourceTbox.TabStop = false;
            circuitSourceTbox.TextAlign = HorizontalAlignment.Left;
            circuitSourceTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            circuitSourceTbox.TrailingIcon = null;
            circuitSourceTbox.UseSystemPasswordChar = false;
            circuitSourceTbox.ValidatingType = null;
            circuitSourceTbox.KeyPress += circuitSourceTbox_KeyPress;
            // 
            // loadResistanceTbox
            // 
            loadResistanceTbox.AllowPromptAsInput = true;
            loadResistanceTbox.AnimateReadOnly = false;
            loadResistanceTbox.AsciiOnly = false;
            loadResistanceTbox.BackgroundImageLayout = ImageLayout.None;
            loadResistanceTbox.BeepOnError = false;
            loadResistanceTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            loadResistanceTbox.Depth = 0;
            loadResistanceTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            loadResistanceTbox.HidePromptOnLeave = false;
            loadResistanceTbox.HideSelection = true;
            loadResistanceTbox.Hint = "Load Resistance";
            loadResistanceTbox.InsertKeyMode = InsertKeyMode.Default;
            loadResistanceTbox.LeadingIcon = null;
            loadResistanceTbox.Location = new Point(945, 586);
            loadResistanceTbox.Mask = "";
            loadResistanceTbox.MaxLength = 32767;
            loadResistanceTbox.MouseState = MaterialSkin.MouseState.OUT;
            loadResistanceTbox.Name = "loadResistanceTbox";
            loadResistanceTbox.PasswordChar = '\0';
            loadResistanceTbox.PrefixSuffixText = null;
            loadResistanceTbox.PromptChar = '_';
            loadResistanceTbox.ReadOnly = false;
            loadResistanceTbox.RejectInputOnFirstFailure = false;
            loadResistanceTbox.ResetOnPrompt = true;
            loadResistanceTbox.ResetOnSpace = true;
            loadResistanceTbox.RightToLeft = RightToLeft.No;
            loadResistanceTbox.SelectedText = "";
            loadResistanceTbox.SelectionLength = 0;
            loadResistanceTbox.SelectionStart = 0;
            loadResistanceTbox.ShortcutsEnabled = true;
            loadResistanceTbox.ShowAssistiveText = true;
            loadResistanceTbox.Size = new Size(250, 64);
            loadResistanceTbox.SkipLiterals = true;
            loadResistanceTbox.TabIndex = 12;
            loadResistanceTbox.TabStop = false;
            loadResistanceTbox.TextAlign = HorizontalAlignment.Left;
            loadResistanceTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            loadResistanceTbox.TrailingIcon = null;
            loadResistanceTbox.UseSystemPasswordChar = false;
            loadResistanceTbox.ValidatingType = null;
            loadResistanceTbox.KeyPress += loadResistanceTbox_KeyPress;
            // 
            // dropResistorLabel
            // 
            dropResistorLabel.Depth = 0;
            dropResistorLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dropResistorLabel.Location = new Point(945, 297);
            dropResistorLabel.MouseState = MaterialSkin.MouseState.HOVER;
            dropResistorLabel.Name = "dropResistorLabel";
            dropResistorLabel.Size = new Size(292, 23);
            dropResistorLabel.TabIndex = 13;
            dropResistorLabel.Text = "Drop Resistor Resistance: ";
            // 
            // circuitCompletedButton
            // 
            circuitCompletedButton.AutoSize = false;
            circuitCompletedButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            circuitCompletedButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            circuitCompletedButton.Depth = 0;
            circuitCompletedButton.HighEmphasis = true;
            circuitCompletedButton.Icon = null;
            circuitCompletedButton.Location = new Point(633, 46);
            circuitCompletedButton.Margin = new Padding(4, 6, 4, 6);
            circuitCompletedButton.MouseState = MaterialSkin.MouseState.HOVER;
            circuitCompletedButton.Name = "circuitCompletedButton";
            circuitCompletedButton.NoAccentTextColor = Color.Empty;
            circuitCompletedButton.Size = new Size(281, 36);
            circuitCompletedButton.TabIndex = 14;
            circuitCompletedButton.Text = "Simulate Circuit Completion";
            circuitCompletedButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            circuitCompletedButton.UseAccentColor = false;
            circuitCompletedButton.UseVisualStyleBackColor = true;
            circuitCompletedButton.Click += circuitCompletedButton_Click;
            // 
            // resistorBurnedButton
            // 
            resistorBurnedButton.AutoSize = false;
            resistorBurnedButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resistorBurnedButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            resistorBurnedButton.Depth = 0;
            resistorBurnedButton.HighEmphasis = true;
            resistorBurnedButton.Icon = null;
            resistorBurnedButton.Location = new Point(633, 94);
            resistorBurnedButton.Margin = new Padding(4, 6, 4, 6);
            resistorBurnedButton.MouseState = MaterialSkin.MouseState.HOVER;
            resistorBurnedButton.Name = "resistorBurnedButton";
            resistorBurnedButton.NoAccentTextColor = Color.Empty;
            resistorBurnedButton.Size = new Size(281, 36);
            resistorBurnedButton.TabIndex = 15;
            resistorBurnedButton.Text = "simulate resistor burned";
            resistorBurnedButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            resistorBurnedButton.UseAccentColor = false;
            resistorBurnedButton.UseVisualStyleBackColor = true;
            resistorBurnedButton.Click += resistorBurnedButton_Click;
            // 
            // ledBurnedButton
            // 
            ledBurnedButton.AutoSize = false;
            ledBurnedButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ledBurnedButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ledBurnedButton.Depth = 0;
            ledBurnedButton.HighEmphasis = true;
            ledBurnedButton.Icon = null;
            ledBurnedButton.Location = new Point(633, 142);
            ledBurnedButton.Margin = new Padding(4, 6, 4, 6);
            ledBurnedButton.MouseState = MaterialSkin.MouseState.HOVER;
            ledBurnedButton.Name = "ledBurnedButton";
            ledBurnedButton.NoAccentTextColor = Color.Empty;
            ledBurnedButton.Size = new Size(281, 36);
            ledBurnedButton.TabIndex = 16;
            ledBurnedButton.Text = "simulate led burned";
            ledBurnedButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ledBurnedButton.UseAccentColor = false;
            ledBurnedButton.UseVisualStyleBackColor = true;
            ledBurnedButton.Click += ledBurnedButton_Click;
            // 
            // circuitCompletedLabel
            // 
            circuitCompletedLabel.Depth = 0;
            circuitCompletedLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            circuitCompletedLabel.Location = new Point(633, 205);
            circuitCompletedLabel.MouseState = MaterialSkin.MouseState.HOVER;
            circuitCompletedLabel.Name = "circuitCompletedLabel";
            circuitCompletedLabel.Size = new Size(292, 23);
            circuitCompletedLabel.TabIndex = 17;
            circuitCompletedLabel.Text = "Current Circuit Completed: ";
            // 
            // resistorBurnedLabel
            // 
            resistorBurnedLabel.Depth = 0;
            resistorBurnedLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            resistorBurnedLabel.Location = new Point(633, 228);
            resistorBurnedLabel.MouseState = MaterialSkin.MouseState.HOVER;
            resistorBurnedLabel.Name = "resistorBurnedLabel";
            resistorBurnedLabel.Size = new Size(292, 23);
            resistorBurnedLabel.TabIndex = 18;
            resistorBurnedLabel.Text = "Current Resistors Burned: ";
            // 
            // ledBurnedLabel
            // 
            ledBurnedLabel.Depth = 0;
            ledBurnedLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            ledBurnedLabel.Location = new Point(633, 251);
            ledBurnedLabel.MouseState = MaterialSkin.MouseState.HOVER;
            ledBurnedLabel.Name = "ledBurnedLabel";
            ledBurnedLabel.Size = new Size(292, 23);
            ledBurnedLabel.TabIndex = 19;
            ledBurnedLabel.Text = "Current LEDs Burned: ";
            // 
            // ratingLabel
            // 
            ratingLabel.Depth = 0;
            ratingLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            ratingLabel.Location = new Point(633, 274);
            ratingLabel.MouseState = MaterialSkin.MouseState.HOVER;
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new Size(292, 23);
            ratingLabel.TabIndex = 20;
            ratingLabel.Text = "Current Rating: ";
            // 
            // dropSourceTbox
            // 
            dropSourceTbox.AllowPromptAsInput = true;
            dropSourceTbox.AnimateReadOnly = false;
            dropSourceTbox.AsciiOnly = false;
            dropSourceTbox.BackgroundImageLayout = ImageLayout.None;
            dropSourceTbox.BeepOnError = false;
            dropSourceTbox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            dropSourceTbox.Depth = 0;
            dropSourceTbox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            dropSourceTbox.HidePromptOnLeave = false;
            dropSourceTbox.HideSelection = true;
            dropSourceTbox.Hint = "Source Dropping Voltage";
            dropSourceTbox.InsertKeyMode = InsertKeyMode.Default;
            dropSourceTbox.LeadingIcon = null;
            dropSourceTbox.Location = new Point(945, 350);
            dropSourceTbox.Mask = "";
            dropSourceTbox.MaxLength = 32767;
            dropSourceTbox.MouseState = MaterialSkin.MouseState.OUT;
            dropSourceTbox.Name = "dropSourceTbox";
            dropSourceTbox.PasswordChar = '\0';
            dropSourceTbox.PrefixSuffixText = null;
            dropSourceTbox.PromptChar = '_';
            dropSourceTbox.ReadOnly = false;
            dropSourceTbox.RejectInputOnFirstFailure = false;
            dropSourceTbox.ResetOnPrompt = true;
            dropSourceTbox.ResetOnSpace = true;
            dropSourceTbox.RightToLeft = RightToLeft.No;
            dropSourceTbox.SelectedText = "";
            dropSourceTbox.SelectionLength = 0;
            dropSourceTbox.SelectionStart = 0;
            dropSourceTbox.ShortcutsEnabled = true;
            dropSourceTbox.ShowAssistiveText = true;
            dropSourceTbox.Size = new Size(250, 64);
            dropSourceTbox.SkipLiterals = true;
            dropSourceTbox.TabIndex = 21;
            dropSourceTbox.TabStop = false;
            dropSourceTbox.TextAlign = HorizontalAlignment.Left;
            dropSourceTbox.TextMaskFormat = MaskFormat.IncludeLiterals;
            dropSourceTbox.TrailingIcon = null;
            dropSourceTbox.UseSystemPasswordChar = false;
            dropSourceTbox.ValidatingType = null;
            dropSourceTbox.KeyPress += dropSourceTbox_KeyPress;
            // 
            // dropVoltageLabel
            // 
            dropVoltageLabel.Depth = 0;
            dropVoltageLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dropVoltageLabel.Location = new Point(945, 320);
            dropVoltageLabel.MouseState = MaterialSkin.MouseState.HOVER;
            dropVoltageLabel.Name = "dropVoltageLabel";
            dropVoltageLabel.Size = new Size(292, 23);
            dropVoltageLabel.TabIndex = 22;
            dropVoltageLabel.Text = "Drop Voltage: ";
            // 
            // MainGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(dropVoltageLabel);
            Controls.Add(dropSourceTbox);
            Controls.Add(ratingLabel);
            Controls.Add(ledBurnedLabel);
            Controls.Add(resistorBurnedLabel);
            Controls.Add(circuitCompletedLabel);
            Controls.Add(ledBurnedButton);
            Controls.Add(resistorBurnedButton);
            Controls.Add(circuitCompletedButton);
            Controls.Add(dropResistorLabel);
            Controls.Add(loadResistanceTbox);
            Controls.Add(circuitSourceTbox);
            Controls.Add(dropResistorTbox);
            Controls.Add(materialLabel1);
            Controls.Add(loadResistanceLabel);
            Controls.Add(loadPowerLabel);
            Controls.Add(loadVoltageLabel);
            Controls.Add(loadCurrentLabel);
            Controls.Add(circuitSourceLabel);
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
        private MaterialSkin.Controls.MaterialLabel circuitSourceLabel;
        private MaterialSkin.Controls.MaterialLabel loadCurrentLabel;
        private MaterialSkin.Controls.MaterialLabel loadVoltageLabel;
        private MaterialSkin.Controls.MaterialLabel loadPowerLabel;
        private MaterialSkin.Controls.MaterialLabel loadResistanceLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox dropResistorTbox;
        private MaterialSkin.Controls.MaterialMaskedTextBox circuitSourceTbox;
        private MaterialSkin.Controls.MaterialMaskedTextBox loadResistanceTbox;
        private MaterialSkin.Controls.MaterialLabel dropResistorLabel;
        private MaterialSkin.Controls.MaterialButton circuitCompletedButton;
        private MaterialSkin.Controls.MaterialButton resistorBurnedButton;
        private MaterialSkin.Controls.MaterialButton ledBurnedButton;
        private MaterialSkin.Controls.MaterialLabel circuitCompletedLabel;
        private MaterialSkin.Controls.MaterialLabel resistorBurnedLabel;
        private MaterialSkin.Controls.MaterialLabel ledBurnedLabel;
        private MaterialSkin.Controls.MaterialLabel ratingLabel;
        private MaterialSkin.Controls.MaterialMaskedTextBox dropSourceTbox;
        private MaterialSkin.Controls.MaterialLabel dropVoltageLabel;
    }
}