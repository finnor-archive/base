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
        GraduationPlanningSystem mParent;

        public AlreadyTakenClasses(GraduationPlanningSystem parent)
        {
            InitializeComponent();
            coursesTaken = new List<Course>();
            mParent = parent;
        }

        private void AlreadyTakenClasses_Load(object sender, EventArgs e)
        {
            lst100.DataSource = GraduationPlanningSystem.db.findLevel(1);
            lst200.DataSource = GraduationPlanningSystem.db.findLevel(2);
            lst300.DataSource = GraduationPlanningSystem.db.findLevel(3);
            lst400.DataSource = GraduationPlanningSystem.db.findLevel(4);
        }



        //detects the course selected and shows the information about the class
        //show course info when selection is changed
        private void lst100_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst100.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }

        //show course info when selection is changed
        private void lst200_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst200.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }

        //show course info when selection is changed
        private void lst300_SelectedIndexChanged(object sender, EventArgs e)
        {
            String myCourse = lst300.SelectedItem.ToString();
            showCourseInfo(myCourse);
        }

        //show course info when selection is changed

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
            btnClassRemoved.Enabled = true;
        }

        //enable buttons on select
        private void btnClassTaken200_Click(object sender, EventArgs e)
        {
            String myCourse = lst200.SelectedItem.ToString();
            addToClassesTaken(myCourse);
            btnClassRemoved.Enabled = true;
        }

        //enable buttons on select
        private void btnClassTaken300_Click(object sender, EventArgs e)
        {
            String myCourse = lst300.SelectedItem.ToString();
            addToClassesTaken(myCourse);
            btnClassRemoved.Enabled = true;
        }

        //enable buttons on select
        private void btnClassTaken400_Click(object sender, EventArgs e)
        {
            String myCourse = lst400.SelectedItem.ToString();
            addToClassesTaken(myCourse);
            btnClassRemoved.Enabled = true;
        }

        private void addToClassesTaken(String myCourse)
        {

            if (!lstBoxClassesTaken.Items.Contains(myCourse))
            { //nk fixed duplicate
                lstBoxClassesTaken.Items.Add(myCourse);
                btnClassRemoved.Enabled = true;
            }
        }

        //removes a class from class taken list
        private void btnClassRemoved_Click(object sender, EventArgs e)
        {
            if (lstBoxClassesTaken.SelectedIndex != -1)
            { //nk if no item is selected no crash

                String item = lstBoxClassesTaken.SelectedItem.ToString();

                lstBoxClassesTaken.SelectionMode = SelectionMode.One;//nk


                lstBoxClassesTaken.Items.Remove(item);


                if (lstBoxClassesTaken.Items.Count > 0)//nk
                {

                    btnClassRemoved.Enabled = true;//nk


                }

                else
                {
                    //MessageBox.Show("Invalid Value!");//nk
                    btnClassRemoved.Enabled = false;//nk



                }

            }
        }


        //saves the class taken list at the GPS Form
        private void btnSaveClasses_Click(object sender, EventArgs e)
        {
            foreach (String myCourse in lstBoxClassesTaken.Items)
            {
                coursesTaken.Add(new Course(myCourse, Course.AcademicStatus.NotYetTaken));
            }
            GraduationPlanningSystem.coursesTaken = coursesTaken;

            //System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            //saveFileDialog1.Filter = "GPS files (*.gps)|*.gps";
            //saveFileDialog1.ShowDialog();

            //Degree saveClassTaken = XMLSerializer.DeserializeXMLToDegree(saveFileDialog1.FileName);
            this.Close();
        }

        private void lstBoxClassesTaken_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
