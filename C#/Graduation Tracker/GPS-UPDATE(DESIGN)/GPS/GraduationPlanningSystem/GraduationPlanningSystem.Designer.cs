namespace GraduationPlanningSystem
{
    partial class GraduationPlanningSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraduationPlanningSystem));
            this.label1 = new System.Windows.Forms.Label();
            this.comboMajor = new System.Windows.Forms.ComboBox();
            this.comboPosYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadSaved = new System.Windows.Forms.Button();
            this.btnLoadDefault = new System.Windows.Forms.Button();
            this.comboDefaulSchedules = new System.Windows.Forms.ComboBox();
            this.btnEditTaken = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(228, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAJOR";
            // 
            // comboMajor
            // 
            this.comboMajor.FormattingEnabled = true;
            this.comboMajor.Items.AddRange(new object[] {
            "Electrical Engineering",
            "Math",
            "History"});
            this.comboMajor.Location = new System.Drawing.Point(66, 51);
            this.comboMajor.Name = "comboMajor";
            this.comboMajor.Size = new System.Drawing.Size(137, 21);
            this.comboMajor.TabIndex = 2;
            // 
            // comboPosYear
            // 
            this.comboPosYear.FormattingEnabled = true;
            this.comboPosYear.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboPosYear.Location = new System.Drawing.Point(66, 93);
            this.comboPosYear.Name = "comboPosYear";
            this.comboPosYear.Size = new System.Drawing.Size(137, 21);
            this.comboPosYear.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(228, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "POS Year";
            // 
            // btnLoadSaved
            // 
            this.btnLoadSaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadSaved.Location = new System.Drawing.Point(66, 147);
            this.btnLoadSaved.Name = "btnLoadSaved";
            this.btnLoadSaved.Size = new System.Drawing.Size(137, 23);
            this.btnLoadSaved.TabIndex = 5;
            this.btnLoadSaved.Text = "Load Saved Schedule";
            this.btnLoadSaved.UseVisualStyleBackColor = true;
            // 
            // btnLoadDefault
            // 
            this.btnLoadDefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadDefault.Location = new System.Drawing.Point(66, 184);
            this.btnLoadDefault.Name = "btnLoadDefault";
            this.btnLoadDefault.Size = new System.Drawing.Size(137, 23);
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
            this.btnEditTaken.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditTaken.Location = new System.Drawing.Point(66, 224);
            this.btnEditTaken.Name = "btnEditTaken";
            this.btnEditTaken.Size = new System.Drawing.Size(137, 23);
            this.btnEditTaken.TabIndex = 8;
            this.btnEditTaken.Text = "Edit Taken Classes";
            this.btnEditTaken.UseVisualStyleBackColor = true;
            this.btnEditTaken.Click += new System.EventHandler(this.btnEditTaken_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(66, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Generate Schedules";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\Natalie\\Desktop\\GPS(Design)\\GPS1.htm";
            // 
            // GraduationPlanningSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(389, 319);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEditTaken);
            this.Controls.Add(this.comboDefaulSchedules);
            this.Controls.Add(this.btnLoadDefault);
            this.Controls.Add(this.btnLoadSaved);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPosYear);
            this.Controls.Add(this.comboMajor);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetHelpString(this, "Generate Schedule");
            this.Name = "GraduationPlanningSystem";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "GraduationPlanningSystem";
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
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

