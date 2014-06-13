using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
     public class Elective
    {
        public List<Course> Courses { get; set; }

        public string Name { get; set; }

        public Elective(string name)
        {
            Courses = new List<Course>();
            Name = name;
        }

        public bool Taken
        {
            get
            {
                bool result = false;
                foreach (Course course in Courses)
                {
                    if (course.Taken)
                    {
                        result = true;
                    }
                }


                return result;
            }
        }
    }
}