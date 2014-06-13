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
    public partial class GenerateSchedulesForm : Form
    {

        public GenerateSchedulesForm(List<Course> coursesTaken, String degreeType)
        {
            InitializeComponent();

            // removes classes taken from the default schedule
            foreach (Course myCourse in coursesTaken)
            {
                if (lstBoxyear1Fall.Items.Contains(myCourse.ToString()))
                    lstBoxyear1Fall.Items.Remove(myCourse.ToString());
                if (lstBoxyear1Spring.Items.Contains(myCourse.ToString()))
                    lstBoxyear1Spring.Items.Remove(myCourse.ToString());
                if (lstBoxYear1Summer.Items.Contains(myCourse.ToString()))
                    lstBoxYear1Summer.Items.Remove(myCourse.ToString());

                if (lstBoxYear2Fall.Items.Contains(myCourse.ToString()))
                    lstBoxYear2Fall.Items.Remove(myCourse.ToString());
                if (lstBoxYear2Spring.Items.Contains(myCourse.ToString()))
                    lstBoxYear2Spring.Items.Remove(myCourse.ToString());
                if (lstBoxYear2Summer.Items.Contains(myCourse.ToString()))
                    lstBoxYear2Summer.Items.Remove(myCourse.ToString());

                if (lstBoxYear3Fall.Items.Contains(myCourse.ToString()))
                    lstBoxYear3Fall.Items.Remove(myCourse.ToString());
                if (lstBoxYear3Spring.Items.Contains(myCourse.ToString()))
                    lstBoxYear3Spring.Items.Remove(myCourse.ToString());
                if (lstBoxYear3Summer.Items.Contains(myCourse.ToString()))
                    lstBoxYear3Summer.Items.Remove(myCourse.ToString());

                if (lstBoxYear4Fall.Items.Contains(myCourse.ToString()))
                    lstBoxYear4Fall.Items.Remove(myCourse.ToString());
                if (lstBoxYear4Spring.Items.Contains(myCourse.ToString()))
                    lstBoxYear4Spring.Items.Remove(myCourse.ToString());
                if (lstBoxYear4Summer.Items.Contains(myCourse.ToString()))
                    lstBoxYear4Summer.Items.Remove(myCourse.ToString());
            }
        }






        //a selection has been made in the list of classes in a semester, shows class information
        private void lstBoxyear1Fall_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxyear1Fall.SelectedItem.ToString();
            showCourseInfo(myCourse);          
        }

        private void lstBoxyear1Spring_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxyear1Spring.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }


        private void lstBoxYear1Summer_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear1Summer.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear2Fall_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear2Fall.SelectedItem.ToString();
            showCourseInfo(myCourse);  

        }

        private void lstBoxYear2Spring_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear2Spring.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear2Summer_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear2Summer.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear3Fall_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear3Fall.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear3Spring_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear3Spring.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear3Summer_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear3Summer.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear4Fall_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear4Fall.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear4Spring_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear4Spring.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        private void lstBoxYear4Summer_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lstBoxYear4Summer.SelectedItem.ToString();
            showCourseInfo(myCourse);  
        }

        // displays the course information for the selected course
        private void showCourseInfo(String myCourse)
        {
            lstBoxReplacements.Items.Clear();                 //since new selection has been made, the replacement courses box is cleared in case it wasn't empty
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











        //displays classes that can replace the one selected when button was clicked.
        private void btnFindReplacement_Click(object sender, EventArgs e)
        {
            if (txtBoxUID.Text.Equals("MA00171"))
            {
                lstBoxReplacements.Items.Add("No Valid Replacements");
            }
            if (txtBoxUID.Text.Equals("HY00101"))
            {
                lstBoxReplacements.Items.Add("Meet Reqs And Can Replace");
                lstBoxReplacements.Items.Add("\tWorld History to 1500");
                lstBoxReplacements.Items.Add("");
                lstBoxReplacements.Items.Add("Do Not Meet Reqs");
                lstBoxReplacements.Items.Add("\tWestern Civ II");
                lstBoxReplacements.Items.Add("\tWorld History since 1500");
                lstBoxReplacements.Items.Add("");
                lstBoxReplacements.Items.Add("Cannot Be Added This Semester");
                lstBoxReplacements.Items.Add("\tSpring/Summer Only History Req");
            }
        }
    }
}
