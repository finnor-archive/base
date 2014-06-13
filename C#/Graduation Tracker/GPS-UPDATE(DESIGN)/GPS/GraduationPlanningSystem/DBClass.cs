using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace GraduationPlanningSystem
{
    public class DBClass
    {
        String path;

        public DBClass()
        {
            path = @"Data Source=" + Directory.GetCurrentDirectory() + "\\Database\\db";
        }

        // input is a SQL query string, outputs result of query
        public DataTable queryDB(String query)
        {
            DataTable data = new DataTable();
            try
            {
                SQLiteConnection connection = new SQLiteConnection(path);
                connection.Open();
                SQLiteCommand myQuery = new SQLiteCommand(connection);
                myQuery.CommandText = query;
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
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
                SQLiteConnection connection = new SQLiteConnection(path);
                connection.Open();
                SQLiteCommand myQuery = new SQLiteCommand(connection);
                myQuery.CommandText = "SELECT * FROM classes where "+type+"='"+name+"';";
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        //queries the database for a match that may be within a string, e.g. find a prereq in a list of prereqs, find if a semester offered is fall 'F' in'SMF'
        public DataTable findIfContatins(String name, String type)
        {
            DataTable data = new DataTable();
            try
            {
                SQLiteConnection connection = new SQLiteConnection(path);
                connection.Open();
                SQLiteCommand myQuery = new SQLiteCommand(connection);
                myQuery.CommandText = "SELECT * FROM classes where " + type + " like '%" + name + "%';";
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
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
                SQLiteConnection connection = new SQLiteConnection(path);
                connection.Open();

                SQLiteCommand myQuery = new SQLiteCommand(connection);
                myQuery.CommandText = "SELECT * FROM classes where courseNum like '__ "+level+"%';";
                SQLiteDataReader reader = myQuery.ExecuteReader();
                data.Load(reader);

                myQuery.CommandText = "SELECT * FROM classes where courseNum like '___ " + level + "%';";
                reader = myQuery.ExecuteReader();
                data2.Load(reader);

                data.Merge(data2);
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            DataRow[] rows = data.Select();
            Object[] rowArray;

            List<String> classes100 = new List<String>();
            for (int i=0; i<rows.Length; i++)
            {
                rowArray = rows[i].ItemArray;
                classes100.Add((String) rowArray[1]);
            }
            return (classes100);
        }
    }
}
