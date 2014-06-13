using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GraduationPlanningSystem.Data_Objects
{
    public class DegreePlanner
    {
        public Degree DegreePlan;

        int NumberOfSemesters;

        public List<Semester> Semesters;
        public List<Degree> PossibleDegrees;

        public DegreePlanner(Degree degree, int semesters)
        {

            DegreePlan = degree;

            NumberOfSemesters = semesters;

            Semesters = new List<Semester>();
        }

        public DegreePlanner()
        { }

        public void PlanSemesters()
        {
            int count = 0;

            int reqs = DegreePlan.RequiredCourses.Count;
            int elect = DegreePlan.ElectiveCourses.Count;
            int total = reqs + elect;



        }

        private bool CanTakeClass(Degree degree, Course course)
        {
            bool result = true;

            if (course.Taken == true)
            {
                result = false;
            }

            if (course.Prereq != null)
            {
                string prereq = (course.Prereq)[0];              //temporary assignment to make it build
                foreach (Course tempCourse in degree.RequiredCourses)
                {
                    if (tempCourse.Name == prereq)
                    {
                        if (tempCourse.Taken == false)
                        {
                            result = false;
                        }
                    }
                }
            }

            return result;
        }

        private List<Semester> ListSemesters(Degree degree)
        {
            List<Semester> result = new List<Semester>();
            int reqs = degree.RequiredCourses.Count;
            int elect = degree.ElectiveCourses.Count;
            int total = reqs + elect;

            // for (int i = 0; i < 

            return result;
        }

        public List<Degree> FillSemesterList(Degree degree, int semesterNo)
        {
            PossibleDegrees = new List<Degree>();

            //ElapseTime = new Stopwatch();
            //ElapseTime.Start();
            //FillSemesterListInternal(degree, semesterNo);

            int required = degree.RequiredCourses.Count;
            int electives = degree.ElectiveCourses.Count;
            int total = required + electives;
            int possible = Convert.ToInt32(Math.Pow(2, total));

            for (int i = 0; i < possible; i++)
            {
                SlowFillSemester(degree, i, semesterNo);
            }

            return PossibleDegrees;
        }

        private bool AlreadyTakingClass(Semester semester, Course course)
        {
            bool result = false;

            foreach (Course temp in semester.Courses)
            {
                if (temp.Name == course.Name)
                {
                    return true;
                }
            }

            return result;
        }

        private Degree SlowFillSemester(Degree degree, int degreeNumber, int semesterNo)
        {
            int required = degree.RequiredCourses.Count;
            int electives = degree.ElectiveCourses.Count;
            int total = required + electives;

            char[] binary = GetIntBinaryString(degreeNumber, total).ToCharArray();
            while (binary.Length < total)
            {
                binary = (binary.ToString() + "0").ToCharArray();
            }
            for (int i = 0; i < total; i++)
            {
                if (binary[i] == '1')
                {

                }
            }

            return degree;
        }

        private string GetIntBinaryString(int n, int length)
        {
            char[] b = new char[length];
            int pos = length - 1;
            int i = 0;

            while (i < length)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }

        private void FillSemesterListInternal(Degree degree, int semesterNo)
        {
            if (degree.Semesters.Count <= semesterNo)
            {
                degree.Semesters.Add(new Semester());
            }

            if ((degree.Semesters[semesterNo].TotalAllowedHours - degree.Semesters[semesterNo].TotalHours) < 3)
            {
                PossibleDegrees.Add(degree);
            }
            else
            {
                degree.SetCourseListing();
                Degree degreeCopy = degree;
                //if (ElapseTime.ElapsedMilliseconds >= 1000)
                //    return;


                int reqs = degreeCopy.RequiredCourses.Count;
                int elect = degreeCopy.ElectiveCourses.Count;
                int total = reqs + elect;

                for (int i = 0; i < total; i++)
                {

                    Degree temp = degreeCopy.Clone();
                    if (i < reqs)
                    {
                        if (CanTakeClass(temp, temp.RequiredCourses[i]) && !AlreadyTakingClass(temp.Semesters[semesterNo], temp.RequiredCourses[i]) && !temp.RequiredCourses[i].Taken)
                        {

                            Course tempest = degreeCopy.RequiredCourses[i];
                            temp.Semesters[semesterNo].Courses.Add(tempest);

                            FillSemesterListInternal(temp, semesterNo);

                        }
                    }
                    else
                    {
                        if (!temp.ElectiveCourses[i - reqs].Taken && !ElectiveBeingTaken(temp.ElectiveCourses[i - reqs], temp.Semesters[semesterNo]))
                        {
                            foreach (Course course in temp.ElectiveCourses[i - reqs].Courses)
                            {
                                //Semester temp = semester;
                                //temp.Courses.Add(course);


                                temp.Semesters[semesterNo].Courses.Add(course);
                                FillSemesterListInternal(temp, semesterNo);

                            }
                        }
                    }
                }
            }
        }


        private bool ElectiveBeingTaken(Elective elective, Semester semester)
        {
            bool result = false;

            foreach (Course course in elective.Courses)
            {
                foreach (Course sCourse in semester.Courses)
                {
                    if (sCourse.Name == course.Name)
                    {
                        return true;
                    }
                }
            }

            return result;

        }


        private Semester CreateSemester(Semester semester, int classNO, Degree degree)
        {
            int reqs = degree.RequiredCourses.Count;
            int elect = degree.ElectiveCourses.Count;
            int total = reqs + elect;

            if (classNO < reqs)
            {
                if (semester.TotalAllowedHours > (semester.TotalHours + degree.RequiredCourses[classNO].Hours) && CanTakeClass(degree, degree.RequiredCourses[classNO]))
                {
                    semester = CreateSemester(semester, classNO + 1, degree);
                    semester.Courses.Add(degree.RequiredCourses[classNO]);
                }

                semester = CreateSemester(semester, classNO + 1, degree);

            }

            return semester;
        }


        private void RemoveTaken()
        {
            Degree temp = DegreePlan;

            temp.ElectiveCourses.Clear();
            temp.RequiredCourses.Clear();

            foreach (Course course in DegreePlan.RequiredCourses)
            {
                if (!course.Taken)
                {
                    temp.RequiredCourses.Add(course);
                }
            }

            foreach (Elective elective in DegreePlan.ElectiveCourses)
            {
                bool taken = false;

                foreach (Course course in elective.Courses)
                {
                    if (course.Taken)
                    {
                        taken = true;
                    }
                }

                if (!taken)
                {
                    temp.ElectiveCourses.Add(elective);
                }
            }


        }
    }
}

