using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace school_form
{
    public class Degree : Object
    {
        public List<Course> RequiredCourses { get; set; }

        public List<Elective> ElectiveCourses { get; set; }

        public List<Semester> Semesters { get; set; }

        public string Name { get; set; }

        public int HoursPerSemester;

        public Degree(List<Course> required, List<Elective> electives, string name)
        {
            RequiredCourses = required;
            ElectiveCourses = electives;
            Name = name;
            Semesters = new List<Semester>();
        }

        public Degree(List<Course> required, List<Elective> electives, string name, List<Semester> semesters)
        {
            RequiredCourses = required;
            ElectiveCourses = electives;
            Name = name;
            Semesters = semesters;
        }

        public Degree(string name)
        {
            Name = name;
            ElectiveCourses = new List<Elective>();
            RequiredCourses = new List<Course>();
            Semesters = new List<Semester>();
        }

        public List<Course> CourseListing;

        public void SetCourseListing()
        {
                List<Course> result = new List<Course>();

                foreach (Course requirement in this.RequiredCourses)
                {
                    result.Add(requirement);
                }

                foreach (Elective elect in this.ElectiveCourses)
                {
                    foreach (Course course in elect.Courses)
                    {
                        result.Add(course);
                    }
                }

                CourseListing = result;
        }

        public Degree Clone()
        {
            Degree temp = new Degree(this.Name);
            foreach (Semester semester in Semesters)
            { 
                Semester tempS = new Semester();
                foreach (Course course in semester.Courses)
                {
                    tempS.Courses.Add(new Course(course.Name, course.Taken, course.Hours, course.DefaultSemester));
                }
                temp.Semesters.Add(tempS);
         
            }
            temp.RequiredCourses = this.RequiredCourses;
            temp.ElectiveCourses = this.ElectiveCourses;
            return temp;// (Degree)this.MemberwiseClone();
        }


    }
}
