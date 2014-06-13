using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace school_form
{
    public class Course
    {
        public bool Taken;

        public bool CurrentlyTaking;

        public int DefaultSemester { get; set; }

        public string Name;

        public int Hours;

        public int Depth;

        public string Prereq;

        public string CoReq;

        public string PrereqOrCoreq;

        public Course(string name, bool taken, int hours, int defaultSemester)
        {
            Name = name;
            Taken = taken;
            Hours = hours;
            DefaultSemester = defaultSemester;
        }

        public Course(string name, bool taken, int hours)
        {
            Name = name;
            Taken = taken;
            Hours = hours;
        }

        public Course(string name, bool taken, int hours, string prereq)
        {
            Name = name;
            Taken = taken;
            Hours = hours;
            Prereq = prereq;
        }

    }
}
