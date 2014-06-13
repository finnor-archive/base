using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
    /// <summary>
    /// Class used to represent requirements that can be met with multiple courses.
    /// </summary>
     public class Elective
    {
         //List of courses that satisfy the requirement
        public List<Course> Courses { get; set; }

         //gets the number of hours required to complete this elective
        public int Hours { get; set; }

        public int RemainingHours { get; set; }

        //Readable name of the elective
        public string Name { get; set; }

         public Elective (){}

         /// <summary>
         /// Constructor with name.
         /// </summary>
         /// <param name="name"></param>
        public Elective(string name, int hours)
        {
            Courses = new List<Course>();
            Name = name;
            Hours = hours;
            RemainingHours = 0;
        }
    }
}