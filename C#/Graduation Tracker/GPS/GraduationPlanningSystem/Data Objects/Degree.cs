using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
    /// <summary>
    /// Represents a total degree/plan
    /// </summary>
    public class Degree : Object
    {
        //List of all "Required classes"
        public List<Course> RequiredCourses { get; set; }

        //List of all electives required for graduation
        public List<Elective> ElectiveCourses { get; set; }

        //All semsters.
        public List<Semester> Semesters { get; set; }

        public List<Course> TakenCourses { get; set; }

        //English readable name
        public string Name { get; set; }

        //Maximum allowable semesters to graduate
        public int MaxSemesters { get; set; }

        private void InitializeSemesters()
        {
            for (int i = 0; i < MaxSemesters; i++)
            {
                //this.Semesters.Add(new Semester());
            }
        }

        /// <summary>
        /// Returns a list of every semester a class is taken
        /// </summary>
        /// <param name="courseName">name of the course</param>
        /// <returns>List of each semester the class is taken and passed.</returns>
        public List<int> SemesterCourseTaken(string courseName)
        {
            List<int> result = new List<int>();

            foreach (Course course in TakenCourses)
            {
                if (courseName == course.Name || courseName == course.UID)
                {
                    result.Add(-1);
                    break;
                }
            }

            for (int i = 0; i < this.Semesters.Count; i++)
            {
                //only keep if the class is passed
                if (this.Semesters[i].ClassIsTakenAndPasses(courseName))
                    result.Add(i);
            }

            return result;
        }

        /// <summary>
        /// Very basic constructor
        /// </summary>
        public Degree()
        {
            this.MaxSemesters = 12;
            RequiredCourses = new List<Course>();
            ElectiveCourses = new List<Elective>();
            this.Semesters = new List<Semester>();
            InitializeSemesters();
            this.TakenCourses = new List<Course>();
        }

        /// <summary>
        /// Very basic constructor
        /// </summary>
        public Degree(string name)
        {
            this.MaxSemesters = 12;
            this.Name = name;
            RequiredCourses = new List<Course>();
            ElectiveCourses = new List<Elective>();
            this.Semesters = new List<Semester>();
            InitializeSemesters();
            this.TakenCourses = new List<Course>();
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="required">list of required classes to graduate</param>
        /// <param name="electives">list of electives needed to graduate</param>
        /// <param name="name">name of the degree</param>
        public Degree(List<Course> required, List<Elective> electives, string name)
        {
            RequiredCourses = required;
            ElectiveCourses = electives;
            Name = name;
            Semesters = new List<Semester>();
            this.TakenCourses = new List<Course>();
            InitializeSemesters();
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="required">list of required classes to graduate</param>
        /// <param name="electives">list of electives needed to graduate</param>
        /// <param name="name">name of the degree</param>
        public Degree(List<Course> required, List<Elective> electives, string name, List<Semester> semesters)
        {
            RequiredCourses = required;
            ElectiveCourses = electives;
            Name = name;
            Semesters = semesters;
            this.TakenCourses = new List<Course>();
        }



        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="required">list of required classes to graduate</param>
        /// <param name="electives">list of electives needed to graduate</param>
        /// <param name="name">name of the degree</param>
        public Degree(string name, int maxSemesters)
        {
            Name = name;
            ElectiveCourses = new List<Elective>();
            RequiredCourses = new List<Course>();
            Semesters = new List<Semester>();
            this.MaxSemesters = maxSemesters;
            this.TakenCourses = new List<Course>();
            InitializeSemesters();
        }

        /// <summary>
        /// Used to determine if an elective will be taken
        /// </summary>
        /// <param name="elective"t>the elective to be checked</param>
        /// <returns>remaining hours to be taken</returns>
        public int ElectiveBeingTaken(Elective elective)
        {
            if (elective.Courses.Count == 0)
                return 0;
            Int64 hours = elective.Hours;
            //check every course that qualifies in the elective
            foreach (Course course in elective.Courses)
            {
                //and every semester
                foreach (Semester semester in this.Semesters)
                {
                    //and every course in these semesters
                    foreach (Course sCourse in semester.Courses)
                    {
                        if (sCourse.Name == course.Name && sCourse.Status != Course.AcademicStatus.Failed)
                        {
                            //keep a record of the total hours taken
                            hours -= course.Hours;
                        }
                    }
                }
            }
            //not found if hours > required hours
            return (int)hours;
        }

        static public Degree LoadDegree(DBClass db, string degree)
        {
            Degree ce = new Degree("CE");
            degree = degree.Replace(" ", "_");
            ce.RequiredCourses = db.FindRequirements(degree);

            Elective upper = new Elective(degree.Replace("_", " ") + "Electives", 6);
            upper.Courses = db.FindElectives(degree);

            List<Elective> humanities = new List<Elective>();
            humanities = db.FindSSElectives(degree);

            foreach (Elective elect in humanities)
            {
                ce.ElectiveCourses.Add(elect);
            }

            ce.ElectiveCourses.Add(upper);

            return ce;
        }

        static public  Degree LoadCPE(DBClass db)
        {
            Degree ce = new Degree("CE");
            ce.RequiredCourses = db.FindRequirements("Computer_Engineering");

            //Elective english1 = new Elective("English 1", 3);
            //english1.Courses.Add(new Course("EH00101", Course.AcademicStatus.NotYetTaken));

            //Elective english2 = new Elective("English 2", 3);
            //english1.Courses.Add(new Course("EH00102", Course.AcademicStatus.NotYetTaken));

            Elective upper = new Elective("CPE Electives", 9);
            upper.Courses = db.FindElectives("Computer_Engineering");

            List<Elective> humanities = new List<Elective>();
            humanities = db.FindSSElectives("Computer_Engineering");

            foreach (Elective elect in humanities)
            {
                ce.ElectiveCourses.Add(elect);
            }

         
            ce.ElectiveCourses.Add(upper);

            return ce;

        }

        static public Degree AutoFillSemesters(Degree degree)
        {

            for (int i = 0; i < degree.MaxSemesters; i++)
            {
                if (degree.Semesters.Count <= i)
                    degree.Semesters.Add(new Semester());
                if ((i % 3) == 2)
                    degree.Semesters[i].TotalAllowedHours = 0;
                else
                    degree.Semesters[i].TotalAllowedHours = 16;
            }

            return degree;
        }

        static public Degree LoadDegreeFromDB(DBClass db)
        {
            return null;
        }

        static public Degree LoadEE(DBClass db)
        {
            Degree ee = new Degree("EE");
            ee.RequiredCourses = db.FindRequirements("Electrical_Engineering");      

            Elective upper = new Elective("CPE Electives", 9);
            upper.Courses = db.FindElectives("Electrical_Engineering");

            List<Elective> humanities = new List<Elective>();
            humanities = db.FindSSElectives("Electrical_Engineering");

            foreach (Elective elect in humanities)
            {
                ee.ElectiveCourses.Add(elect);
            }

            ee.ElectiveCourses.Add(upper);

            return ee;

        }


         static public Degree LoadOPE(DBClass db)
        {
            Degree ope = new Degree("OPE");
            ope.RequiredCourses = db.FindRequirements("Optical_Engineering");

            Elective upper = new Elective("OPE Electives", 3);
            upper.Courses = db.FindElectives("Optical_Engineering");

            List<Elective> humanities = new List<Elective>();
            humanities = db.FindSSElectives("Optical_Engineering");

            foreach (Elective elect in humanities)
            {
                ope.ElectiveCourses.Add(elect);
            }

            ope.ElectiveCourses.Add(upper);

            return ope;

        }


        /// <summary>
        /// Returns a shallow clone of the degree.
        /// </summary>
        /// <returns></returns>
        public Degree Clone()
        {
            Degree temp = new Degree(this.Name, this.MaxSemesters);
            temp.Semesters.Clear();
            foreach (Semester semester in Semesters)
            {
                Semester tempS = new Semester();
                foreach (Course course in semester.Courses)
                {
                    tempS.Courses.Add(new Course(course.Name, course.Status));
                }
                tempS.TotalAllowedHours = semester.TotalAllowedHours;
                temp.Semesters.Add(tempS);

            }

            while (temp.Semesters.Count < temp.MaxSemesters)
            {
                temp.Semesters.Add(new Semester());
            }
            temp.RequiredCourses = this.RequiredCourses;
            temp.ElectiveCourses = this.ElectiveCourses;

            foreach (Course course in this.TakenCourses)
            {
                temp.TakenCourses.Add(course);
            }
            //Btemp.MaxSemesters = this.MaxSemesters;
            return temp;// (Degree)this.MemberwiseClone();
        }

    }
}

