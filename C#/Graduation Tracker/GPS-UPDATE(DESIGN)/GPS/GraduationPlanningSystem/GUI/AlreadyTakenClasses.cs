using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationPlanningSystem.Data_Objects;

namespace GraduationPlanningSystem
{
    public partial class AlreadyTakenClasses : Form
    {
        List<Course> coursesTaken;

        public AlreadyTakenClasses()
        {
            InitializeComponent();
            coursesTaken = new List<Course>();
        }

        private void AlreadyTakenClasses_Load(object sender, EventArgs e)
        {
            lst100.DataSource = GraduationPlanningSystem.db.findLevel(1);
            lst200.DataSource = GraduationPlanningSystem.db.findLevel(2);
            lst300.DataSource = GraduationPlanningSystem.db.findLevel(3);
            lst400.DataSource = GraduationPlanningSystem.db.findLevel(4);
        }



        //detects the course selected and shows the information about the class
        private void lst100_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst100.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }
        private void lst200_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst200.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }

        private void lst300_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst300.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }

        private void lst400_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst400.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }

        //displays course info
        private void showCourseInfo(String myCourse)
        {
            DataTable result = GraduationPlanningSystem.db.find(myCourse, "course");
            DataRow[] rows = result.Select();
            Object[] rowArray = rows[0].ItemArray;
            txtBoxCourseTitle.Text = (String)rowArray[1];
            txtBoxUID.Text = (String)rowArray[0];
            txtBoxCourseNumber.Text = (String)rowArray[2];
            txtBoxDepartment.Text = (String)rowArray[4];
            txtBoxHours.Text = (String)(rowArray[3].ToString());
            txtBoxSemester.Text = (String)rowArray[9];


            //empties the prereq/coreq/precoreq boxes
            lstBoxPrereqs.DataSource = null;
            lstBoxCoreqs.DataSource = null;
            lstBoxPreCoreqs.DataSource = null;
            lstBoxPrereqs.Items.Clear();
            lstBoxCoreqs.Items.Clear();
            lstBoxPreCoreqs.Items.Clear();


            //the information needed for prereqs/coreqs/precoreqs must be parsed from the database
            String entry = (String)rowArray[5];
            if (entry.Equals(""))
                lstBoxPrereqs.Items.Add("No prereqs");
            else
            {
                List<String> preReqs = ParseGPS.parseReqs(entry);
                lstBoxPrereqs.DataSource = preReqs;

            }

            entry = (String)rowArray[6];
            if (entry.Equals(""))
                lstBoxCoreqs.Items.Add("No coreqs");
            else
            {
                List<String> coReqs = ParseGPS.parseReqs(entry);
                lstBoxCoreqs.DataSource = coReqs;
            }

            entry = (String)rowArray[7];
            if (entry.Equals(""))
                lstBoxPreCoreqs.Items.Add("No pre/coreqs");
            else
            {
                List<String> preCoReqs = ParseGPS.parseReqs(entry);
                lstBoxPreCoreqs.DataSource = preCoReqs;
            }

        }




        //takes the currently selected class and adds it to the classes taken list
        private void btnClassTaken100_Click(object sender, EventArgs e)
        {
            String myCourse = lst100.SelectedItem.ToString();
            addToClassesTaken(myCourse);
        }

        private void btnClassTaken200_Click(object sender, EventArgs e)
        {
            String myCourse = lst200.SelectedItem.ToString();
            addToClassesTaken(myCourse);
        }

        private void btnClassTaken300_Click(object sender, EventArgs e)
        {
            String myCourse = lst300.SelectedItem.ToString();
            addToClassesTaken(myCourse);
        }

        private void btnClassTaken400_Click(object sender, EventArgs e)
        {
            String myCourse = lst400.SelectedItem.ToString();
            addToClassesTaken(myCourse);
        }

        private void addToClassesTaken(String myCourse)
        {
            lstBoxClassesTaken.Items.Add(myCourse);
        }

        //removes a class from class taken list
        private void btnClassRemoved_Click(object sender, EventArgs e)
        {
            String item = lstBoxClassesTaken.SelectedItem.ToString();
            lstBoxClassesTaken.Items.Remove(item);
        }


        //saves the class taken list at the GPS Form
        private void btnSaveClasses_Click(object sender, EventArgs e)
        {
            foreach (String myCourse in lstBoxClassesTaken.Items)
            {
                coursesTaken.Add(new Course(myCourse, true));
            }
            GraduationPlanningSystem.coursesTaken = coursesTaken;
        }


    }
}
