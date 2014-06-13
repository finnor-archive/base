using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
    /// <summary>
    /// A class representing one semester of school
    /// </summary>
    public class Semester
    {
        /// <summary>
        /// List of all courses taken in that semester.
        /// </summary>
        public List<Course> Courses;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Semester()
        {
            Courses = new List<Course>();
            TotalAllowedHours = 16;

        }

        /// <summary>
        /// total allowable hours in a semester.
        /// </summary>
        public int TotalAllowedHours;

        /// <summary>
        /// Checks if a course has been taken and passed.
        /// </summary>
        /// <param name="courseUid">uid of course to be taken</param>
        /// <returns>true if taken.</returns>
        public bool ClassIsTakenAndPasses(string courseUid)
        {

            foreach (Course course in Courses)
            {
                if (course.UID == courseUid && course.Status != Course.AcademicStatus.Failed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// returns the total number of hours already being taken.
        /// </summary>
        public Int64 TotalHours
        {
            get
            {
                Int64 result = 0;
                if (Courses.Count > 0)
                {
                    foreach (Course course in Courses)
                    {
                        result = result + course.Hours;
                    }
                }

                return result;
            }
        }


    }
}
