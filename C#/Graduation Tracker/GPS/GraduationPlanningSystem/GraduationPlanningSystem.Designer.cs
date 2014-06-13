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
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadSaved = new System.Windows.Forms.Button();
            this.btnLoadDefault = new System.Windows.Forms.Button();
            this.comboDefaulSchedules = new System.Windows.Forms.ComboBox();
            this.btnEditTaken = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDegreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDegreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditTakednClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboPosYear = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(228, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAJOR";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.comboMajor.SelectionChangeCommitted += new System.EventHandler(this.comboMajor_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(228, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Graduation Deadline";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnLoadSaved
            // 
            this.btnLoadSaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadSaved.Location = new System.Drawing.Point(66, 178);
            this.btnLoadSaved.Name = "btnLoadSaved";
            this.btnLoadSaved.Size = new System.Drawing.Size(137, 23);
            this.btnLoadSaved.TabIndex = 5;
            this.btnLoadSaved.Text = "Load Saved Schedule";
            this.btnLoadSaved.UseVisualStyleBackColor = true;
            this.btnLoadSaved.Click += new System.EventHandler(this.btnLoadSaved_Click);
            // 
            // btnLoadDefault
            // 
            this.btnLoadDefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadDefault.Location = new System.Drawing.Point(66, 216);
            this.btnLoadDefault.Name = "btnLoadDefault";
            this.btnLoadDefault.Size = new System.Drawing.Size(137, 23);
            this.btnLoadDefault.TabIndex = 6;
            this.btnLoadDefault.Text = "Load Default Schedule";
            this.btnLoadDefault.UseVisualStyleBackColor = true;
            this.btnLoadDefault.Click += new System.EventHandler(this.btnLoadDefault_Click);
            // 
            // comboDefaulSchedules
            // 
            this.comboDefaulSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboDefaulSchedules.FormattingEnabled = true;
            this.comboDefaulSchedules.Items.AddRange(new object[] {
            "Default",
            "Required",
            "Elective"});
            this.comboDefaulSchedules.Location = new System.Drawing.Point(228, 217);
            this.comboDefaulSchedules.Name = "comboDefaulSchedules";
            this.comboDefaulSchedules.Size = new System.Drawing.Size(121, 21);
            this.comboDefaulSchedules.TabIndex = 7;
            // 
            // btnEditTaken
            // 
            this.btnEditTaken.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditTaken.Location = new System.Drawing.Point(66, 140);
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
            this.button1.Location = new System.Drawing.Point(66, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Create Custom Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viedToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(390, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDegreeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadDegreeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDegreeToolStripMenuItem
            // 
            this.newDegreeToolStripMenuItem.Name = "newDegreeToolStripMenuItem";
            this.newDegreeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newDegreeToolStripMenuItem.Text = "New Degree";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadDegreeToolStripMenuItem
            // 
            this.loadDegreeToolStripMenuItem.Name = "loadDegreeToolStripMenuItem";
            this.loadDegreeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadDegreeToolStripMenuItem.Text = "Load Degree";
            this.loadDegreeToolStripMenuItem.Click += new System.EventHandler(this.loadDegreeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viedToolStripMenuItem
            // 
            this.viedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewEditTakednClassesToolStripMenuItem,
            this.schedulesToolStripMenuItem});
            this.viedToolStripMenuItem.Name = "viedToolStripMenuItem";
            this.viedToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viedToolStripMenuItem.Text = "View";
            // 
            // viewEditTakednClassesToolStripMenuItem
            // 
            this.viewEditTakednClassesToolStripMenuItem.Name = "viewEditTakednClassesToolStripMenuItem";
            this.viewEditTakednClassesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewEditTakednClassesToolStripMenuItem.Text = "View/Edit Taken Classes";
            // 
            // schedulesToolStripMenuItem
            // 
            this.schedulesToolStripMenuItem.Name = "schedulesToolStripMenuItem";
            this.schedulesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.schedulesToolStripMenuItem.Text = "Schedules";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // comboPosYear
            // 
            this.comboPosYear.FormattingEnabled = true;
            this.comboPosYear.Items.AddRange(new object[] {
            "Spring 2014",
            "Summer 2014",
            "Fall 2015",
            "Spring 2015",
            "Summer 2015",
            "Fall 2016",
            "Spring 2016",
            "Summer 2016",
            "Fall 2017",
            "Spring 2017",
            "Summer 2017",
            "Fall 2018",
            "Spring 2018",
            "Summer 2018",
            "Fall 2018"});
            this.comboPosYear.Location = new System.Drawing.Point(66, 93);
            this.comboPosYear.Name = "comboPosYear";
            this.comboPosYear.Size = new System.Drawing.Size(137, 21);
            this.comboPosYear.TabIndex = 3;
            this.comboPosYear.SelectedIndexChanged += new System.EventHandler(this.comboPosYear_SelectedIndexChanged);
            // 
            // GraduationPlanningSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(390, 315);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEditTaken);
            this.Controls.Add(this.comboDefaulSchedules);
            this.Controls.Add(this.btnLoadDefault);
            this.Controls.Add(this.btnLoadSaved);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPosYear);
            this.Controls.Add(this.comboMajor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraduationPlanningSystem";
            this.Text = "Graduation Planning System";
            this.Load += new System.EventHandler(this.GraduationPlanningSystem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMajor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadSaved;
        private System.Windows.Forms.Button btnLoadDefault;
        private System.Windows.Forms.ComboBox comboDefaulSchedules;
        private System.Windows.Forms.Button btnEditTaken;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDegreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDegreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditTakednClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboPosYear;
    }
}

