namespace CircuitCraft
{
    partial class TutorialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialForm));
            circuitCanvas1 = new CircuitCanvas();
            CanvasContextMenuStrip = new ContextMenuStrip(components);
            addResistorToolStripMenuItem = new ToolStripMenuItem();
            addBatterySourceToolStripMenuItem = new ToolStripMenuItem();
            rotate90ToolStripMenuItem = new ToolStripMenuItem();
            CanvasContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // circuitCanvas1
            // 
            circuitCanvas1.BackColor = Color.White;
            circuitCanvas1.ContextMenuStrip = CanvasContextMenuStrip;
            circuitCanvas1.Location = new Point(-2, -2);
            circuitCanvas1.Name = "circuitCanvas1";
            circuitCanvas1.Size = new Size(1265, 684);
            circuitCanvas1.TabIndex = 0;
            // 
            // CanvasContextMenuStrip
            // 
            CanvasContextMenuStrip.Items.AddRange(new ToolStripItem[] { addResistorToolStripMenuItem, addBatterySourceToolStripMenuItem, rotate90ToolStripMenuItem });
            CanvasContextMenuStrip.Name = "CanvasContextMenuStrip";
            CanvasContextMenuStrip.Size = new Size(176, 70);
            // 
            // addResistorToolStripMenuItem
            // 
            addResistorToolStripMenuItem.Name = "addResistorToolStripMenuItem";
            addResistorToolStripMenuItem.Size = new Size(175, 22);
            addResistorToolStripMenuItem.Text = "Add Resistor";
            addResistorToolStripMenuItem.Click += addResistorToolStripMenuItem_Click;
            // 
            // addBatterySourceToolStripMenuItem
            // 
            addBatterySourceToolStripMenuItem.Name = "addBatterySourceToolStripMenuItem";
            addBatterySourceToolStripMenuItem.Size = new Size(175, 22);
            addBatterySourceToolStripMenuItem.Text = "Add Battery Source";
            addBatterySourceToolStripMenuItem.Click += addBatterySourceToolStripMenuItem_Click;
            // 
            // rotate90ToolStripMenuItem
            // 
            rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            rotate90ToolStripMenuItem.Size = new Size(175, 22);
            rotate90ToolStripMenuItem.Text = "Rotate 90";
            rotate90ToolStripMenuItem.Click += rotate90ToolStripMenuItem_Click;
            // 
            // TutorialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(circuitCanvas1);
            Name = "TutorialForm";
            Text = "Form1";
            CanvasContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CircuitCanvas circuitCanvas1;
        private ContextMenuStrip CanvasContextMenuStrip;
        private ToolStripMenuItem addResistorToolStripMenuItem;
        private ToolStripMenuItem addBatterySourceToolStripMenuItem;
        private ToolStripMenuItem rotate90ToolStripMenuItem;
    }
}
