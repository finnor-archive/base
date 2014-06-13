namespace GraduationPlanningSystem
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboMajor = new System.Windows.Forms.ComboBox();
            this.comboPosYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadSaved = new System.Windows.Forms.Button();
            this.btnLoadDefault = new System.Windows.Forms.Button();
            this.comboDefaulSchedules = new System.Windows.Forms.ComboBox();
            this.btnEditTaken = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Major";
            // 
            // comboMajor
            // 
            this.comboMajor.FormattingEnabled = true;
            this.comboMajor.Location = new System.Drawing.Point(66, 51);
            this.comboMajor.Name = "comboMajor";
            this.comboMajor.Size = new System.Drawing.Size(121, 21);
            this.comboMajor.TabIndex = 2;
            this.comboMajor.SelectedIndexChanged += new System.EventHandler(this.comboMajor_SelectedIndexChanged);
            // 
            // comboPosYear
            // 
            this.comboPosYear.FormattingEnabled = true;
            this.comboPosYear.Location = new System.Drawing.Point(66, 93);
            this.comboPosYear.Name = "comboPosYear";
            this.comboPosYear.Size = new System.Drawing.Size(121, 21);
            this.comboPosYear.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "POS Year";
            // 
            // btnLoadSaved
            // 
            this.btnLoadSaved.Location = new System.Drawing.Point(66, 147);
            this.btnLoadSaved.Name = "btnLoadSaved";
            this.btnLoadSaved.Size = new System.Drawing.Size(121, 23);
            this.btnLoadSaved.TabIndex = 5;
            this.btnLoadSaved.Text = "Load Saved Schedule";
            this.btnLoadSaved.UseVisualStyleBackColor = true;
            // 
            // btnLoadDefault
            // 
            this.btnLoadDefault.Location = new System.Drawing.Point(66, 184);
            this.btnLoadDefault.Name = "btnLoadDefault";
            this.btnLoadDefault.Size = new System.Drawing.Size(121, 23);
            this.btnLoadDefault.TabIndex = 6;
            this.btnLoadDefault.Text = "Load Default Schedule";
            this.btnLoadDefault.UseVisualStyleBackColor = true;
            // 
            // comboDefaulSchedules
            // 
            this.comboDefaulSchedules.FormattingEnabled = true;
            this.comboDefaulSchedules.Location = new System.Drawing.Point(231, 184);
            this.comboDefaulSchedules.Name = "comboDefaulSchedules";
            this.comboDefaulSchedules.Size = new System.Drawing.Size(121, 21);
            this.comboDefaulSchedules.TabIndex = 7;
            // 
            // btnEditTaken
            // 
            this.btnEditTaken.Location = new System.Drawing.Point(66, 224);
            this.btnEditTaken.Name = "btnEditTaken";
            this.btnEditTaken.Size = new System.Drawing.Size(121, 23);
            this.btnEditTaken.TabIndex = 8;
            this.btnEditTaken.Text = "Edit Taken Classes";
            this.btnEditTaken.UseVisualStyleBackColor = true;
            this.btnEditTaken.Click += new System.EventHandler(this.btnEditTaken_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Generate Schedules";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 292);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEditTaken);
            this.Controls.Add(this.comboDefaulSchedules);
            this.Controls.Add(this.btnLoadDefault);
            this.Controls.Add(this.btnLoadSaved);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPosYear);
            this.Controls.Add(this.comboMajor);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMajor;
        private System.Windows.Forms.ComboBox comboPosYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadSaved;
        private System.Windows.Forms.Button btnLoadDefault;
        private System.Windows.Forms.ComboBox comboDefaulSchedules;
        private System.Windows.Forms.Button btnEditTaken;
        private System.Windows.Forms.Button button1;
    }
}

