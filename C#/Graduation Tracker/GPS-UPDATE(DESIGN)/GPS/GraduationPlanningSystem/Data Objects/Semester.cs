using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
    public class Semester
    {
        public List<Course> Courses;

        public Semester()
        {
            Courses = new List<Course>();
            TotalAllowedHours = 15;

        }

        public int TotalAllowedHours;

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
