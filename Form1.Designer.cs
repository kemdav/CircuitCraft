﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CircuitCraft // Change this namespace to match your project
{
    partial class Form1
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
            this.panelGameArea = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTime = new System.Windows.Forms.Panel();
            this.labelTimeValue = new System.Windows.Forms.Label();
            this.labelTimeText = new System.Windows.Forms.Label();
            this.labelLogoPlaceholder = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelHold = new System.Windows.Forms.Panel();
            this.panelHoldPiece = new System.Windows.Forms.Panel();
            this.labelHoldText = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelScore = new System.Windows.Forms.Panel();
            this.labelScoreValue = new System.Windows.Forms.Label();
            this.labelScoreText = new System.Windows.Forms.Label();
            this.panelHighScore = new System.Windows.Forms.Panel();
            this.labelHighScoreValue = new System.Windows.Forms.Label();
            this.labelHighScoreText = new System.Windows.Forms.Label();
            this.panelGoal = new System.Windows.Forms.Panel();
            this.labelGoalValue = new System.Windows.Forms.Label();
            this.labelGoalText = new System.Windows.Forms.Label();
            this.panelLevel = new System.Windows.Forms.Panel();
            this.labelLevelValue = new System.Windows.Forms.Label();
            this.labelLevelText = new System.Windows.Forms.Label();
            this.panelNext = new System.Windows.Forms.Panel();
            this.panelNextPiece3 = new System.Windows.Forms.Panel();
            this.panelNextPiece2 = new System.Windows.Forms.Panel();
            this.panelNextPiece1 = new System.Windows.Forms.Panel();
            this.labelNextText = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelHold.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelScore.SuspendLayout();
            this.panelHighScore.SuspendLayout();
            this.panelGoal.SuspendLayout();
            this.panelLevel.SuspendLayout();
            this.panelNext.SuspendLayout();
            this.SuspendLayout();
            //
            // panelGameArea
            //
            this.panelGameArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelGameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGameArea.Location = new System.Drawing.Point(12, 127);
            this.panelGameArea.Name = "panelGameArea";
            this.panelGameArea.Size = new System.Drawing.Size(252, 502); // Approx 10x20 grid aspect ratio + border
            this.panelGameArea.TabIndex = 1;
            //
            // panelLeft
            //
            this.panelLeft.Controls.Add(this.panelTime);
            this.panelLeft.Controls.Add(this.labelLogoPlaceholder);
            this.panelLeft.Location = new System.Drawing.Point(12, 12);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 658);
            this.panelLeft.TabIndex = 0;
            //
            // panelTime
            //
            this.panelTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panelTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTime.Controls.Add(this.labelTimeValue);
            this.panelTime.Controls.Add(this.labelTimeText);
            this.panelTime.Location = new System.Drawing.Point(15, 488);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(170, 65);
            this.panelTime.TabIndex = 1;
            //
            // labelTimeValue
            //
            this.labelTimeValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeValue.ForeColor = System.Drawing.Color.White;
            this.labelTimeValue.Location = new System.Drawing.Point(3, 30);
            this.labelTimeValue.Name = "labelTimeValue";
            this.labelTimeValue.Size = new System.Drawing.Size(164, 28);
            this.labelTimeValue.TabIndex = 1;
            this.labelTimeValue.Text = "03 : 53 : 52";
            this.labelTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelTimeText
            //
            this.labelTimeText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTimeText.Location = new System.Drawing.Point(3, 5);
            this.labelTimeText.Name = "labelTimeText";
            this.labelTimeText.Size = new System.Drawing.Size(164, 23);
            this.labelTimeText.TabIndex = 0;
            this.labelTimeText.Text = "TIME";
            this.labelTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelLogoPlaceholder
            //
            this.labelLogoPlaceholder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelLogoPlaceholder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLogoPlaceholder.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogoPlaceholder.ForeColor = System.Drawing.Color.White;
            this.labelLogoPlaceholder.Location = new System.Drawing.Point(15, 15);
            this.labelLogoPlaceholder.Name = "labelLogoPlaceholder";
            this.labelLogoPlaceholder.Size = new System.Drawing.Size(170, 100);
            this.labelLogoPlaceholder.TabIndex = 0;
            this.labelLogoPlaceholder.Text = "TETRIS";
            this.labelLogoPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMiddle
            //
            this.panelMiddle.BackColor = System.Drawing.Color.Transparent; // Will use form's backcolor
            this.panelMiddle.Controls.Add(this.panelHold);
            this.panelMiddle.Controls.Add(this.panelGameArea);
            this.panelMiddle.Location = new System.Drawing.Point(218, 12);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(276, 658);
            this.panelMiddle.TabIndex = 1;
            //
            // panelHold
            //
            this.panelHold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHold.Controls.Add(this.panelHoldPiece);
            this.panelHold.Controls.Add(this.labelHoldText);
            this.panelHold.Location = new System.Drawing.Point(12, 15);
            this.panelHold.Name = "panelHold";
            this.panelHold.Size = new System.Drawing.Size(120, 100);
            this.panelHold.TabIndex = 0;
            //
            // panelHoldPiece
            //
            this.panelHoldPiece.BackColor = System.Drawing.Color.Black;
            this.panelHoldPiece.Location = new System.Drawing.Point(18, 31);
            this.panelHoldPiece.Name = "panelHoldPiece";
            this.panelHoldPiece.Size = new System.Drawing.Size(80, 60);
            this.panelHoldPiece.TabIndex = 1;
            // Draw Held Piece Here in code-behind
            //
            // labelHoldText
            //
            this.labelHoldText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHoldText.ForeColor = System.Drawing.Color.White;
            this.labelHoldText.Location = new System.Drawing.Point(4, 4);
            this.labelHoldText.Name = "labelHoldText";
            this.labelHoldText.Size = new System.Drawing.Size(111, 23);
            this.labelHoldText.TabIndex = 0;
            this.labelHoldText.Text = "HOLD";
            this.labelHoldText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelRight
            //
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.panelScore);
            this.panelRight.Controls.Add(this.panelHighScore);
            this.panelRight.Controls.Add(this.panelGoal);
            this.panelRight.Controls.Add(this.panelLevel);
            this.panelRight.Controls.Add(this.panelNext);
            this.panelRight.Location = new System.Drawing.Point(500, 12);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(200, 658);
            this.panelRight.TabIndex = 2;
            //
            // panelScore
            //
            this.panelScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panelScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelScore.Controls.Add(this.labelScoreValue);
            this.panelScore.Controls.Add(this.labelScoreText);
            this.panelScore.Location = new System.Drawing.Point(15, 568);
            this.panelScore.Name = "panelScore";
            this.panelScore.Size = new System.Drawing.Size(170, 65);
            this.panelScore.TabIndex = 6;
            //
            // labelScoreValue
            //
            this.labelScoreValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreValue.ForeColor = System.Drawing.Color.White;
            this.labelScoreValue.Location = new System.Drawing.Point(3, 30);
            this.labelScoreValue.Name = "labelScoreValue";
            this.labelScoreValue.Size = new System.Drawing.Size(164, 28);
            this.labelScoreValue.TabIndex = 1;
            this.labelScoreValue.Text = "3,757";
            this.labelScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelScoreText
            //
            this.labelScoreText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelScoreText.Location = new System.Drawing.Point(3, 5);
            this.labelScoreText.Name = "labelScoreText";
            this.labelScoreText.Size = new System.Drawing.Size(164, 23);
            this.labelScoreText.TabIndex = 0;
            this.labelScoreText.Text = "SCORE";
            this.labelScoreText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelHighScore
            //
            this.panelHighScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panelHighScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHighScore.Controls.Add(this.labelHighScoreValue);
            this.panelHighScore.Controls.Add(this.labelHighScoreText);
            this.panelHighScore.Location = new System.Drawing.Point(15, 488);
            this.panelHighScore.Name = "panelHighScore";
            this.panelHighScore.Size = new System.Drawing.Size(170, 65);
            this.panelHighScore.TabIndex = 5;
            //
            // labelHighScoreValue
            //
            this.labelHighScoreValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighScoreValue.ForeColor = System.Drawing.Color.White;
            this.labelHighScoreValue.Location = new System.Drawing.Point(3, 30);
            this.labelHighScoreValue.Name = "labelHighScoreValue";
            this.labelHighScoreValue.Size = new System.Drawing.Size(164, 28);
            this.labelHighScoreValue.TabIndex = 1;
            this.labelHighScoreValue.Text = "124,252";
            this.labelHighScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelHighScoreText
            //
            this.labelHighScoreText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighScoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelHighScoreText.Location = new System.Drawing.Point(3, 5);
            this.labelHighScoreText.Name = "labelHighScoreText";
            this.labelHighScoreText.Size = new System.Drawing.Size(164, 23);
            this.labelHighScoreText.TabIndex = 0;
            this.labelHighScoreText.Text = "HIGH SCORE";
            this.labelHighScoreText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelGoal
            //
            this.panelGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGoal.Controls.Add(this.labelGoalValue);
            this.panelGoal.Controls.Add(this.labelGoalText);
            this.panelGoal.Location = new System.Drawing.Point(138, 127);
            this.panelGoal.Name = "panelGoal";
            this.panelGoal.Size = new System.Drawing.Size(47, 100);
            this.panelGoal.TabIndex = 4;
            //
            // labelGoalValue
            //
            this.labelGoalValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoalValue.ForeColor = System.Drawing.Color.Gold;
            this.labelGoalValue.Location = new System.Drawing.Point(3, 31);
            this.labelGoalValue.Name = "labelGoalValue";
            this.labelGoalValue.Size = new System.Drawing.Size(39, 60);
            this.labelGoalValue.TabIndex = 1;
            this.labelGoalValue.Text = "3";
            this.labelGoalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelGoalText
            //
            this.labelGoalText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoalText.ForeColor = System.Drawing.Color.White;
            this.labelGoalText.Location = new System.Drawing.Point(4, 4);
            this.labelGoalText.Name = "labelGoalText";
            this.labelGoalText.Size = new System.Drawing.Size(38, 23);
            this.labelGoalText.TabIndex = 0;
            this.labelGoalText.Text = "GOAL";
            this.labelGoalText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelLevel
            //
            this.panelLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel.Controls.Add(this.labelLevelValue);
            this.panelLevel.Controls.Add(this.labelLevelText);
            this.panelLevel.Location = new System.Drawing.Point(138, 15);
            this.panelLevel.Name = "panelLevel";
            this.panelLevel.Size = new System.Drawing.Size(47, 100);
            this.panelLevel.TabIndex = 3;
            //
            // labelLevelValue
            //
            this.labelLevelValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevelValue.ForeColor = System.Drawing.Color.Gold;
            this.labelLevelValue.Location = new System.Drawing.Point(3, 31);
            this.labelLevelValue.Name = "labelLevelValue";
            this.labelLevelValue.Size = new System.Drawing.Size(39, 60);
            this.labelLevelValue.TabIndex = 1;
            this.labelLevelValue.Text = "3";
            this.labelLevelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelLevelText
            //
            this.labelLevelText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevelText.ForeColor = System.Drawing.Color.White;
            this.labelLevelText.Location = new System.Drawing.Point(4, 4);
            this.labelLevelText.Name = "labelLevelText";
            this.labelLevelText.Size = new System.Drawing.Size(38, 23);
            this.labelLevelText.TabIndex = 0;
            this.labelLevelText.Text = "LEVEL";
            this.labelLevelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelNext
            //
            this.panelNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNext.Controls.Add(this.panelNextPiece3);
            this.panelNext.Controls.Add(this.panelNextPiece2);
            this.panelNext.Controls.Add(this.panelNextPiece1);
            this.panelNext.Controls.Add(this.labelNextText);
            this.panelNext.Location = new System.Drawing.Point(15, 15);
            this.panelNext.Name = "panelNext";
            this.panelNext.Size = new System.Drawing.Size(120, 290); // Adjusted height for 3 pieces
            this.panelNext.TabIndex = 2;
            //
            // panelNextPiece3
            //
            this.panelNextPiece3.BackColor = System.Drawing.Color.Black;
            this.panelNextPiece3.Location = new System.Drawing.Point(18, 219);
            this.panelNextPiece3.Name = "panelNextPiece3";
            this.panelNextPiece3.Size = new System.Drawing.Size(80, 60);
            this.panelNextPiece3.TabIndex = 4;
            // Draw Next Piece Here in code-behind
            //
            // panelNextPiece2
            //
            this.panelNextPiece2.BackColor = System.Drawing.Color.Black;
            this.panelNextPiece2.Location = new System.Drawing.Point(18, 125);
            this.panelNextPiece2.Name = "panelNextPiece2";
            this.panelNextPiece2.Size = new System.Drawing.Size(80, 60);
            this.panelNextPiece2.TabIndex = 3;
            // Draw Next Piece Here in code-behind
            //
            // panelNextPiece1
            //
            this.panelNextPiece1.BackColor = System.Drawing.Color.Black;
            this.panelNextPiece1.Location = new System.Drawing.Point(18, 31);
            this.panelNextPiece1.Name = "panelNextPiece1";
            this.panelNextPiece1.Size = new System.Drawing.Size(80, 60);
            this.panelNextPiece1.TabIndex = 2;
            // Draw Next Piece Here in code-behind
            //
            // labelNextText
            //
            this.labelNextText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNextText.ForeColor = System.Drawing.Color.White;
            this.labelNextText.Location = new System.Drawing.Point(4, 4);
            this.labelNextText.Name = "labelNextText";
            this.labelNextText.Size = new System.Drawing.Size(111, 23);
            this.labelNextText.TabIndex = 0;
            this.labelNextText.Text = "NEXT";
            this.labelNextText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(0)))), ((int)(((byte)(90))))); // Deep Purple
            this.ClientSize = new System.Drawing.Size(714, 681); // Adjusted size
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.panelLeft.ResumeLayout(false);
            this.panelTime.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelHold.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelScore.ResumeLayout(false);
            this.panelHighScore.ResumeLayout(false);
            this.panelGoal.ResumeLayout(false);
            this.panelLevel.ResumeLayout(false);
            this.panelNext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelGameArea;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label labelLogoPlaceholder;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelHold;
        private System.Windows.Forms.Label labelHoldText;
        private System.Windows.Forms.Panel panelHoldPiece;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelNext;
        private System.Windows.Forms.Label labelNextText;
        private System.Windows.Forms.Panel panelNextPiece1;
        private System.Windows.Forms.Panel panelNextPiece3;
        private System.Windows.Forms.Panel panelNextPiece2;
        private System.Windows.Forms.Panel panelLevel;
        private System.Windows.Forms.Label labelLevelValue;
        private System.Windows.Forms.Label labelLevelText;
        private System.Windows.Forms.Panel panelGoal;
        private System.Windows.Forms.Label labelGoalValue;
        private System.Windows.Forms.Label labelGoalText;
        private System.Windows.Forms.Panel panelHighScore;
        private System.Windows.Forms.Label labelHighScoreValue;
        private System.Windows.Forms.Label labelHighScoreText;
        private System.Windows.Forms.Panel panelScore;
        private System.Windows.Forms.Label labelScoreValue;
        private System.Windows.Forms.Label labelScoreText;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.Label labelTimeValue;
        private System.Windows.Forms.Label labelTimeText;
    }
}