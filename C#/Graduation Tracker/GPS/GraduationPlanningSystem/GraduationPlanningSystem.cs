using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationPlanningSystem.Data_Objects;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace GraduationPlanningSystem
{
    /// <summary>
    /// Main form for the program
    /// </summary>
    public partial class GraduationPlanningSystem : Form
    {
        List<Degree> mDegreeList;
        public static DBClass db;
        public static List<Course> coursesTaken;

        public GraduationPlanningSystem()
        {
            InitializeComponent();
            coursesTaken = new List<Course>();
            db = new DBClass();         //initializes database
            mDegreeList = new List<Degree>();

            List<string> codes = db.GetDegreeCodes();
            comboMajor.Items.Clear();
            foreach (string code in codes)
            {
                comboMajor.Items.Add(code);
            }

            #region unneeded
            /*
            mDegreeList.Add(new Degree("Math"));
            mDegreeList.Add(new Degree("English"));
            Degree degree = new Degree("Electrical Engineering");

            degree.RequiredCourses.Add(new Course("Calculus A", false));
            degree.RequiredCourses.Add(new Course("General Chemistry I", false));
            degree.RequiredCourses.Add(new Course("General Chem Lab", false));
            degree.ElectiveCourses.Add(new Elective("Western Civ"));
            degree.RequiredCourses.Add(new Course("Calculus B", false));
            degree.RequiredCourses.Add(new Course("General Physics", false));
            degree.RequiredCourses.Add(new Course("General Physics Lab", false));
            degree.RequiredCourses.Add(new Course("Intro to Comp Programming", false));
            degree.RequiredCourses.Add(new Course("Intro to Comp Prog Lab", false));
            degree.RequiredCourses.Add(new Course("Calculus C", false));
            degree.RequiredCourses.Add(new Course("General Physics with Calculus", false));
            degree.RequiredCourses.Add(new Course("General Physics with Lab II", false));
            degree.RequiredCourses.Add(new Course("Intro to Linear Algebra", false));
            degree.RequiredCourses.Add(new Course("Intro to Digital Logic", false));
            degree.RequiredCourses.Add(new Course("Digital Logic Design Lab", false));
            degree.RequiredCourses.Add(new Course("Applied Diff Equations", false));
            degree.RequiredCourses.Add(new Course("Electrical Circuit Analysis", false));
            degree.RequiredCourses.Add(new Course("General Physics III", false));
            degree.RequiredCourses.Add(new Course("General Physics Lab III", false));
            degree.RequiredCourses.Add(new Course("Computer Organization", false));

            degree.ElectiveCourses.Add(new Elective("Western Civ"));

            DegreePlan plan = new DegreePlan("Full Plan");
            DegreePlan plan2 = new DegreePlan("Requirements only plan");
            DegreePlan plan3 = new DegreePlan("Electives only plan");
            */

            #endregion

            #region tempSetupSemesters

            

            #endregion
            

        }

     
        /// <summary>
        /// Populates a list of courses based on major
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        private List<Course> GetCoursesFromDB(string major)
        {
            List<Course> result = new List<Course>();
            DataTable table = GraduationPlanningSystem.db.find(major , "major");
            foreach (DataRow row in table.Select())
            {
                Course course = new Course((String)row[1], Course.AcademicStatus.NotYetTaken);

                course.Hours = (Int64)row[3];
                String entry = (String)row[5];         //gets list of reqs and parses them into nodes for a list
                if (entry.Equals(""))
                    course.CoReq = null;
                else
                    course.CoReq = ParseGPS.parseReqs(entry);

                entry = (String)row[6];
                if (entry.Equals(""))
                    course.Prereq = null;
                else
                    course.Prereq = ParseGPS.parseReqs(entry);

                entry = (String)row[7];
                if (entry.Equals(""))
                    course.PrereqOrCoreq = null;
                else
                    course.PrereqOrCoreq = ParseGPS.parseReqs(entry);
                result.Add(course);

            }
            return result;
        }

        public void SetTakenList(List<Course> taken)
        {
            coursesTaken = taken;
        }



        //Go to Edit Taken Classes Form;
        private void btnEditTaken_Click(object sender, EventArgs e)
        {
            AlreadyTakenClasses form = new AlreadyTakenClasses(this);
            form.Show();
        }


        //Go to Generate Schedule Form
        private void button1_Click(object sender, EventArgs e)
        {
            ToolTip gen = new ToolTip();//nk
            gen.SetToolTip(button1, "Click to Generate Schedules");//nk
            this.Controls.Add(button1);//nk
            Degree temp;

            if (comboMajor.SelectedIndex >= 0)
            {
                string degreeName = db.GetDegreeFromCode(comboMajor.SelectedItem.ToString());
                Degree degree = Degree.LoadDegree(db, degreeName);
                degree.MaxSemesters = comboPosYear.SelectedIndex + 2;

                degree = Degree.AutoFillSemesters(degree);
                GenerateSchedulesForm form = new GenerateSchedulesForm(degreeName, degree, db);
                form.Show();

            }

            #region Deprecated

            //return;
            //if (comboMajor.SelectedIndex == 0)
            //{
            //    temp = Degree.LoadEE(db);
            //    temp.TakenCourses = coursesTaken;
            //    if (comboPosYear.SelectedIndex >= 0)
            //    {
            //        temp.MaxSemesters = comboPosYear.SelectedIndex + 2;
            //    }
            //    temp = Degree.AutoFillSemesters(temp);
            //    GenerateSchedulesForm form = new GenerateSchedulesForm("CPE", temp, db);
            //    form.Show();
            //}

            //if (comboMajor.SelectedIndex == 1)
            //{
            //    temp = Degree.LoadCPE(db);
            //    temp.TakenCourses = coursesTaken;
            //    if (comboPosYear.SelectedIndex >= 0)
            //    {
            //        temp.MaxSemesters = comboPosYear.SelectedIndex + 2;
            //    }
            //    temp = Degree.AutoFillSemesters(temp);
            //    GenerateSchedulesForm form = new GenerateSchedulesForm("CPE", temp, db);
            //    form.Show();
            //}

            //if (comboMajor.SelectedIndex == 2)
            //{
            //    temp = Degree.LoadOPE(db);
            //    temp.TakenCourses = coursesTaken;
            //    if (comboPosYear.SelectedIndex >= 0)
            //    {
            //        temp.MaxSemesters = comboPosYear.SelectedIndex + 2;
            //    }
            //    temp = Degree.AutoFillSemesters(temp);
            //    GenerateSchedulesForm form = new GenerateSchedulesForm("OPE", temp, db);
            //    form.Show();
            //}

            #endregion

            //LoadDegreeFromFile();
            //GenerateSchedulesForm form = new GenerateSchedulesForm(coursesTaken, "EE", mDegreeList[comboMajor.SelectedIndex]);
            //form.Show();
        }

        

        
        private void label1_Click(object sender, EventArgs e)
        {

            ToolTip major = new ToolTip();//nk
            major.SetToolTip(label1, "Select Major from List");//nk
            this.Controls.Add(label1);//nk

        }

        private void label2_Click(object sender, EventArgs e)
        {

            ToolTip pos = new ToolTip();//nk
            pos.SetToolTip(label2, "Select Plan of Study");//nk
            this.Controls.Add(label2);//nk


        }

        /// <summary>
        /// closes the program 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// saves teh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          // SerializeToXML(
        }

        /// <summary>
        /// serialize the degree
        /// </summary>
        /// <param name="degree"></param>
        static public void SerializeToXML(Degree degree)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Degree));
            TextWriter textWriter = new StreamWriter(@"C:\test.xml");
            serializer.Serialize(textWriter, degree);
            textWriter.Close();
        }

        /// <summary>
        /// load from a file.  Creates teh file dialog.
        /// </summary>
        private void LoadDegreeFromFile()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "GPS files (*.gps)|*.gps";
            DialogResult result = openFileDialog1.ShowDialog(); //nk

            if (result == DialogResult.OK) //nk
            {

                Degree loadDegree = XMLSerializer.DeserializeXMLToDegree(openFileDialog1.FileName);

                GenerateSchedulesForm form = new GenerateSchedulesForm("EE", loadDegree, db);
                form.Show();
            }
        }

        private void loadDegreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDegreeFromFile();

        }

        /// <summary>
        /// checks the last time the class was updated.  dls new version if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraduationPlanningSystem_Load(object sender, EventArgs e)
        {

            #region Deprecated

            //string lastUpdate = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\GraduationPlanningSystem", "LastUpdate", null);
            //if (lastUpdate != null)
            //{
            //    try
            //    {
            //        DateTime time = Convert.ToDateTime(lastUpdate);
            //        if (MessageBox.Show("Last update: " + time.ToShortDateString() + ".  Update now?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\GraduationPlanningSystem", "LastUpdate", DateTime.Now.ToShortDateString());
            //        }

            //    }
            //    catch
            //    {
            //        if (MessageBox.Show("Unkown time since last update.  Update now?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\GraduationPlanningSystem", "LastUpdate", DateTime.Now.ToShortDateString());
            //        }
            //    }
            //    // Do stuff
            //}

            #endregion
        }

        private void comboMajor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Deprecated
            //comboDefaulSchedules.Items.Clear();
            //comboDefaulSchedules.Items.Add("Default");
            //comboDefaulSchedules.Items.Add("Required");
            //comboDefaulSchedules.Items.Add("Elective");
        }

        private void comboPosYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadDefault_Click(object sender, EventArgs e)
        {
            if (comboMajor.SelectedIndex >= 0 && comboDefaulSchedules.SelectedIndex >= 0)
            {
                if (comboMajor.SelectedItem.ToString() != "" && comboDefaulSchedules.SelectedItem.ToString() != "")
                {
                    string file = comboMajor.SelectedItem.ToString() + "_" + comboDefaulSchedules.SelectedItem.ToString() + ".gps";

                    try
                    {
                        Degree loadDegree = XMLSerializer.DeserializeXMLToDegree(file);
                        loadDegree.TakenCourses = coursesTaken;
                        GenerateSchedulesForm form = new GenerateSchedulesForm("EE", loadDegree, db);
                        form.Show();
                    }
                    catch
                    {
                        try
                        {
                            Degree loadDegree = XMLSerializer.DeserializeXMLToDegree("..\\..\\" + file);
                            loadDegree.TakenCourses = coursesTaken;
                            GenerateSchedulesForm form = new GenerateSchedulesForm("EE", loadDegree, db);
                            form.Show();
                        }
                        catch
                        {
                            MessageBox.Show("Error loading template.  Please either load another template, or attempt another method of creating a degree plan.");
                        }
                    }
                }
            }

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "updatefinal.htm";
            proc.Start();
        }

        private void btnLoadSaved_Click(object sender, EventArgs e)
        {
            LoadDegreeFromFile();
        }
    }
}
