using System.Windows.Forms;
using System.Windows.Controls;
namespace GraduationPlanningSystem
{
    partial class GenerateSchedulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateSchedulesForm));
            this.btnGenerateSchedules = new System.Windows.Forms.Button();
            this.btnViewEditClasses = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.lstBoxReplacements = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPreCoreqs = new System.Windows.Forms.Label();
            this.lblCoreqs = new System.Windows.Forms.Label();
            this.lblPrereqs = new System.Windows.Forms.Label();
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
            this.lstBoxPrereqs = new System.Windows.Forms.ListBox();
            this.lstBoxCoreqs = new System.Windows.Forms.ListBox();
            this.lstBoxPreCoreqs = new System.Windows.Forms.ListBox();
            this.txtGenSchedules = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cmboDegreeSwitch = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateSchedules
            // 
            this.btnGenerateSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateSchedules.Location = new System.Drawing.Point(129, 42);
            this.btnGenerateSchedules.Name = "btnGenerateSchedules";
            this.btnGenerateSchedules.Size = new System.Drawing.Size(127, 23);
            this.btnGenerateSchedules.TabIndex = 1;
            this.btnGenerateSchedules.Text = "Generate Schedules";
            this.btnGenerateSchedules.UseVisualStyleBackColor = true;
            this.btnGenerateSchedules.Click += new System.EventHandler(this.btnGenerateSchedules_Click);
            // 
            // btnViewEditClasses
            // 
            this.btnViewEditClasses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewEditClasses.Location = new System.Drawing.Point(270, 42);
            this.btnViewEditClasses.Name = "btnViewEditClasses";
            this.btnViewEditClasses.Size = new System.Drawing.Size(160, 23);
            this.btnViewEditClasses.TabIndex = 2;
            this.btnViewEditClasses.Text = "Switch Degree";
            this.btnViewEditClasses.UseVisualStyleBackColor = true;
            this.btnViewEditClasses.Click += new System.EventHandler(this.btnViewEditClasses_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.elementHost3);
            this.panel1.Controls.Add(this.lstBoxReplacements);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(580, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 424);
            this.panel1.TabIndex = 3;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(3, 3);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(534, 418);
            this.elementHost3.TabIndex = 2;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost3_ChildChanged);
            this.elementHost3.Child = null;
            // 
            // lstBoxReplacements
            // 
            this.lstBoxReplacements.FormattingEnabled = true;
            this.lstBoxReplacements.Location = new System.Drawing.Point(36, 22);
            this.lstBoxReplacements.Name = "lstBoxReplacements";
            this.lstBoxReplacements.Size = new System.Drawing.Size(288, 407);
            this.lstBoxReplacements.TabIndex = 1;
            this.lstBoxReplacements.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Replacements";
            this.label9.Visible = false;
            // 
            // lblPreCoreqs
            // 
            this.lblPreCoreqs.AutoSize = true;
            this.lblPreCoreqs.Location = new System.Drawing.Point(850, 95);
            this.lblPreCoreqs.Name = "lblPreCoreqs";
            this.lblPreCoreqs.Size = new System.Drawing.Size(61, 13);
            this.lblPreCoreqs.TabIndex = 69;
            this.lblPreCoreqs.Text = "Pre/Coreqs";
            this.lblPreCoreqs.Visible = false;
            // 
            // lblCoreqs
            // 
            this.lblCoreqs.AutoSize = true;
            this.lblCoreqs.Location = new System.Drawing.Point(690, 95);
            this.lblCoreqs.Name = "lblCoreqs";
            this.lblCoreqs.Size = new System.Drawing.Size(40, 13);
            this.lblCoreqs.TabIndex = 67;
            this.lblCoreqs.Text = "Coreqs";
            // 
            // lblPrereqs
            // 
            this.lblPrereqs.AutoSize = true;
            this.lblPrereqs.Location = new System.Drawing.Point(513, 92);
            this.lblPrereqs.Name = "lblPrereqs";
            this.lblPrereqs.Size = new System.Drawing.Size(43, 13);
            this.lblPrereqs.TabIndex = 65;
            this.lblPrereqs.Text = "Prereqs";
            // 
            // txtBoxSemester
            // 
            this.txtBoxSemester.Location = new System.Drawing.Point(396, 141);
            this.txtBoxSemester.Name = "txtBoxSemester";
            this.txtBoxSemester.ReadOnly = true;
            this.txtBoxSemester.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSemester.TabIndex = 83;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(339, 144);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(51, 13);
            this.lblSemester.TabIndex = 82;
            this.lblSemester.Text = "Semester";
            // 
            // txtBoxHours
            // 
            this.txtBoxHours.Location = new System.Drawing.Point(396, 115);
            this.txtBoxHours.Name = "txtBoxHours";
            this.txtBoxHours.ReadOnly = true;
            this.txtBoxHours.Size = new System.Drawing.Size(100, 20);
            this.txtBoxHours.TabIndex = 81;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(355, 118);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 80;
            this.lblHours.Text = "Hours";
            // 
            // txtBoxDepartment
            // 
            this.txtBoxDepartment.Location = new System.Drawing.Point(222, 115);
            this.txtBoxDepartment.Name = "txtBoxDepartment";
            this.txtBoxDepartment.ReadOnly = true;
            this.txtBoxDepartment.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDepartment.TabIndex = 79;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(154, 118);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 78;
            this.lblDepartment.Text = "Department";
            // 
            // txtBoxCourseNumber
            // 
            this.txtBoxCourseNumber.Location = new System.Drawing.Point(222, 167);
            this.txtBoxCourseNumber.Name = "txtBoxCourseNumber";
            this.txtBoxCourseNumber.ReadOnly = true;
            this.txtBoxCourseNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCourseNumber.TabIndex = 77;
            // 
            // lblCourseNumber
            // 
            this.lblCourseNumber.AutoSize = true;
            this.lblCourseNumber.Location = new System.Drawing.Point(136, 170);
            this.lblCourseNumber.Name = "lblCourseNumber";
            this.lblCourseNumber.Size = new System.Drawing.Size(80, 13);
            this.lblCourseNumber.TabIndex = 76;
            this.lblCourseNumber.Text = "Course Number";
            // 
            // txtBoxUID
            // 
            this.txtBoxUID.Location = new System.Drawing.Point(222, 141);
            this.txtBoxUID.Name = "txtBoxUID";
            this.txtBoxUID.ReadOnly = true;
            this.txtBoxUID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUID.TabIndex = 75;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(190, 144);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(26, 13);
            this.lblUID.TabIndex = 74;
            this.lblUID.Text = "UID";
            // 
            // txtBoxCourseTitle
            // 
            this.txtBoxCourseTitle.Location = new System.Drawing.Point(222, 89);
            this.txtBoxCourseTitle.Name = "txtBoxCourseTitle";
            this.txtBoxCourseTitle.ReadOnly = true;
            this.txtBoxCourseTitle.Size = new System.Drawing.Size(274, 20);
            this.txtBoxCourseTitle.TabIndex = 73;
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Location = new System.Drawing.Point(153, 89);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(63, 13);
            this.lblCourseTitle.TabIndex = 72;
            this.lblCourseTitle.Text = "Course Title";
            // 
            // lblSelectedCourseInfo
            // 
            this.lblSelectedCourseInfo.AutoSize = true;
            this.lblSelectedCourseInfo.Location = new System.Drawing.Point(20, 89);
            this.lblSelectedCourseInfo.Name = "lblSelectedCourseInfo";
            this.lblSelectedCourseInfo.Size = new System.Drawing.Size(106, 13);
            this.lblSelectedCourseInfo.TabIndex = 71;
            this.lblSelectedCourseInfo.Text = "Selected Course Info";
            // 
            // lstBoxPrereqs
            // 
            this.lstBoxPrereqs.FormattingEnabled = true;
            this.lstBoxPrereqs.Location = new System.Drawing.Point(562, 92);
            this.lstBoxPrereqs.Name = "lstBoxPrereqs";
            this.lstBoxPrereqs.Size = new System.Drawing.Size(108, 95);
            this.lstBoxPrereqs.TabIndex = 23;
            // 
            // lstBoxCoreqs
            // 
            this.lstBoxCoreqs.FormattingEnabled = true;
            this.lstBoxCoreqs.Location = new System.Drawing.Point(736, 95);
            this.lstBoxCoreqs.Name = "lstBoxCoreqs";
            this.lstBoxCoreqs.Size = new System.Drawing.Size(99, 95);
            this.lstBoxCoreqs.TabIndex = 84;
            // 
            // lstBoxPreCoreqs
            // 
            this.lstBoxPreCoreqs.FormattingEnabled = true;
            this.lstBoxPreCoreqs.Location = new System.Drawing.Point(915, 95);
            this.lstBoxPreCoreqs.Name = "lstBoxPreCoreqs";
            this.lstBoxPreCoreqs.Size = new System.Drawing.Size(103, 95);
            this.lstBoxPreCoreqs.TabIndex = 85;
            this.lstBoxPreCoreqs.Visible = false;
            // 
            // txtGenSchedules
            // 
            this.txtGenSchedules.Location = new System.Drawing.Point(76, 45);
            this.txtGenSchedules.Name = "txtGenSchedules";
            this.txtGenSchedules.Size = new System.Drawing.Size(47, 20);
            this.txtGenSchedules.TabIndex = 86;
            this.txtGenSchedules.Text = "5";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1233, 24);
            this.menuStrip1.TabIndex = 87;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.lToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save Degree...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // lToolStripMenuItem
            // 
            this.lToolStripMenuItem.Name = "lToolStripMenuItem";
            this.lToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.lToolStripMenuItem.Text = "Load Degree...";
            this.lToolStripMenuItem.Click += new System.EventHandler(this.lToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(49, 220);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(493, 421);
            this.elementHost1.TabIndex = 88;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.elementHost1.Child = null;
            // 
            // cmboDegreeSwitch
            // 
            this.cmboDegreeSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmboDegreeSwitch.FormattingEnabled = true;
            this.cmboDegreeSwitch.Items.AddRange(new object[] {
            "EE",
            "CPE",
            "OPE"});
            this.cmboDegreeSwitch.Location = new System.Drawing.Point(471, 44);
            this.cmboDegreeSwitch.Name = "cmboDegreeSwitch";
            this.cmboDegreeSwitch.Size = new System.Drawing.Size(121, 21);
            this.cmboDegreeSwitch.TabIndex = 89;
            // 
            // GenerateSchedulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1233, 713);
            this.Controls.Add(this.cmboDegreeSwitch);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.txtGenSchedules);
            this.Controls.Add(this.lstBoxPreCoreqs);
            this.Controls.Add(this.lstBoxCoreqs);
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
            this.Controls.Add(this.lblPreCoreqs);
            this.Controls.Add(this.lblCoreqs);
            this.Controls.Add(this.lblPrereqs);
            this.Controls.Add(this.btnViewEditClasses);
            this.Controls.Add(this.btnGenerateSchedules);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GenerateSchedulesForm";
            this.Text = "GenerateSchedulesForm";
            this.Load += new System.EventHandler(this.GenerateSchedulesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateSchedules;
        private System.Windows.Forms.Button btnViewEditClasses;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstBoxReplacements;
        private System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label lblPreCoreqs;
        protected System.Windows.Forms.Label lblCoreqs;
        private System.Windows.Forms.Label lblPrereqs;
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
        private System.Windows.Forms.ListBox lstBoxPrereqs;
        private System.Windows.Forms.ListBox lstBoxCoreqs;
        private System.Windows.Forms.ListBox lstBoxPreCoreqs;
        private System.Windows.Forms.TextBox txtGenSchedules;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.ComboBox cmboDegreeSwitch;
    }
}