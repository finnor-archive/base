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
            this.NaturalMatchScore = new System.Windows.Forms.TextBox();
            this.NaturalMismatchScore = new System.Windows.Forms.TextBox();
            this.NaturalGapScore = new System.Windows.Forms.TextBox();
            this.NaturalMatchScoreLbl = new System.Windows.Forms.Label();
            this.NaturalMismatchScoreLbl = new System.Windows.Forms.Label();
            this.NaturalGapScoreLbl = new System.Windows.Forms.Label();
            this.SimilarityScore = new System.Windows.Forms.TextBox();
            this.SimilarityScoreLbl = new System.Windows.Forms.Label();
            this.ExoticGapScoreLbl = new System.Windows.Forms.Label();
            this.ExoticMismatchScoreLbl = new System.Windows.Forms.Label();
            this.ExoticMatchScoreLbl = new System.Windows.Forms.Label();
            this.ExoticGapScore = new System.Windows.Forms.TextBox();
            this.ExoticMismatchScore = new System.Windows.Forms.TextBox();
            this.ExoticMatchScore = new System.Windows.Forms.TextBox();
            this.Format1Lbl = new System.Windows.Forms.Label();
            this.Format2Lbl = new System.Windows.Forms.Label();
            this.FormatOLbl = new System.Windows.Forms.Label();
            this.FormatBox1 = new System.Windows.Forms.ComboBox();
            this.FormatBox2 = new System.Windows.Forms.ComboBox();
            this.FormatBoxO = new System.Windows.Forms.ComboBox();
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
            this.Sequence2Lbl.Location = new System.Drawing.Point(390, 20);
            this.Sequence2Lbl.Name = "Sequence2Lbl";
            this.Sequence2Lbl.Size = new System.Drawing.Size(80, 13);
            this.Sequence2Lbl.TabIndex = 2;
            this.Sequence2Lbl.Text = "Sequence Two";
            // 
            // Sequence2
            // 
            this.Sequence2.Location = new System.Drawing.Point(393, 36);
            this.Sequence2.Multiline = true;
            this.Sequence2.Name = "Sequence2";
            this.Sequence2.Size = new System.Drawing.Size(315, 220);
            this.Sequence2.TabIndex = 3;
            // 
            // alignBtn
            // 
            this.alignBtn.Location = new System.Drawing.Point(770, 188);
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
            this.ImportSequence2Btn.Location = new System.Drawing.Point(486, 262);
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
            this.OutputSequence1.Size = new System.Drawing.Size(907, 20);
            this.OutputSequence1.TabIndex = 7;
            // 
            // OutputSequence2
            // 
            this.OutputSequence2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputSequence2.Location = new System.Drawing.Point(36, 395);
            this.OutputSequence2.Name = "OutputSequence2";
            this.OutputSequence2.Size = new System.Drawing.Size(907, 20);
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
            // NaturalMatchScore
            // 
            this.NaturalMatchScore.Location = new System.Drawing.Point(864, 36);
            this.NaturalMatchScore.Name = "NaturalMatchScore";
            this.NaturalMatchScore.Size = new System.Drawing.Size(22, 20);
            this.NaturalMatchScore.TabIndex = 12;
            this.NaturalMatchScore.Text = "5";
            // 
            // NaturalMismatchScore
            // 
            this.NaturalMismatchScore.Location = new System.Drawing.Point(864, 52);
            this.NaturalMismatchScore.Name = "NaturalMismatchScore";
            this.NaturalMismatchScore.Size = new System.Drawing.Size(22, 20);
            this.NaturalMismatchScore.TabIndex = 13;
            this.NaturalMismatchScore.Text = "2";
            // 
            // NaturalGapScore
            // 
            this.NaturalGapScore.Location = new System.Drawing.Point(864, 70);
            this.NaturalGapScore.Name = "NaturalGapScore";
            this.NaturalGapScore.Size = new System.Drawing.Size(22, 20);
            this.NaturalGapScore.TabIndex = 14;
            this.NaturalGapScore.Text = "-2";
            // 
            // NaturalMatchScoreLbl
            // 
            this.NaturalMatchScoreLbl.AutoSize = true;
            this.NaturalMatchScoreLbl.Location = new System.Drawing.Point(722, 39);
            this.NaturalMatchScoreLbl.Name = "NaturalMatchScoreLbl";
            this.NaturalMatchScoreLbl.Size = new System.Drawing.Size(105, 13);
            this.NaturalMatchScoreLbl.TabIndex = 15;
            this.NaturalMatchScoreLbl.Text = "Natural Match Score";
            // 
            // NaturalMismatchScoreLbl
            // 
            this.NaturalMismatchScoreLbl.AutoSize = true;
            this.NaturalMismatchScoreLbl.Location = new System.Drawing.Point(722, 59);
            this.NaturalMismatchScoreLbl.Name = "NaturalMismatchScoreLbl";
            this.NaturalMismatchScoreLbl.Size = new System.Drawing.Size(120, 13);
            this.NaturalMismatchScoreLbl.TabIndex = 16;
            this.NaturalMismatchScoreLbl.Text = "Natural Mismatch Score";
            // 
            // NaturalGapScoreLbl
            // 
            this.NaturalGapScoreLbl.AutoSize = true;
            this.NaturalGapScoreLbl.Location = new System.Drawing.Point(722, 77);
            this.NaturalGapScoreLbl.Name = "NaturalGapScoreLbl";
            this.NaturalGapScoreLbl.Size = new System.Drawing.Size(95, 13);
            this.NaturalGapScoreLbl.TabIndex = 17;
            this.NaturalGapScoreLbl.Text = "Natural Gap Score";
            // 
            // SimilarityScore
            // 
            this.SimilarityScore.Location = new System.Drawing.Point(770, 436);
            this.SimilarityScore.Name = "SimilarityScore";
            this.SimilarityScore.Size = new System.Drawing.Size(100, 20);
            this.SimilarityScore.TabIndex = 18;
            // 
            // SimilarityScoreLbl
            // 
            this.SimilarityScoreLbl.AutoSize = true;
            this.SimilarityScoreLbl.Location = new System.Drawing.Point(686, 439);
            this.SimilarityScoreLbl.Name = "SimilarityScoreLbl";
            this.SimilarityScoreLbl.Size = new System.Drawing.Size(78, 13);
            this.SimilarityScoreLbl.TabIndex = 19;
            this.SimilarityScoreLbl.Text = "Similarity Score";
            // 
            // ExoticGapScoreLbl
            // 
            this.ExoticGapScoreLbl.AutoSize = true;
            this.ExoticGapScoreLbl.Location = new System.Drawing.Point(722, 149);
            this.ExoticGapScoreLbl.Name = "ExoticGapScoreLbl";
            this.ExoticGapScoreLbl.Size = new System.Drawing.Size(90, 13);
            this.ExoticGapScoreLbl.TabIndex = 25;
            this.ExoticGapScoreLbl.Text = "Exotic Gap Score";
            // 
            // ExoticMismatchScoreLbl
            // 
            this.ExoticMismatchScoreLbl.AutoSize = true;
            this.ExoticMismatchScoreLbl.Location = new System.Drawing.Point(722, 131);
            this.ExoticMismatchScoreLbl.Name = "ExoticMismatchScoreLbl";
            this.ExoticMismatchScoreLbl.Size = new System.Drawing.Size(115, 13);
            this.ExoticMismatchScoreLbl.TabIndex = 24;
            this.ExoticMismatchScoreLbl.Text = "Exotic Mismatch Score";
            // 
            // ExoticMatchScoreLbl
            // 
            this.ExoticMatchScoreLbl.AutoSize = true;
            this.ExoticMatchScoreLbl.Location = new System.Drawing.Point(722, 111);
            this.ExoticMatchScoreLbl.Name = "ExoticMatchScoreLbl";
            this.ExoticMatchScoreLbl.Size = new System.Drawing.Size(100, 13);
            this.ExoticMatchScoreLbl.TabIndex = 23;
            this.ExoticMatchScoreLbl.Text = "Exotic Match Score";
            // 
            // ExoticGapScore
            // 
            this.ExoticGapScore.Location = new System.Drawing.Point(864, 142);
            this.ExoticGapScore.Name = "ExoticGapScore";
            this.ExoticGapScore.Size = new System.Drawing.Size(22, 20);
            this.ExoticGapScore.TabIndex = 22;
            this.ExoticGapScore.Text = "-3";
            // 
            // ExoticMismatchScore
            // 
            this.ExoticMismatchScore.Location = new System.Drawing.Point(864, 124);
            this.ExoticMismatchScore.Name = "ExoticMismatchScore";
            this.ExoticMismatchScore.Size = new System.Drawing.Size(22, 20);
            this.ExoticMismatchScore.TabIndex = 21;
            this.ExoticMismatchScore.Text = "-2";
            // 
            // ExoticMatchScore
            // 
            this.ExoticMatchScore.Location = new System.Drawing.Point(864, 108);
            this.ExoticMatchScore.Name = "ExoticMatchScore";
            this.ExoticMatchScore.Size = new System.Drawing.Size(22, 20);
            this.ExoticMatchScore.TabIndex = 20;
            this.ExoticMatchScore.Text = "7";
            // 
            // Format1Lbl
            // 
            this.Format1Lbl.AutoSize = true;
            this.Format1Lbl.Location = new System.Drawing.Point(293, 262);
            this.Format1Lbl.Name = "Format1Lbl";
            this.Format1Lbl.Size = new System.Drawing.Size(39, 13);
            this.Format1Lbl.TabIndex = 28;
            this.Format1Lbl.Text = "Format";
            // 
            // Format2Lbl
            // 
            this.Format2Lbl.AutoSize = true;
            this.Format2Lbl.Location = new System.Drawing.Point(623, 262);
            this.Format2Lbl.Name = "Format2Lbl";
            this.Format2Lbl.Size = new System.Drawing.Size(39, 13);
            this.Format2Lbl.TabIndex = 29;
            this.Format2Lbl.Text = "Format";
            // 
            // FormatOLbl
            // 
            this.FormatOLbl.AutoSize = true;
            this.FormatOLbl.Location = new System.Drawing.Point(535, 420);
            this.FormatOLbl.Name = "FormatOLbl";
            this.FormatOLbl.Size = new System.Drawing.Size(39, 13);
            this.FormatOLbl.TabIndex = 31;
            this.FormatOLbl.Text = "Format";
            // 
            // FormatBox1
            // 
            this.FormatBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBox1.FormattingEnabled = true;
            this.FormatBox1.Items.AddRange(new object[] {
            "Raw",
            "FASTA"});
            this.FormatBox1.Location = new System.Drawing.Point(296, 277);
            this.FormatBox1.Name = "FormatBox1";
            this.FormatBox1.Size = new System.Drawing.Size(79, 21);
            this.FormatBox1.TabIndex = 32;
            // 
            // FormatBox2
            // 
            this.FormatBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBox2.FormattingEnabled = true;
            this.FormatBox2.Items.AddRange(new object[] {
            "Raw",
            "FASTA"});
            this.FormatBox2.Location = new System.Drawing.Point(626, 278);
            this.FormatBox2.Name = "FormatBox2";
            this.FormatBox2.Size = new System.Drawing.Size(79, 21);
            this.FormatBox2.TabIndex = 33;
            // 
            // FormatBoxO
            // 
            this.FormatBoxO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBoxO.FormattingEnabled = true;
            this.FormatBoxO.Items.AddRange(new object[] {
            "Raw",
            "FASTA"});
            this.FormatBoxO.Location = new System.Drawing.Point(538, 435);
            this.FormatBoxO.Name = "FormatBoxO";
            this.FormatBoxO.Size = new System.Drawing.Size(79, 21);
            this.FormatBoxO.TabIndex = 34;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 481);
            this.Controls.Add(this.FormatBoxO);
            this.Controls.Add(this.FormatBox2);
            this.Controls.Add(this.FormatBox1);
            this.Controls.Add(this.FormatOLbl);
            this.Controls.Add(this.Format2Lbl);
            this.Controls.Add(this.Format1Lbl);
            this.Controls.Add(this.ExoticGapScoreLbl);
            this.Controls.Add(this.ExoticMismatchScoreLbl);
            this.Controls.Add(this.ExoticMatchScoreLbl);
            this.Controls.Add(this.ExoticGapScore);
            this.Controls.Add(this.ExoticMismatchScore);
            this.Controls.Add(this.ExoticMatchScore);
            this.Controls.Add(this.SimilarityScoreLbl);
            this.Controls.Add(this.SimilarityScore);
            this.Controls.Add(this.NaturalGapScoreLbl);
            this.Controls.Add(this.NaturalMismatchScoreLbl);
            this.Controls.Add(this.NaturalMatchScoreLbl);
            this.Controls.Add(this.NaturalGapScore);
            this.Controls.Add(this.NaturalMismatchScore);
            this.Controls.Add(this.NaturalMatchScore);
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
        private System.Windows.Forms.TextBox NaturalMatchScore;
        private System.Windows.Forms.TextBox NaturalMismatchScore;
        private System.Windows.Forms.TextBox NaturalGapScore;
        private System.Windows.Forms.Label NaturalMatchScoreLbl;
        private System.Windows.Forms.Label NaturalMismatchScoreLbl;
        private System.Windows.Forms.Label NaturalGapScoreLbl;
        private System.Windows.Forms.TextBox SimilarityScore;
        private System.Windows.Forms.Label SimilarityScoreLbl;
        private System.Windows.Forms.Label ExoticGapScoreLbl;
        private System.Windows.Forms.Label ExoticMismatchScoreLbl;
        private System.Windows.Forms.Label ExoticMatchScoreLbl;
        private System.Windows.Forms.TextBox ExoticGapScore;
        private System.Windows.Forms.TextBox ExoticMismatchScore;
        private System.Windows.Forms.TextBox ExoticMatchScore;
        private System.Windows.Forms.Label Format1Lbl;
        private System.Windows.Forms.Label Format2Lbl;
        private System.Windows.Forms.Label FormatOLbl;
        private System.Windows.Forms.ComboBox FormatBox1;
        private System.Windows.Forms.ComboBox FormatBox2;
        private System.Windows.Forms.ComboBox FormatBoxO;
    }
}

