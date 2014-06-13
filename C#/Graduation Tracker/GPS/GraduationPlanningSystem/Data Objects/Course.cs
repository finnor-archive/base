using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace GraduationPlanningSystem.Data_Objects
{
    /// <summary>
    /// Class of Course, which is used to represent any class which will be taken or required.
    /// </summary>
    public class Course
    {
        //True if the course has been taken
        public AcademicStatus Status;

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

        //Names of preorcoreq courses
        public List<string> PrereqOrCoreq;

        public int Depth;

        //Deprecated 
        //public int SemesterTaken { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Course()
        {
            this.Status = AcademicStatus.NotYetTaken;
        }

        /// <summary>
        /// Converts the course name to a UID.  The method is static.  Searches the db to find the course UID.
        /// </summary>
        /// <param name="name">course name</param>
        /// <returns>UID of the found course</returns>
        static public string NameToNumber(string name)
        {
            DataTable result = GraduationPlanningSystem.db.find(name, "course");
            DataRow[] rows = result.Select();
            Object[] rowArray = rows[0].ItemArray;

            return (String)rowArray[2];
        }

        /// <summary>
        /// Converts the UID to a course name.
        /// </summary>
        /// <param name="uid">UID of the course to search</param>
        /// <returns>Name of the course</returns>
        static public string NumberToName(string uid)
        {
            try
            {
                //Search on the UID
                DataTable result = GraduationPlanningSystem.db.find(uid, "uid");
                DataRow[] rows = result.Select();
                if (rows.Count() > 0)
                {
                    Object[] rowArray = rows[0].ItemArray;

                    return (String)rowArray[1];
                }

                else
                {
                    //If the uid search fails, searh on the number.
                    result = GraduationPlanningSystem.db.find(uid, "courseNum");
                    rows = result.Select();
                    Object[] rowArray = rows[0].ItemArray;
                    return (string)rowArray[1];
                }
            }
            catch (Exception ex)
            {
                //If no result is found, return "".
                return "";
            }
        }

        //Constructs Course Object, using name it queries the database and gets the information for the class
        //Class lacks exception handling and does not account for the class name entered being invalid
        public Course (string nameorUID, AcademicStatus taken)
        {
            Depth = -1;
            if (nameorUID != "")
            {

                //Populate the course.
                this.Prereq = new List<string>();
                this.CoReq = new List<string>();
                this.PrereqOrCoreq = new List<string>();
                Status = taken;
                //SemesterTaken = -1;
                DataTable result = GraduationPlanningSystem.db.find(nameorUID, "course");

                if (result.Rows.Count == 0)
                {
                    result = GraduationPlanningSystem.db.find(nameorUID, "uid");
                }

                if (result.Rows.Count > 0)
                {
                    DataRow[] rows = result.Select();
                    Object[] rowArray = rows[0].ItemArray;

                    Name = (String)rowArray[1];
                    UID = (String)rowArray[0];
                    CourseNumber = (String)rowArray[2];
                    Department = (String)rowArray[4];
                    Hours = (Int64)rowArray[3];
                    SemOffered = (String)rowArray[9];

                    String entry = (String)rowArray[6];         //gets list of reqs and parses them into nodes for a list
                    if (entry.Equals(""))
                        CoReq = new List<string>();
                    else
                        CoReq = ParseGPS.parseReqs(entry);

                    entry = (String)rowArray[5];
                    if (entry.Equals(""))
                        Prereq = new List<string>();
                    else
                        Prereq = ParseGPS.parseReqs(entry);

                    entry = (String)rowArray[7];
                    if (entry.Equals(""))
                        PrereqOrCoreq = new List<string>();
                    else
                        PrereqOrCoreq = ParseGPS.parseReqs(entry);
                }
            }
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

        //Make comparisons easier
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Used to designate all possible outcomes.
        /// </summary>
        public enum AcademicStatus
        { 
            Pass,

            Failed,

            NotYetTaken
        }
    }
}

