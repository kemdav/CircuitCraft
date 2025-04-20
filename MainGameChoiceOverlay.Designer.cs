namespace CircuitCraft
{
    partial class MainGameChoiceOverlay
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
            choicePanel1 = new Panel();
            choicePanel2 = new Panel();
            choicePanel3 = new Panel();
            gameoverFormPos = new Panel();
            SuspendLayout();
            // 
            // choicePanel1
            // 
            choicePanel1.Anchor = AnchorStyles.None;
            choicePanel1.BackColor = Color.Transparent;
            choicePanel1.Location = new Point(52, 117);
            choicePanel1.Name = "choicePanel1";
            choicePanel1.Size = new Size(174, 419);
            choicePanel1.TabIndex = 2;
            // 
            // choicePanel2
            // 
            choicePanel2.Anchor = AnchorStyles.None;
            choicePanel2.BackColor = Color.Transparent;
            choicePanel2.Location = new Point(372, 117);
            choicePanel2.Name = "choicePanel2";
            choicePanel2.Size = new Size(263, 419);
            choicePanel2.TabIndex = 3;
            // 
            // choicePanel3
            // 
            choicePanel3.Anchor = AnchorStyles.None;
            choicePanel3.BackColor = Color.Transparent;
            choicePanel3.Location = new Point(691, 117);
            choicePanel3.Name = "choicePanel3";
            choicePanel3.Size = new Size(263, 419);
            choicePanel3.TabIndex = 4;
            // 
            // gameoverFormPos
            // 
            gameoverFormPos.Anchor = AnchorStyles.None;
            gameoverFormPos.BackColor = Color.Transparent;
            gameoverFormPos.Location = new Point(232, 173);
            gameoverFormPos.Name = "gameoverFormPos";
            gameoverFormPos.Size = new Size(569, 320);
            gameoverFormPos.TabIndex = 4;
            // 
            // MainGameChoiceOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1008, 720);
            Controls.Add(gameoverFormPos);
            Controls.Add(choicePanel3);
            Controls.Add(choicePanel2);
            Controls.Add(choicePanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainGameChoiceOverlay";
            Text = "MainGameChoiceOverlay";
            TransparencyKey = Color.IndianRed;
            ResumeLayout(false);
        }

        #endregion

        private Panel choicePanel1;
        private Panel choicePanel2;
        private Panel choicePanel3;
        private Panel gameoverFormPos;
    }
}