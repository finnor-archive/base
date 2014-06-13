using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using GraduationPlanningSystem.Data_Objects;

namespace GraduationPlanningSystem
{
    /// <summary>
    /// used to read from the database and populate data objects
    /// author: adrian
    /// </summary>
    public class DBClass
    {
        String mPath;
        SQLiteConnection mConnection;
        SQLiteCommand myQuery;
        public DBClass()
        {
            try
            {
                mPath = @"Data Source=" + Directory.GetCurrentDirectory() + "\\Database\\db";
                // RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\GPS");
                //// MessageBox.Show((string)registryKey.GetValue("dbLocation") + "\\db");
                // mPath = (string)registryKey.GetValue("dbLocation") + "\\db";
                // mPath = @"Data Source=" + Directory.GetCurrentDirectory() + "\\Database\\db";
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                mPath = @"Data Source=" + Directory.GetCurrentDirectory() + "\\Database\\db";
            }

            mConnection = new SQLiteConnection(mPath);
            mConnection.Open();
            myQuery = new SQLiteCommand(mConnection);

            // 
        }

        // input is a SQL query string, outputs result of query
        public DataTable queryDB(String query)
        {
            DataTable data = new DataTable();
            try
            {

                SQLiteCommand myQuery = new SQLiteCommand(mConnection);
                myQuery.CommandText = query;
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }
            return data;
        }


        //queries the database for an exact match in the type selected
        public DataTable find(String name, String type)
        {
            DataTable data = new DataTable();
            try
            {


                //SQLiteCommand myQuery = new SQLiteCommand(mConnection);
                myQuery.CommandText = "SELECT * FROM classes where " + type + "='" + name + "';";
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }
            return data;
        }

        public List<string> GetDegreeCodes()
        {
            List<string> result = new List<string>();

            try
            {
                string query = "SELECT * FROM degreeTypes";
                DataTable degrees = GraduationPlanningSystem.db.queryDB(query);
                foreach (DataRow degree in degrees.Select())
                {
                    // this should give you the uid of each course in the Computer_Engineering_Req table
                    result.Add((String)degree[1]);
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public string GetDegreeFromCode(string code)
        {
            string result = "";

            try
            {
                string query = "SELECT Degree FROM degreeTypes where degreeID = '" + code + "'";
                DataTable degrees = GraduationPlanningSystem.db.queryDB(query);
                foreach (DataRow degree in degrees.Select())
                {
                    // this should give you the uid of each course in the Computer_Engineering_Req table
                    return ((String)degree[0]);
                }
                return result;
            }
            catch
            {
                return "";
            }
        }

     

        public List<Course> FindRequirements(string tableName)
        {
            String query;

            DataTable Computer_Engineering_Courses;

            List<Course> result = new List<Course>();

            query = "SELECT * FROM " + tableName + "_Req";
            Computer_Engineering_Courses = GraduationPlanningSystem.db.queryDB(query);
            foreach (DataRow req_course in Computer_Engineering_Courses.Select())
            {
                // this should give you the uid of each course in the Computer_Engineering_Req table
                String course_uid = (String)req_course[0];
                Course course = new Course(course_uid, Course.AcademicStatus.NotYetTaken);

                if (course.Name != "" && course.Name != null)
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public List<Course> FindElectives(string tableName)
        {
            String query;

            DataTable Computer_Engineering_Courses;

            List<Course> result = new List<Course>();

            query = "SELECT * FROM " + tableName + "_Electives";
            Computer_Engineering_Courses = GraduationPlanningSystem.db.queryDB(query);
            foreach (DataRow req_course in Computer_Engineering_Courses.Select())
            {
                // this should give you the uid of each course in the Computer_Engineering_Req table
                String course_uid = (String)req_course[0];
                Course course = new Course(course_uid, Course.AcademicStatus.NotYetTaken);

                if (course.Name != "" && course.Name != null)
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public List<Elective> FindSSElectives(string tableName)
        {
            String query;
            List<Elective> result = new List<Elective>();
            DataTable Computer_Engineering_Courses;

            List<Course> nonhist = new List<Course>();

            Elective history = new Elective("History", 9);
            Elective ss = new Elective("Humanities", 9);
            query = "SELECT * FROM " + tableName + "_SSElectives";
            Computer_Engineering_Courses = GraduationPlanningSystem.db.queryDB(query);
            foreach (DataRow req_course in Computer_Engineering_Courses.Select())
            {
                // this should give you the uid of each course in the Computer_Engineering_Req table
                String course_uid = (String)req_course[0];
                Course course = new Course(course_uid, Course.AcademicStatus.NotYetTaken);

                if (course.Name != "" && course.Name != null)
                {
                    if (course.Department == "History")
                        history.Courses.Add(course);
                    else
                        ss.Courses.Add(course);
                    
                }
            }
          
            result.Add(history);
            result.Add(ss);
            return result;
        }

        //queries the database for a match that may be within a string, e.g. find a prereq in a list of prereqs, find if a semester offered is fall 'F' in'SMF'
        public DataTable findIfContatins(String name, String type)
        {
            DataTable data = new DataTable();
            try
            {

                //SQLiteCommand myQuery = new SQLiteCommand(mConnection);
                myQuery.CommandText = "SELECT * FROM classes where " + type + " like '%" + name + "%';";
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }
            return data;
        }


        // input a level of course work and return that level of classes, e.g. 1 returns 100 level classes
        public List<String> findLevel(int level)
        {
            DataTable data = new DataTable();
            DataTable data2 = new DataTable();
            try
            {

                //SQLiteCommand myQuery = new SQLiteCommand(mConnection);
                myQuery.CommandText = "SELECT * FROM classes where courseNum like '__ " + level + "%';";
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);

                myQuery.CommandText = "SELECT * FROM classes where courseNum like '___ " + level + "%';";
                reader = myQuery.ExecuteReader();
                data2.Load(reader);

                data.Merge(data2);
                reader.Close();
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }


            DataRow[] rows = data.Select();
            Object[] rowArray;

            List<String> classes100 = new List<String>();
            for (int i = 0; i < rows.Length; i++)
            {
                rowArray = rows[i].ItemArray;
                classes100.Add((String)rowArray[1]);
            }
            return (classes100);
        }
    }
}
