using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace GraduationPlanningSystem.Data_Objects
{
    /// <summary>
    /// This class is used to generate schedules for a degree
    /// </summary>
    public class DegreePlanner
    {
        const int NOTTAKEN = -2;
        const int ALREADYTAKEN = -1;

        /// <summary>
        /// Basic contructor
        /// </summary>
        public DegreePlanner()
        { }


        public void OrderCourses(Degree degree)
        {
            List<Course> allCourses = new List<Course>();

            foreach (Course course in degree.RequiredCourses)
            {
                course.Depth = 0;
                allCourses.Add(course);
            }

            foreach (Elective elective in degree.ElectiveCourses)
            {
                foreach (Course course in elective.Courses)
                {
                    course.Depth = 0;
                    allCourses.Add(course);
                }
            }

            foreach (Course course in allCourses)
            {
                FindDepth(course, allCourses);
            }
            List<Course> newlist = degree.RequiredCourses.OrderByDescending(x => x.Depth).ToList();
            degree.RequiredCourses = newlist;
            //degree.RequiredCourses.Sort(
            //degree.RequiredCourses.Sort((x) => x.Depth);
        }

        private List<string> GetPostReqs(Course course, List<Course> courselist)
        {
            List<string> result = new List<string>();

            foreach (Course req in courselist)
            {
                foreach (string pre in req.Prereq)
                {
                    if (pre == course.UID || pre == course.Name)
                    {
                        result.Add(req.UID);
                        break;
                    }
                }
            }

            return result;
        }

        private int FindDepth(Course course, List<Course> courselist)
        {
            //int result = 1;
            int highest = 0;
            List<string> posts = GetPostReqs(course, courselist);

            if (posts.Count == 0)
            {
                course.Depth = 1;
                return 1;
            }
            foreach (string courseUID in posts)
            {
                Course temp = GetCourseFromUID(courseUID, courselist);

                if (temp.Depth == 0)
                {
                    int tempDepth = FindDepth(temp, courselist);
                    if (tempDepth > highest)
                        highest = tempDepth;
                }
                else
                {
                    if (temp.Depth > highest)
                        highest = temp.Depth;
                }
            }
            course.Depth = highest + 1;
            return highest + 1;
        }

        private Course GetCourseFromUID(string UID, List<Course> courselist)
        {
            Course result = null;

            foreach (Course course in courselist)
            {
                if (UID == course.UID)
                    return course;
            }

            return result;
        }

        /// <summary>
        /// Used to see if a class may be taken in a certain semester.
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        private bool CanTakeClass(Degree degree, Course course)
        {
            bool result = true;

            if (course.Status == Course.AcademicStatus.Failed)
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
                        if (tempCourse.Status == Course.AcademicStatus.Failed)
                        {
                            result = false;
                        }
                    }
                }
            }

            return result;
        }

        #region deprecated

        //private List<Semester> ListSemesters(Degree degree)
        //{
        //    List<Semester> result = new List<Semester>();
        //    int reqs = degree.RequiredCourses.Count;
        //    int elect = degree.ElectiveCourses.Count;
        //    int total = reqs + elect;

        //    // for (int i = 0; i < 

        //    return result;
        //}

        //public List<Degree> FillSemesterList(Degree degree, int semesterNo)
        //{
        //    PossibleDegrees = new List<Degree>();

        //    //ElapseTime = new Stopwatch();
        //    //ElapseTime.Start();
        //    //FillSemesterListInternal(degree, semesterNo);

        //    int required = degree.RequiredCourses.Count;
        //    int electives = degree.ElectiveCourses.Count;
        //    int total = required + electives;
        //    int possible = Convert.ToInt32(Math.Pow(2, total));

        //    for (int i = 0; i < possible; i++)
        //    {
        //        SlowFillSemester(degree, i, semesterNo);
        //    }

        //    return PossibleDegrees;
        //}

        //public Degree GetOneDegree(Degree degree)
        //{
        //    Random rand = new Random();

        //    return degree;

        //}


        #endregion

        /// <summary>
        /// Used to check if a course is already taken
        /// </summary>
        /// <param name="semester">The semester to check</param>
        /// <param name="course">The course</param>
        /// <returns></returns>
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

        public List<Degree> GenerateSchedules(Degree degree, int results)
        { 
            List<Degree> result = new List<Degree>();
            OrderCourses(degree);
           
            for (int i = 0; i < results; i++)
            {
                result.Add(RandomFill(degree, 0));
            }

            return result;
        }

        /// <summary>
        /// Fills the degre randomly with courses to take.  Will return the result.
        /// </summary>
        /// <param name="degree">Degree to fill</param>
        /// <returns> Generated schedule</returns>
        private Degree RandomFill(Degree degree, int passNo)
        {
            Random rand = new Random();

            int highestDepth = degree.RequiredCourses[0].Depth;
            
            //clone the degree to avoid overwriting
            Degree result = degree.Clone();
            //add semesters as needed
            while (result.Semesters.Count < result.MaxSemesters)
            {
                result.Semesters.Add(new Semester());
            }

            //make sure every required class is taken
            foreach (Course course in result.RequiredCourses)
            {
                int taken = CourseIsTaken(result, course);
                //add if not taken
                if (taken == NOTTAKEN)
                {
                    //get a list of possible semesters to take
                    List<int> availableSemesters = PossibleSemestersWithCoreqs (course, result);

                 
                    //if we can actually take the course...
                    if (availableSemesters.Count > 0)
                    {
                        int seed = (highestDepth - course.Depth) - (degree.MaxSemesters - availableSemesters.Count);
                        if (seed < 0)
                            seed = 0;
                        if (availableSemesters.Count < seed)
                        {
                            seed = availableSemesters.Count;
                        }
                        //place the course in one of the random semesters.
                        int x = rand.Next(seed);
                        result.Semesters[availableSemesters[x]].Courses.Add(course);

                        foreach (string co in course.CoReq)
                        {
                            result.Semesters[availableSemesters[x]].Courses.Add(new Course(co, Course.AcademicStatus.NotYetTaken));
                        }
                    }
                    
                }
            }

            //now add in each elective
            foreach (Elective elective in result.ElectiveCourses)
            {
                int remainingHours = result.ElectiveBeingTaken(elective);
                int availableHours = AvailableElectiveHours(elective, result);
                while (remainingHours > 0 && availableHours > 0)
                {
                    
                    List<Course> untaken = ElectivesNotTaken(elective, result);
                    untaken = untaken.OrderByDescending(x => x.Depth).ToList();
                    int maxElectDepth = untaken[0].Depth;
                    Course course = untaken[rand.Next(untaken.Count)];
                    
                    List<int> availableSemesters = PossibleSemestersWithCoreqs(course, result);

                    if (availableSemesters.Count > 0)
                    {
                        int seed = (highestDepth - course.Depth) - (degree.MaxSemesters - availableSemesters.Count);
                        if (seed < 0)
                            seed = 0;
                        if (availableSemesters.Count < seed)
                        {
                            seed = availableSemesters.Count;
                        }

                        int x = rand.Next(seed);
                        result.Semesters[availableSemesters[x]].Courses.Add(course);

                        foreach (string co in course.CoReq)
                        {
                            result.Semesters[availableSemesters[x]].Courses.Add(new Course(co, Course.AcademicStatus.NotYetTaken));
                        }
                    }

                    remainingHours = result.ElectiveBeingTaken(elective);
                    availableHours = AvailableElectiveHours(elective, result);
                }

                
            }
            if (passNo < 5)
                return RandomFill(result, ++passNo);
            return result;
        }

        public List<Course> ElectivesNotTaken(Elective elective, Degree degree)
        {
            List<Course> result = new List<Course>();

            foreach (Course course in elective.Courses)
            {
                if (CourseIsTaken(degree, course) == NOTTAKEN)
                {
                    if (PossibleSemestersWithCoreqs(course, degree).Count > 0)
                        result.Add(course);
                }
            }

            return result;
        }

        public int AvailableElectiveHours(Elective elective, Degree degree)
        {
            Int64 result = 0;

            foreach (Course course in elective.Courses)
            {
                int temp = CourseIsTaken(degree, course);
                if (temp == NOTTAKEN &&  PossibleSemestersWithCoreqs(course, degree).Count > 0)
                {
                    result += course.Hours;
                }

            }

            return (int)result;
        }

        private int CourseLevel(Course course)
        {
            int result = 4;

            try
            {
                string number = course.CourseNumber.Substring(course.CourseNumber.Length - 3);
                string temp2 = number.Substring(0, 1);
                int temp = Convert.ToInt32(temp2);
                result = temp;
            }
            catch
            { }

            if (result < 1 || result > 4)
                return 4;
            return result;
        }

        /// <summary>
        /// returns the semester the course is taken.
        /// </summary>
        /// <param name="semesters"></param>
        /// <param name="course"></param>
        /// <returns>-1 if the course is in the taken list.  -2 means the course is not taken</returns>
        private int CourseIsTaken(Degree degree, Course course)
        {
            foreach (Course taken in degree.TakenCourses)
            {
                if (taken.Name ==course.Name)
                    return ALREADYTAKEN;
            }
            
            for (int i = 0; i < degree.Semesters.Count; i++)
            {
                foreach (Course foundCourse in degree.Semesters[i].Courses)
                {
                 
                    if (course.UID == foundCourse.UID && foundCourse.Status != Course.AcademicStatus.Failed)
                        return i;
                }
            }

            return NOTTAKEN;
        }

        private List<int> PossibleSemestersWithCoreqs(Course course, Degree degree)
        {
            List<int> combinedresult = new List<int>();
            List<int> courseResult = new List<int>();
            
            combinedresult = PossibleSemesters(course, degree);

            foreach (string co in course.CoReq)
            {
                Course coreq = new Course(co, Course.AcademicStatus.NotYetTaken);
                courseResult = PossibleSemesters(coreq, degree);
                List<int> temp = new List<int>();

                foreach (int x in combinedresult)
                {
                    if (courseResult.Contains(x))
                        temp.Add(x);
                }
                combinedresult = temp;
            }


            return combinedresult;
        }

        /// <summary>
        /// grabs a list of possible semesters  for the degree... deprecated
        /// </summary>
        /// <param name="course"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        private List<int> PossibleSemesters(Course course, Degree degree)
        {
            List<int> courseResult = new List<int>();
            //List<int> result = new List<int>();

            int earliest = EarliestSemesterTaken(course, degree);
            if (earliest >= 0)
            {
                for (int i = earliest; i < degree.Semesters.Count; i++)
                {
                    if (degree.Semesters[i].TotalAllowedHours >= degree.Semesters[i].TotalHours + course.Hours)
                        courseResult.Add(i);
                }
            }    

            return courseResult;
        }

        /// <summary>
        /// rgrabs the earliest instance of the course taken
        /// </summary>
        /// <param name="course"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        private int EarliestSemesterTaken(Course course, Degree degree)
        {
            int result = 0;

            if (course.Prereq != null && course.Prereq.Count > 0)
            {
                result = -2;
                foreach (string prereq in course.Prereq)
                {
                    List<int> semester = degree.SemesterCourseTaken(prereq);
                    semester.Sort();
                    if (semester.Count > 0)
                    {
                        if ( result < semester[0] && semester[0] < degree.MaxSemesters)
                            result = semester[0] + 1;
                    }
                }
            }
            return result;
        }

        #region deprecated

        //private Degree SlowFillSemester(Degree degree, int degreeNumber, int semesterNo)
        //{
        //    int required = degree.RequiredCourses.Count;
        //    int electives = degree.ElectiveCourses.Count;
        //    int total = required;// +electives;

        //    char[] binary = GetIntBinaryString(degreeNumber, total).ToCharArray();
        //    while (binary.Length < total)
        //    {
        //        binary = (binary.ToString() + "0").ToCharArray();
        //    }

        //    Semester semester = new Semester();

        //    for (int i = 0; i < total; i++)
        //    {
        //        if (binary[i] == '1')
        //        {
        //            //degree
        //        }
        //    }

        //    return degree;
        //}

        //private string GetIntBinaryString(int n, int length)
        //{
        //    char[] b = new char[length];
        //    int pos = length - 1;
        //    int i = 0;

        //    while (i < length)
        //    {
        //        if ((n & (1 << i)) != 0)
        //        {
        //            b[pos] = '1';
        //        }
        //        else
        //        {
        //            b[pos] = '0';
        //        }
        //        pos--;
        //        i++;
        //    }
        //    return new string(b);
        //}


        //private void RemoveTaken()
        //{
        //    Degree temp = DegreePlan;

        //    temp.ElectiveCourses.Clear();
        //    temp.RequiredCourses.Clear();

        //    foreach (Course course in DegreePlan.RequiredCourses)
        //    {
        //        if (course.Status != Course.AcademicStatus.Failed)
        //        {
        //            temp.RequiredCourses.Add(course);
        //        }
        //    }

        //    foreach (Elective elective in DegreePlan.ElectiveCourses)
        //    {
        //        bool taken = false;

        //        foreach (Course course in elective.Courses)
        //        {
        //            if (course.Status != Course.AcademicStatus.Failed)
        //            {
        //                taken = true;
        //            }
        //        }

        //        if (!taken)
        //        {
        //            temp.ElectiveCourses.Add(elective);
        //        }
        //    }


        //}
        #endregion

    }

    internal class CourseDepth
    {
        public string Name;

        public int Depth;

        CourseDepth(string name, int depth)
        {
            Name = name;
            Depth = depth;
        }
    }
}

