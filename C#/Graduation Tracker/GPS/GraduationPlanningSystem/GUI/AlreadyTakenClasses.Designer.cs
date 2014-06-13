namespace GraduationPlanningSystem
{
    partial class AlreadyTakenClasses
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlreadyTakenClasses));
            this.tabTakenClasses = new System.Windows.Forms.TabControl();
            this.tabRequirements = new System.Windows.Forms.TabPage();
            this.btnClassTaken100 = new System.Windows.Forms.Button();
            this.btnClassTaken400 = new System.Windows.Forms.Button();
            this.btnClassTaken300 = new System.Windows.Forms.Button();
            this.btnClassTaken200 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lst400 = new System.Windows.Forms.ListBox();
            this.lst300 = new System.Windows.Forms.ListBox();
            this.lst200 = new System.Windows.Forms.ListBox();
            this.lst100 = new System.Windows.Forms.ListBox();
            this.lstBoxPrereqs = new System.Windows.Forms.ListBox();
            this.txtBoxSemester = new System.Windows.Forms.TextBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.txtBoxHours = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtBoxDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtBoxCourseNumber = new System.Windows.Forms.TextBox();
            this.lblCourseNumber = new System.Windows.Forms.Label();
            this.txtBoxUID = new System.Windows.Forms.TextBox();
            this.lblUID = new System.Windows.Forms.Label();
            this.txtBoxCourseTitle = new System.Windows.Forms.TextBox();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.lblSelectedCourseInfo = new System.Windows.Forms.Label();
            this.lblPrereqs = new System.Windows.Forms.Label();
            this.lstBoxPreCoreqs = new System.Windows.Forms.ListBox();
            this.lstBoxCoreqs = new System.Windows.Forms.ListBox();
            this.lblPreCoreqs = new System.Windows.Forms.Label();
            this.lblCoreqs = new System.Windows.Forms.Label();
            this.btnClassRemoved = new System.Windows.Forms.Button();
            this.lstBoxClassesTaken = new System.Windows.Forms.ListBox();
            this.lblClassesTaken = new System.Windows.Forms.Label();
            this.btnSaveClasses = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.tabTakenClasses.SuspendLayout();
            this.tabRequirements.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTakenClasses
            // 
            this.tabTakenClasses.Controls.Add(this.tabRequirements);
            this.tabTakenClasses.Location = new System.Drawing.Point(127, 115);
            this.tabTakenClasses.Name = "tabTakenClasses";
            this.tabTakenClasses.SelectedIndex = 0;
            this.tabTakenClasses.Size = new System.Drawing.Size(639, 371);
            this.tabTakenClasses.TabIndex = 0;
            // 
            // tabRequirements
            // 
            this.tabRequirements.Controls.Add(this.btnClassTaken100);
            this.tabRequirements.Controls.Add(this.btnClassTaken400);
            this.tabRequirements.Controls.Add(this.btnClassTaken300);
            this.tabRequirements.Controls.Add(this.btnClassTaken200);
            this.tabRequirements.Controls.Add(this.label4);
            this.tabRequirements.Controls.Add(this.label3);
            this.tabRequirements.Controls.Add(this.label2);
            this.tabRequirements.Controls.Add(this.label1);
            this.tabRequirements.Controls.Add(this.lst400);
            this.tabRequirements.Controls.Add(this.lst300);
            this.tabRequirements.Controls.Add(this.lst200);
            this.tabRequirements.Controls.Add(this.lst100);
            this.tabRequirements.Location = new System.Drawing.Point(4, 22);
            this.tabRequirements.Name = "tabRequirements";
            this.tabRequirements.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequirements.Size = new System.Drawing.Size(631, 345);
            this.tabRequirements.TabIndex = 0;
            this.tabRequirements.Text = "Requirements";
            this.tabRequirements.UseVisualStyleBackColor = true;
            // 
            // btnClassTaken100
            // 
            this.btnClassTaken100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClassTaken100.Location = new System.Drawing.Point(43, 282);
            this.btnClassTaken100.Name = "btnClassTaken100";
            this.btnClassTaken100.Size = new System.Drawing.Size(92, 23);
            this.btnClassTaken100.TabIndex = 108;
            this.btnClassTaken100.Text = "Class Taken ->";
            this.toolTip3.SetToolTip(this.btnClassTaken100, "Select to Class to Move to Classes Taken Dialog");
            this.toolTip4.SetToolTip(this.btnClassTaken100, "Select to Class to Move to Classes Taken Dialog");
            this.toolTip1.SetToolTip(this.btnClassTaken100, "Select to Class to Move to Classes Taken Dialog");
            this.toolTip2.SetToolTip(this.btnClassTaken100, "Select to Class to Move to Classes Taken Dialog");
            this.btnClassTaken100.UseVisualStyleBackColor = true;
            this.btnClassTaken100.Click += new System.EventHandler(this.btnClassTaken100_Click);
            // 
            // btnClassTaken400
            // 
            this.btnClassTaken400.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClassTaken400.Location = new System.Drawing.Point(478, 282);
            this.btnClassTaken400.Name = "btnClassTaken400";
            this.btnClassTaken400.Size = new System.Drawing.Size(92, 23);
            this.btnClassTaken400.TabIndex = 107;
            this.btnClassTaken400.Text = "Class Taken ->";
            this.toolTip4.SetToolTip(this.btnClassTaken400, "Select to Class to Move to Classes Taken Dialog");
            this.btnClassTaken400.UseVisualStyleBackColor = true;
            this.btnClassTaken400.Click += new System.EventHandler(this.btnClassTaken400_Click);
            // 
            // btnClassTaken300
            // 
            this.btnClassTaken300.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClassTaken300.Location = new System.Drawing.Point(329, 282);
            this.btnClassTaken300.Name = "btnClassTaken300";
            this.btnClassTaken300.Size = new System.Drawing.Size(92, 23);
            this.btnClassTaken300.TabIndex = 106;
            this.btnClassTaken300.Text = "Class Taken ->";
            this.toolTip3.SetToolTip(this.btnClassTaken300, "Select to Class to Move to Classes Taken Dialog");
            this.btnClassTaken300.UseVisualStyleBackColor = true;
            this.btnClassTaken300.Click += new System.EventHandler(this.btnClassTaken300_Click);
            // 
            // btnClassTaken200
            // 
            this.btnClassTaken200.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClassTaken200.Location = new System.Drawing.Point(182, 282);
            this.btnClassTaken200.Name = "btnClassTaken200";
            this.btnClassTaken200.Size = new System.Drawing.Size(92, 23);
            this.btnClassTaken200.TabIndex = 105;
            this.btnClassTaken200.Text = "Class Taken ->";
            this.toolTip2.SetToolTip(this.btnClassTaken200, "Select to Class to Move to Classes Taken Dialog");
            this.btnClassTaken200.UseVisualStyleBackColor = true;
            this.btnClassTaken200.Click += new System.EventHandler(this.btnClassTaken200_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "400 Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "300 Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "200 Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "100 Level";
            // 
            // lst400
            // 
            this.lst400.FormattingEnabled = true;
            this.lst400.Location = new System.Drawing.Point(460, 77);
            this.lst400.Name = "lst400";
            this.lst400.Size = new System.Drawing.Size(132, 199);
            this.lst400.TabIndex = 3;
            this.lst400.SelectedIndexChanged += new System.EventHandler(this.lst400_SelectedIndexChanged);
            // 
            // lst300
            // 
            this.lst300.FormattingEnabled = true;
            this.lst300.Location = new System.Drawing.Point(308, 77);
            this.lst300.Name = "lst300";
            this.lst300.Size = new System.Drawing.Size(132, 199);
            this.lst300.TabIndex = 2;
            this.lst300.SelectedIndexChanged += new System.EventHandler(this.lst300_SelectedIndexChanged);
            // 
            // lst200
            // 
            this.lst200.FormattingEnabled = true;
            this.lst200.Location = new System.Drawing.Point(165, 77);
            this.lst200.Name = "lst200";
            this.lst200.Size = new System.Drawing.Size(132, 199);
            this.lst200.TabIndex = 1;
            this.lst200.SelectedIndexChanged += new System.EventHandler(this.lst200_SelectedIndexChanged);
            // 
            // lst100
            // 
            this.lst100.FormattingEnabled = true;
            this.lst100.Location = new System.Drawing.Point(25, 77);
            this.lst100.Name = "lst100";
            this.lst100.Size = new System.Drawing.Size(134, 199);
            this.lst100.TabIndex = 0;
            this.lst100.SelectedIndexChanged += new System.EventHandler(this.lst100_SelectedIndexChanged);
            // 
            // lstBoxPrereqs
            // 
            this.lstBoxPrereqs.FormattingEnabled = true;
            this.lstBoxPrereqs.Location = new System.Drawing.Point(521, 14);
            this.lstBoxPrereqs.Name = "lstBoxPrereqs";
            this.lstBoxPrereqs.Size = new System.Drawing.Size(78, 95);
            this.lstBoxPrereqs.TabIndex = 84;
            // 
            // txtBoxSemester
            // 
            this.txtBoxSemester.Location = new System.Drawing.Point(367, 63);
            this.txtBoxSemester.Name = "txtBoxSemester";
            this.txtBoxSemester.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSemester.TabIndex = 98;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(310, 66);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(51, 13);
            this.lblSemester.TabIndex = 97;
            this.lblSemester.Text = "Semester";
            // 
            // txtBoxHours
            // 
            this.txtBoxHours.Location = new System.Drawing.Point(367, 37);
            this.txtBoxHours.Name = "txtBoxHours";
            this.txtBoxHours.Size = new System.Drawing.Size(100, 20);
            this.txtBoxHours.TabIndex = 96;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(326, 40);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 95;
            this.lblHours.Text = "Hours";
            // 
            // txtBoxDepartment
            // 
            this.txtBoxDepartment.Location = new System.Drawing.Point(193, 37);
            this.txtBoxDepartment.Name = "txtBoxDepartment";
            this.txtBoxDepartment.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDepartment.TabIndex = 94;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(125, 40);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 93;
            this.lblDepartment.Text = "Department";
            // 
            // txtBoxCourseNumber
            // 
            this.txtBoxCourseNumber.Location = new System.Drawing.Point(193, 89);
            this.txtBoxCourseNumber.Name = "txtBoxCourseNumber";
            this.txtBoxCourseNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCourseNumber.TabIndex = 92;
            // 
            // lblCourseNumber
            // 
            this.lblCourseNumber.AutoSize = true;
            this.lblCourseNumber.Location = new System.Drawing.Point(107, 92);
            this.lblCourseNumber.Name = "lblCourseNumber";
            this.lblCourseNumber.Size = new System.Drawing.Size(80, 13);
            this.lblCourseNumber.TabIndex = 91;
            this.lblCourseNumber.Text = "Course Number";
            // 
            // txtBoxUID
            // 
            this.txtBoxUID.Location = new System.Drawing.Point(193, 63);
            this.txtBoxUID.Name = "txtBoxUID";
            this.txtBoxUID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUID.TabIndex = 90;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(161, 66);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(26, 13);
            this.lblUID.TabIndex = 89;
            this.lblUID.Text = "UID";
            // 
            // txtBoxCourseTitle
            // 
            this.txtBoxCourseTitle.Location = new System.Drawing.Point(193, 11);
            this.txtBoxCourseTitle.Name = "txtBoxCourseTitle";
            this.txtBoxCourseTitle.Size = new System.Drawing.Size(274, 20);
            this.txtBoxCourseTitle.TabIndex = 88;
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Location = new System.Drawing.Point(124, 11);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(63, 13);
            this.lblCourseTitle.TabIndex = 87;
            this.lblCourseTitle.Text = "Course Title";
            // 
            // lblSelectedCourseInfo
            // 
            this.lblSelectedCourseInfo.AutoSize = true;
            this.lblSelectedCourseInfo.Location = new System.Drawing.Point(13, 10);
            this.lblSelectedCourseInfo.Name = "lblSelectedCourseInfo";
            this.lblSelectedCourseInfo.Size = new System.Drawing.Size(106, 13);
            this.lblSelectedCourseInfo.TabIndex = 86;
            this.lblSelectedCourseInfo.Text = "Selected Course Info";
            // 
            // lblPrereqs
            // 
            this.lblPrereqs.AutoSize = true;
            this.lblPrereqs.Location = new System.Drawing.Point(472, 14);
            this.lblPrereqs.Name = "lblPrereqs";
            this.lblPrereqs.Size = new System.Drawing.Size(43, 13);
            this.lblPrereqs.TabIndex = 85;
            this.lblPrereqs.Text = "Prereqs";
            // 
            // lstBoxPreCoreqs
            // 
            this.lstBoxPreCoreqs.FormattingEnabled = true;
            this.lstBoxPreCoreqs.Location = new System.Drawing.Point(807, 14);
            this.lstBoxPreCoreqs.Name = "lstBoxPreCoreqs";
            this.lstBoxPreCoreqs.Size = new System.Drawing.Size(80, 95);
            this.lstBoxPreCoreqs.TabIndex = 102;
            // 
            // lstBoxCoreqs
            // 
            this.lstBoxCoreqs.FormattingEnabled = true;
            this.lstBoxCoreqs.Location = new System.Drawing.Point(652, 14);
            this.lstBoxCoreqs.Name = "lstBoxCoreqs";
            this.lstBoxCoreqs.Size = new System.Drawing.Size(78, 95);
            this.lstBoxCoreqs.TabIndex = 101;
            // 
            // lblPreCoreqs
            // 
            this.lblPreCoreqs.AutoSize = true;
            this.lblPreCoreqs.Location = new System.Drawing.Point(740, 17);
            this.lblPreCoreqs.Name = "lblPreCoreqs";
            this.lblPreCoreqs.Size = new System.Drawing.Size(61, 13);
            this.lblPreCoreqs.TabIndex = 100;
            this.lblPreCoreqs.Text = "Pre/Coreqs";
            // 
            // lblCoreqs
            // 
            this.lblCoreqs.AutoSize = true;
            this.lblCoreqs.Location = new System.Drawing.Point(606, 17);
            this.lblCoreqs.Name = "lblCoreqs";
            this.lblCoreqs.Size = new System.Drawing.Size(40, 13);
            this.lblCoreqs.TabIndex = 99;
            this.lblCoreqs.Text = "Coreqs";
            // 
            // btnClassRemoved
            // 
            this.btnClassRemoved.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClassRemoved.Location = new System.Drawing.Point(795, 422);
            this.btnClassRemoved.Name = "btnClassRemoved";
            this.btnClassRemoved.Size = new System.Drawing.Size(102, 23);
            this.btnClassRemoved.TabIndex = 104;
            this.btnClassRemoved.Text = "Remove Class";
            this.btnClassRemoved.UseVisualStyleBackColor = true;
            this.btnClassRemoved.Click += new System.EventHandler(this.btnClassRemoved_Click);
            // 
            // lstBoxClassesTaken
            // 
            this.lstBoxClassesTaken.FormattingEnabled = true;
            this.lstBoxClassesTaken.Location = new System.Drawing.Point(777, 139);
            this.lstBoxClassesTaken.Name = "lstBoxClassesTaken";
            this.lstBoxClassesTaken.Size = new System.Drawing.Size(132, 277);
            this.lstBoxClassesTaken.TabIndex = 105;
            this.lstBoxClassesTaken.SelectedIndexChanged += new System.EventHandler(this.lstBoxClassesTaken_SelectedIndexChanged);
            // 
            // lblClassesTaken
            // 
            this.lblClassesTaken.AutoSize = true;
            this.lblClassesTaken.Location = new System.Drawing.Point(774, 123);
            this.lblClassesTaken.Name = "lblClassesTaken";
            this.lblClassesTaken.Size = new System.Drawing.Size(77, 13);
            this.lblClassesTaken.TabIndex = 106;
            this.lblClassesTaken.Text = "Classes Taken";
            // 
            // btnSaveClasses
            // 
            this.btnSaveClasses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveClasses.Location = new System.Drawing.Point(795, 459);
            this.btnSaveClasses.Name = "btnSaveClasses";
            this.btnSaveClasses.Size = new System.Drawing.Size(102, 23);
            this.btnSaveClasses.TabIndex = 109;
            this.btnSaveClasses.Text = "Save List";
            this.btnSaveClasses.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSaveClasses.UseVisualStyleBackColor = true;
            this.btnSaveClasses.Click += new System.EventHandler(this.btnSaveClasses_Click);
            // 
            // AlreadyTakenClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1007, 544);
            this.Controls.Add(this.btnSaveClasses);
            this.Controls.Add(this.lblClassesTaken);
            this.Controls.Add(this.lstBoxClassesTaken);
            this.Controls.Add(this.lstBoxPreCoreqs);
            this.Controls.Add(this.btnClassRemoved);
            this.Controls.Add(this.lstBoxCoreqs);
            this.Controls.Add(this.lblPreCoreqs);
            this.Controls.Add(this.lblCoreqs);
            this.Controls.Add(this.lstBoxPrereqs);
            this.Controls.Add(this.txtBoxSemester);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.txtBoxHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtBoxDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtBoxCourseNumber);
            this.Controls.Add(this.lblCourseNumber);
            this.Controls.Add(this.txtBoxUID);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.txtBoxCourseTitle);
            this.Controls.Add(this.lblCourseTitle);
            this.Controls.Add(this.lblSelectedCourseInfo);
            this.Controls.Add(this.lblPrereqs);
            this.Controls.Add(this.tabTakenClasses);
            this.DoubleBuffered = true;
            this.Name = "AlreadyTakenClasses";
            this.Text = "AlreadyTakenClasses";
            this.Load += new System.EventHandler(this.AlreadyTakenClasses_Load);
            this.tabTakenClasses.ResumeLayout(false);
            this.tabRequirements.ResumeLayout(false);
            this.tabRequirements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabTakenClasses;
        private System.Windows.Forms.TabPage tabRequirements;
        private System.Windows.Forms.ListBox lst200;
        private System.Windows.Forms.ListBox lst100;
        private System.Windows.Forms.ListBox lst400;
        private System.Windows.Forms.ListBox lst300;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxPrereqs;
        private System.Windows.Forms.TextBox txtBoxSemester;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.TextBox txtBoxHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtBoxDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtBoxCourseNumber;
        private System.Windows.Forms.Label lblCourseNumber;
        private System.Windows.Forms.TextBox txtBoxUID;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.TextBox txtBoxCourseTitle;
        private System.Windows.Forms.Label lblCourseTitle;
        private System.Windows.Forms.Label lblSelectedCourseInfo;
        private System.Windows.Forms.Label lblPrereqs;
        private System.Windows.Forms.ListBox lstBoxPreCoreqs;
        private System.Windows.Forms.ListBox lstBoxCoreqs;
        protected System.Windows.Forms.Label lblPreCoreqs;
        protected System.Windows.Forms.Label lblCoreqs;
        private System.Windows.Forms.Button btnClassRemoved;
        private System.Windows.Forms.ListBox lstBoxClassesTaken;
        private System.Windows.Forms.Label lblClassesTaken;
        private System.Windows.Forms.Button btnClassTaken400;
        private System.Windows.Forms.Button btnClassTaken300;
        private System.Windows.Forms.Button btnClassTaken200;
        private System.Windows.Forms.Button btnClassTaken100;
        private System.Windows.Forms.Button btnSaveClasses;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}