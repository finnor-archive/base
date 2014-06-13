using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
    public class Course
    {
        //True if the course has been taken
        public bool Taken;

        public int DefaultSemester { get; set; }

        //Name of the course.  May need to change or add a course ID.
        public string Name;

        //Unique identifier for the course
        public string UID;

        //Semesters that the Course Is Offered
        public string SemOffered;

        //Course Number e.g. CS101
        public string CourseNumber;

        //Department course is offered in
        public string Department;

        //Number of credit hours.
        public Int64 Hours;

        //Name of the prereq course
        public List<string> Prereq;

        //Name of the coreq course
        public List<string> CoReq;

        public List<string> PrereqOrCoreq;


        public Course(string name, bool taken, Int64 hours, int defaultSemester)
        {
            Name = name;
            Taken = taken;
            Hours = hours;
            DefaultSemester = defaultSemester;
        }




        //Constructs Course Object, using name it queries the database and gets the information for the class
        //Class lacks exception handling and does not account for the class name entered being invalid
        public Course (string name, bool taken)
        {
            Taken = taken;

            DataTable result = GraduationPlanningSystem.db.find(name, "course");
            DataRow[] rows = result.Select();
            Object[] rowArray = rows[0].ItemArray;

            Name = (String)rowArray[1];
            UID = (String)rowArray[0];
            CourseNumber = (String)rowArray[2];
            Department = (String)rowArray[4];
            Hours = (Int64)rowArray[3];
            SemOffered = (String)rowArray[9];
            
            String entry = (String)rowArray[5];         //gets list of reqs and parses them into nodes for a list
            if (entry.Equals(""))
                CoReq = null;
            else
                CoReq = ParseGPS.parseReqs(entry);
            
            entry = (String)rowArray[6];
            if (entry.Equals(""))
                Prereq = null;
            else
                Prereq = ParseGPS.parseReqs(entry);

            entry = (String)rowArray[7];
            if (entry.Equals(""))
                PrereqOrCoreq = null;
            else
                PrereqOrCoreq = ParseGPS.parseReqs(entry);
        }




        /*
        public Course(string name, bool taken, int hours, string prereq)
        {
            Name = name;
            Taken = taken;
            Hours = hours;
            Prereq = prereq;
        }
         */

        public override string ToString()
        {
            return Name;
        }
    }
}

