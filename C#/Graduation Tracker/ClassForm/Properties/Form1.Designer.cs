namespace school_form
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
            this.lstDegrees = new System.Windows.Forms.ListBox();
            this.btnSelectMajor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRequiredClasses = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstElectiveClasses = new System.Windows.Forms.ListBox();
            this.lstTakenClasses = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRequiredClasses = new System.Windows.Forms.Button();
            this.btnElectives = new System.Windows.Forms.Button();
            this.lstSemester1 = new System.Windows.Forms.ListBox();
            this.lstSemester2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lstElectiveSelected = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstDegrees
            // 
            this.lstDegrees.FormattingEnabled = true;
            this.lstDegrees.Location = new System.Drawing.Point(41, 69);
            this.lstDegrees.Name = "lstDegrees";
            this.lstDegrees.Size = new System.Drawing.Size(120, 95);
            this.lstDegrees.TabIndex = 0;
            // 
            // btnSelectMajor
            // 
            this.btnSelectMajor.Location = new System.Drawing.Point(41, 184);
            this.btnSelectMajor.Name = "btnSelectMajor";
            this.btnSelectMajor.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMajor.TabIndex = 1;
            this.btnSelectMajor.Text = "Select Major";
            this.btnSelectMajor.UseVisualStyleBackColor = true;
            this.btnSelectMajor.Click += new System.EventHandler(this.btnSelectMajor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Degrees";
            // 
            // lstRequiredClasses
            // 
            this.lstRequiredClasses.FormattingEnabled = true;
            this.lstRequiredClasses.Location = new System.Drawing.Point(253, 52);
            this.lstRequiredClasses.Name = "lstRequiredClasses";
            this.lstRequiredClasses.Size = new System.Drawing.Size(120, 108);
            this.lstRequiredClasses.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Required Classes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elective Classes";
            // 
            // lstElectiveClasses
            // 
            this.lstElectiveClasses.FormattingEnabled = true;
            this.lstElectiveClasses.Location = new System.Drawing.Point(253, 226);
            this.lstElectiveClasses.Name = "lstElectiveClasses";
            this.lstElectiveClasses.Size = new System.Drawing.Size(120, 121);
            this.lstElectiveClasses.TabIndex = 5;
            this.lstElectiveClasses.SelectedIndexChanged += new System.EventHandler(this.lstElectiveClasses_SelectedIndexChanged);
            // 
            // lstTakenClasses
            // 
            this.lstTakenClasses.FormattingEnabled = true;
            this.lstTakenClasses.Location = new System.Drawing.Point(469, 69);
            this.lstTakenClasses.Name = "lstTakenClasses";
            this.lstTakenClasses.Size = new System.Drawing.Size(120, 277);
            this.lstTakenClasses.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Taken Classes";
            // 
            // btnRequiredClasses
            // 
            this.btnRequiredClasses.Location = new System.Drawing.Point(379, 96);
            this.btnRequiredClasses.Name = "btnRequiredClasses";
            this.btnRequiredClasses.Size = new System.Drawing.Size(59, 23);
            this.btnRequiredClasses.TabIndex = 9;
            this.btnRequiredClasses.Text = "->";
            this.btnRequiredClasses.UseVisualStyleBackColor = true;
            this.btnRequiredClasses.Click += new System.EventHandler(this.btnRequiredClasses_Click);
            // 
            // btnElectives
            // 
            this.btnElectives.Location = new System.Drawing.Point(398, 418);
            this.btnElectives.Name = "btnElectives";
            this.btnElectives.Size = new System.Drawing.Size(59, 23);
            this.btnElectives.TabIndex = 10;
            this.btnElectives.Text = "->";
            this.btnElectives.UseVisualStyleBackColor = true;
            this.btnElectives.Click += new System.EventHandler(this.btnElectives_Click);
            // 
            // lstSemester1
            // 
            this.lstSemester1.FormattingEnabled = true;
            this.lstSemester1.Location = new System.Drawing.Point(617, 142);
            this.lstSemester1.Name = "lstSemester1";
            this.lstSemester1.Size = new System.Drawing.Size(120, 121);
            this.lstSemester1.TabIndex = 11;
            // 
            // lstSemester2
            // 
            this.lstSemester2.FormattingEnabled = true;
            this.lstSemester2.Location = new System.Drawing.Point(793, 142);
            this.lstSemester2.Name = "lstSemester2";
            this.lstSemester2.Size = new System.Drawing.Size(120, 121);
            this.lstSemester2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(617, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Generate Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Semester 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(790, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Semester 2";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(802, 90);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 20;
            // 
            // lstElectiveSelected
            // 
            this.lstElectiveSelected.FormattingEnabled = true;
            this.lstElectiveSelected.Location = new System.Drawing.Point(253, 383);
            this.lstElectiveSelected.Name = "lstElectiveSelected";
            this.lstElectiveSelected.Size = new System.Drawing.Size(120, 121);
            this.lstElectiveSelected.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 555);
            this.Controls.Add(this.lstElectiveSelected);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstSemester2);
            this.Controls.Add(this.lstSemester1);
            this.Controls.Add(this.btnElectives);
            this.Controls.Add(this.btnRequiredClasses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstTakenClasses);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstElectiveClasses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstRequiredClasses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectMajor);
            this.Controls.Add(this.lstDegrees);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDegrees;
        private System.Windows.Forms.Button btnSelectMajor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstRequiredClasses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstElectiveClasses;
        private System.Windows.Forms.ListBox lstTakenClasses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRequiredClasses;
        private System.Windows.Forms.Button btnElectives;
        private System.Windows.Forms.ListBox lstSemester1;
        private System.Windows.Forms.ListBox lstSemester2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ListBox lstElectiveSelected;
    }
}

