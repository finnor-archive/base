namespace DNAAlignmentToolWithXYBases
{
    partial class MainForm
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
            this.Sequence1 = new System.Windows.Forms.TextBox();
            this.Sequence1Lbl = new System.Windows.Forms.Label();
            this.Sequence2Lbl = new System.Windows.Forms.Label();
            this.Sequence2 = new System.Windows.Forms.TextBox();
            this.alignBtn = new System.Windows.Forms.Button();
            this.importSequence1Btn = new System.Windows.Forms.Button();
            this.ImportSequence2Btn = new System.Windows.Forms.Button();
            this.OutputSequence1 = new System.Windows.Forms.TextBox();
            this.OutputSequence2 = new System.Windows.Forms.TextBox();
            this.OutputSequence1Lbl = new System.Windows.Forms.Label();
            this.OutputSequence2Lbl = new System.Windows.Forms.Label();
            this.ExportSequencesBtn = new System.Windows.Forms.Button();
            this.MatchScore = new System.Windows.Forms.TextBox();
            this.MismatchScore = new System.Windows.Forms.TextBox();
            this.GapScore = new System.Windows.Forms.TextBox();
            this.MatchScoreLbl = new System.Windows.Forms.Label();
            this.MismatchScoreLbl = new System.Windows.Forms.Label();
            this.GapScoreLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Sequence1
            // 
            this.Sequence1.Location = new System.Drawing.Point(60, 36);
            this.Sequence1.Multiline = true;
            this.Sequence1.Name = "Sequence1";
            this.Sequence1.Size = new System.Drawing.Size(315, 220);
            this.Sequence1.TabIndex = 0;
            // 
            // Sequence1Lbl
            // 
            this.Sequence1Lbl.AutoSize = true;
            this.Sequence1Lbl.Location = new System.Drawing.Point(57, 20);
            this.Sequence1Lbl.Name = "Sequence1Lbl";
            this.Sequence1Lbl.Size = new System.Drawing.Size(79, 13);
            this.Sequence1Lbl.TabIndex = 1;
            this.Sequence1Lbl.Text = "Sequence One";
            // 
            // Sequence2Lbl
            // 
            this.Sequence2Lbl.AutoSize = true;
            this.Sequence2Lbl.Location = new System.Drawing.Point(552, 20);
            this.Sequence2Lbl.Name = "Sequence2Lbl";
            this.Sequence2Lbl.Size = new System.Drawing.Size(80, 13);
            this.Sequence2Lbl.TabIndex = 2;
            this.Sequence2Lbl.Text = "Sequence Two";
            // 
            // Sequence2
            // 
            this.Sequence2.Location = new System.Drawing.Point(555, 36);
            this.Sequence2.Multiline = true;
            this.Sequence2.Name = "Sequence2";
            this.Sequence2.Size = new System.Drawing.Size(315, 220);
            this.Sequence2.TabIndex = 3;
            // 
            // alignBtn
            // 
            this.alignBtn.Location = new System.Drawing.Point(393, 294);
            this.alignBtn.Name = "alignBtn";
            this.alignBtn.Size = new System.Drawing.Size(136, 54);
            this.alignBtn.TabIndex = 4;
            this.alignBtn.Text = "Align Sequences";
            this.alignBtn.UseVisualStyleBackColor = true;
            this.alignBtn.Click += new System.EventHandler(this.alignBtn_Click);
            // 
            // importSequence1Btn
            // 
            this.importSequence1Btn.Location = new System.Drawing.Point(149, 262);
            this.importSequence1Btn.Name = "importSequence1Btn";
            this.importSequence1Btn.Size = new System.Drawing.Size(124, 36);
            this.importSequence1Btn.TabIndex = 5;
            this.importSequence1Btn.Text = "Import Sequence";
            this.importSequence1Btn.UseVisualStyleBackColor = true;
            this.importSequence1Btn.Click += new System.EventHandler(this.importSequence1Btn_Click);
            // 
            // ImportSequence2Btn
            // 
            this.ImportSequence2Btn.Location = new System.Drawing.Point(655, 262);
            this.ImportSequence2Btn.Name = "ImportSequence2Btn";
            this.ImportSequence2Btn.Size = new System.Drawing.Size(124, 36);
            this.ImportSequence2Btn.TabIndex = 6;
            this.ImportSequence2Btn.Text = "Import Sequence";
            this.ImportSequence2Btn.UseVisualStyleBackColor = true;
            this.ImportSequence2Btn.Click += new System.EventHandler(this.ImportSequence2Btn_Click);
            // 
            // OutputSequence1
            // 
            this.OutputSequence1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputSequence1.Location = new System.Drawing.Point(36, 369);
            this.OutputSequence1.Name = "OutputSequence1";
            this.OutputSequence1.Size = new System.Drawing.Size(850, 20);
            this.OutputSequence1.TabIndex = 7;
            // 
            // OutputSequence2
            // 
            this.OutputSequence2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputSequence2.Location = new System.Drawing.Point(36, 395);
            this.OutputSequence2.Name = "OutputSequence2";
            this.OutputSequence2.Size = new System.Drawing.Size(850, 20);
            this.OutputSequence2.TabIndex = 8;
            // 
            // OutputSequence1Lbl
            // 
            this.OutputSequence1Lbl.AutoSize = true;
            this.OutputSequence1Lbl.Location = new System.Drawing.Point(33, 353);
            this.OutputSequence1Lbl.Name = "OutputSequence1Lbl";
            this.OutputSequence1Lbl.Size = new System.Drawing.Size(117, 13);
            this.OutputSequence1Lbl.TabIndex = 9;
            this.OutputSequence1Lbl.Text = "Aligned Sequence One";
            // 
            // OutputSequence2Lbl
            // 
            this.OutputSequence2Lbl.AutoSize = true;
            this.OutputSequence2Lbl.Location = new System.Drawing.Point(33, 418);
            this.OutputSequence2Lbl.Name = "OutputSequence2Lbl";
            this.OutputSequence2Lbl.Size = new System.Drawing.Size(118, 13);
            this.OutputSequence2Lbl.TabIndex = 10;
            this.OutputSequence2Lbl.Text = "Aligned Sequence Two";
            // 
            // ExportSequencesBtn
            // 
            this.ExportSequencesBtn.Location = new System.Drawing.Point(393, 418);
            this.ExportSequencesBtn.Name = "ExportSequencesBtn";
            this.ExportSequencesBtn.Size = new System.Drawing.Size(136, 54);
            this.ExportSequencesBtn.TabIndex = 11;
            this.ExportSequencesBtn.Text = "Export Sequences";
            this.ExportSequencesBtn.UseVisualStyleBackColor = true;
            this.ExportSequencesBtn.Click += new System.EventHandler(this.ExportSequencesBtn_Click);
            // 
            // MatchScore
            // 
            this.MatchScore.Location = new System.Drawing.Point(449, 79);
            this.MatchScore.Name = "MatchScore";
            this.MatchScore.Size = new System.Drawing.Size(22, 20);
            this.MatchScore.TabIndex = 12;
            this.MatchScore.Text = "5";
            // 
            // MismatchScore
            // 
            this.MismatchScore.Location = new System.Drawing.Point(449, 133);
            this.MismatchScore.Name = "MismatchScore";
            this.MismatchScore.Size = new System.Drawing.Size(22, 20);
            this.MismatchScore.TabIndex = 13;
            this.MismatchScore.Text = "2";
            // 
            // GapScore
            // 
            this.GapScore.Location = new System.Drawing.Point(449, 180);
            this.GapScore.Name = "GapScore";
            this.GapScore.Size = new System.Drawing.Size(24, 20);
            this.GapScore.TabIndex = 14;
            this.GapScore.Text = "-2";
            // 
            // MatchScoreLbl
            // 
            this.MatchScoreLbl.AutoSize = true;
            this.MatchScoreLbl.Location = new System.Drawing.Point(431, 63);
            this.MatchScoreLbl.Name = "MatchScoreLbl";
            this.MatchScoreLbl.Size = new System.Drawing.Size(68, 13);
            this.MatchScoreLbl.TabIndex = 15;
            this.MatchScoreLbl.Text = "Match Score";
            // 
            // MismatchScoreLbl
            // 
            this.MismatchScoreLbl.AutoSize = true;
            this.MismatchScoreLbl.Location = new System.Drawing.Point(421, 117);
            this.MismatchScoreLbl.Name = "MismatchScoreLbl";
            this.MismatchScoreLbl.Size = new System.Drawing.Size(83, 13);
            this.MismatchScoreLbl.TabIndex = 16;
            this.MismatchScoreLbl.Text = "Mismatch Score";
            // 
            // GapScoreLbl
            // 
            this.GapScoreLbl.AutoSize = true;
            this.GapScoreLbl.Location = new System.Drawing.Point(431, 164);
            this.GapScoreLbl.Name = "GapScoreLbl";
            this.GapScoreLbl.Size = new System.Drawing.Size(58, 13);
            this.GapScoreLbl.TabIndex = 17;
            this.GapScoreLbl.Text = "Gap Score";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 481);
            this.Controls.Add(this.GapScoreLbl);
            this.Controls.Add(this.MismatchScoreLbl);
            this.Controls.Add(this.MatchScoreLbl);
            this.Controls.Add(this.GapScore);
            this.Controls.Add(this.MismatchScore);
            this.Controls.Add(this.MatchScore);
            this.Controls.Add(this.ExportSequencesBtn);
            this.Controls.Add(this.OutputSequence2Lbl);
            this.Controls.Add(this.OutputSequence1Lbl);
            this.Controls.Add(this.OutputSequence2);
            this.Controls.Add(this.OutputSequence1);
            this.Controls.Add(this.ImportSequence2Btn);
            this.Controls.Add(this.importSequence1Btn);
            this.Controls.Add(this.alignBtn);
            this.Controls.Add(this.Sequence2);
            this.Controls.Add(this.Sequence2Lbl);
            this.Controls.Add(this.Sequence1Lbl);
            this.Controls.Add(this.Sequence1);
            this.Name = "MainForm";
            this.Text = "DNA Alignment Tool with XY Bases";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sequence1;
        private System.Windows.Forms.Label Sequence1Lbl;
        private System.Windows.Forms.Label Sequence2Lbl;
        private System.Windows.Forms.TextBox Sequence2;
        private System.Windows.Forms.Button alignBtn;
        private System.Windows.Forms.Button importSequence1Btn;
        private System.Windows.Forms.Button ImportSequence2Btn;
        private System.Windows.Forms.TextBox OutputSequence1;
        private System.Windows.Forms.TextBox OutputSequence2;
        private System.Windows.Forms.Label OutputSequence1Lbl;
        private System.Windows.Forms.Label OutputSequence2Lbl;
        private System.Windows.Forms.Button ExportSequencesBtn;
        private System.Windows.Forms.TextBox MatchScore;
        private System.Windows.Forms.TextBox MismatchScore;
        private System.Windows.Forms.TextBox GapScore;
        private System.Windows.Forms.Label MatchScoreLbl;
        private System.Windows.Forms.Label MismatchScoreLbl;
        private System.Windows.Forms.Label GapScoreLbl;
    }
}

