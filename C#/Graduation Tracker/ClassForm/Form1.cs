using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace school_form
{
    public partial class Form1 : Form
    {
        private List<Degree> Degrees;
        List<Degree> final;
        public Form1()
        {
            InitializeComponent();
            Degrees = new List<Degree>();


            TestNew();

            Degree spanish = new Degree("Spanish");
            Degrees.Add(spanish);

            foreach (Degree degree in Degrees)
            {
                lstDegrees.Items.Add(degree.Name);
            }


        }

        private void AddOldMath()
        {
            Degree math = new Degree("Math");
            List<List<Course>> mathElectives = new List<List<Course>>();

            Elective history = new Elective("history");

            history.Courses.Add(new Course("US History", false, 3));
            history.Courses.Add(new Course("Non Wester Civ", false, 3));

            Elective music = new Elective("Music");
            music.Courses.Add(new Course("Music 101", false, 3));
            music.Courses.Add(new Course("Phys Ed", false, 3));

            Elective english = new Elective("English");
            history.Courses.Add(new Course("English", false, 3));
            history.Courses.Add(new Course("English Lit", false, 3));

            math.RequiredCourses.Add(new Course("Cal A", false, 3));
            math.RequiredCourses.Add(new Course("Cal B", false, 3));
            math.RequiredCourses.Add(new Course("Linear", false, 3));
            math.RequiredCourses.Add(new Course("DiffEQ", false, 3));
            math.RequiredCourses.Add(new Course("Physics", false, 3));
            math.RequiredCourses.Add(new Course("English 101", false, 3));
            math.RequiredCourses.Add(new Course("Western Civ", false, 3));
            math.ElectiveCourses.Add(history);
            math.ElectiveCourses.Add(music);
            math.ElectiveCourses.Add(english);

            Degrees.Add(math);
        }

        private void TestNew()
        {
            Degree math = new Degree("math");

            math.RequiredCourses.Add(new Course("Cal A", false, 3));
            math.RequiredCourses.Add(new Course("Cal B", false, 3, "Cal A"));
            math.RequiredCourses.Add(new Course("Linear", false, 3, "Cal B"));

            Elective english = new Elective("english");
            english.Courses.Add(new Course("English 101", false, 3));

            Elective phys = new Elective("phys");
            english.Courses.Add(new Course("Physics 101", false, 3));

            Elective civ = new Elective("western civ");
            english.Courses.Add(new Course("Western Civ", false, 3));

            Elective music = new Elective("music");
            english.Courses.Add(new Course("Music Appreciation", false, 3));

            Elective art = new Elective("art");
            english.Courses.Add(new Course("Art History", false, 3));

            math.ElectiveCourses.Add(english);
            math.ElectiveCourses.Add(phys);
            math.ElectiveCourses.Add(civ);
            math.ElectiveCourses.Add(art);
            math.ElectiveCourses.Add(music);

            Degrees.Add(math);

        }

        private void btnSelectMajor_Click(object sender, EventArgs e)
        {
            if (lstDegrees.SelectedIndex > -1)
            {
                    int index = lstDegrees.SelectedIndex;
                    string degreeName = lstDegrees.Items[index].ToString();
                    foreach (Degree degree in Degrees)
                    {
                        if (degree.Name == degreeName)
                        {
                            foreach (Elective elective in degree.ElectiveCourses)
                            {
                                lstElectiveClasses.Items.Add(elective.Name);
                            }
                            foreach (Course course in degree.RequiredCourses)
                            {
                                lstRequiredClasses.Items.Add(course.Name);
                            }
                        }
                    }
            }
        }

        private void btnRequiredClasses_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = lstRequiredClasses.SelectedIndex;
                if (selected > -1)
                {
                    lstRequiredClasses.Items.RemoveAt(selected);
                    lstTakenClasses.Items.Add(lstRequiredClasses.Items[selected].ToString());
                    Degrees[lstDegrees.SelectedIndex].RequiredCourses[selected].Taken = true;

                }
            }
            catch
            { }

        }

        private void btnElectives_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = lstElectiveClasses.SelectedIndex;
                if (selected > -1)
                {
                    lstElectiveClasses.Items.RemoveAt(selected);
                    lstTakenClasses.Items.Add(lstElectiveClasses.Items[selected].ToString());
                    Degrees[lstDegrees.SelectedIndex].ElectiveCourses[selected].Courses[lstElectiveSelected.SelectedIndex].Taken = true;
                }
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstSemester1.Items.Clear();
            lstSemester2.Items.Clear();

            Degree selected = Degrees[lstDegrees.SelectedIndex];



            foreach (Course course in selected.RequiredCourses)
            {
                if (course.DefaultSemester == 1)
                {
                    lstSemester1.Items.Add(course.Name);
                }

                if (course.DefaultSemester == 2)
                {
                    lstSemester2.Items.Add(course.Name);
                }
            }

            foreach (Elective elective in selected.ElectiveCourses)
            {
                foreach (Course course in elective.Courses)
                {
                    if (course.DefaultSemester == 1)
                    {
                        lstSemester1.Items.Add(course.Name);
                    }

                    if (course.DefaultSemester == 2)
                    {
                        lstSemester2.Items.Add(course.Name);
                    }
                }
            }



            bool error = false;
            int reqTaken = 0;
            foreach (Course course in Degrees[0].RequiredCourses)
            {
                if (lstSemester1.Items.Count < 3 && course.Taken == false)
                {
                    lstSemester1.Items.Add(course.Name);
                }
                else if (lstSemester2.Items.Count < 3 && course.Taken == false)
                {
                    lstSemester2.Items.Add(course.Name);
                }

                if (course.Taken)
                {
                    reqTaken++;
                }


                
                error = lstSemester1.Items.Count + lstSemester2.Items.Count + reqTaken < Degrees[0].RequiredCourses.Count;

            }
            int elect = 0;
            foreach (Elective elective in Degrees[0].ElectiveCourses)
            {
                
                if (lstSemester1.Items.Count - 6+ lstSemester2.Items.Count + elect < 4)
                { 
                    
                }
                if (lstSemester1.Items.Count < 5 && elective.Taken == false)
                {
                    lstSemester1.Items.Add(elective.Name);
                }
                else if (lstSemester2.Items.Count < 5 && elective.Taken == false)
                {
                    lstSemester2.Items.Add(elective.Name);
                }

                if (elective.Taken)
                {
                    elect++;
                }


                if (lstSemester1.Items.Count + lstSemester2.Items.Count + elect < 4)
                    error = true;

            }


            if (error)
            {
                lblError.Text = "Schedule is impossible.";

                lstSemester1.Items.Clear();
                lstSemester2.Items.Clear();
                
            }
            else
            {
                lblError.Text = "";
            }
        }

        private void lstElectiveClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstElectiveClasses.SelectedIndex > -1)
            {
                lstElectiveSelected.Items.Clear();
                Degree degree = Degrees[lstDegrees.SelectedIndex];
                foreach (Course course in degree.ElectiveCourses[lstElectiveClasses.SelectedIndex].Courses)
                {
                    lstElectiveSelected.Items.Add(course.Name);
                }
            }
        }

        private void btnNumberOfSchedules_Click(object sender, EventArgs e)
        {
            List<Degree> degrees = new List<Degree>();
            List<Degree> degrees2 = new List<Degree>();
            List<Degree> degrees3 = new List<Degree>();
            final = new List<Degree>();
            DegreePlanner planner = new DegreePlanner();
            degrees = planner.FillSemesterList(Degrees[lstDegrees.SelectedIndex], 0);
            
            foreach (Degree degree2 in degrees)
            {
                foreach (Course course in degree2.Semesters[0].Courses)
                {
                    foreach (Course requiredCourse in degree2.RequiredCourses)
                    {
                        if (requiredCourse.Name == course.Name)
                        {
                            degree2.RequiredCourses[degree2.RequiredCourses.IndexOf(requiredCourse)].Taken = true;
                        }
                    }

                    foreach (Elective elective in degree2.ElectiveCourses)
                    {
                        foreach (Course tempCourse in elective.Courses)
                        {
                            if (tempCourse.Name == course.Name)
                            {
                                elective.Courses[elective.Courses.IndexOf(tempCourse)].Taken = true;
                            }
                        }
                    }
                }
                List<Degree> lists = planner.FillSemesterList(degree2, 1);

                foreach (Degree temp in lists)
                    degrees2.Add(temp);
            }

            foreach (Degree degree3 in degrees2)
            {
                foreach (Course course in degree3.Semesters[1].Courses)
                {
                    if (degree3.RequiredCourses.Contains(course))
                    {
                        degree3.RequiredCourses[degree3.RequiredCourses.IndexOf(course)].Taken = true;
                    }

                    foreach (Elective elective in degree3.ElectiveCourses)
                    {
                        if (elective.Courses.Contains(course))
                        {
                            elective.Courses[elective.Courses.IndexOf(course)].Taken = true;
                        }
                    }
                }

                foreach (Degree temp in planner.FillSemesterList(degree3, 2))
                    degrees3.Add(temp);
            }

            foreach (Degree finalDegree in degrees3)
            {
                foreach (Course course in finalDegree.Semesters[2].Courses)
                {
                    if (finalDegree.RequiredCourses.Contains(course))
                    {
                        finalDegree.RequiredCourses[finalDegree.RequiredCourses.IndexOf(course)].Taken = true;
                    }

                    foreach (Elective elective in finalDegree.ElectiveCourses)
                    {
                        if (elective.Courses.Contains(course))
                        {
                            elective.Courses[elective.Courses.IndexOf(course)].Taken = true;
                        }
                    }
                }
            }



            foreach (Degree checkForGrad in degrees3)
            {
                bool graduated = true;
                foreach (Course requirement in checkForGrad.RequiredCourses)
                {
                    if (requirement.Taken == false)
                    {
                        graduated = false;
                    }
                }
                foreach (Elective elective in checkForGrad.ElectiveCourses)
                {
                    if (elective.Taken == false)
                    {
                        graduated = false;
                    }
                }

                if (graduated)
                {
                    final.Add(checkForGrad);
                }

            }

            final = degrees2;
            txtScheduleNumber.Text = final.Count.ToString();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            lstSemester1.Items.Clear();
            lstSemester2.Items.Clear();

            Random rand = new Random();
            int temp = rand.Next(0, final.Count - 1);

            Degree chosen = final[temp];

            foreach (Course course in chosen.Semesters[0].Courses)
            {
                lstSemester1.Items.Add(course.Name);
            }

            foreach (Course course in chosen.Semesters[1].Courses)
            {
                lstSemester2.Items.Add(course.Name);
            }

        }
    }
}
