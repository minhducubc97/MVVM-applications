using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteCommunication
{
    class Program
    {
        // File name
        private const string FileName = "NewDatabase.sqlite3"; // Extension is up to developer's choice, sqlite indicate using SQLite, version 3
        static void Main(string[] args)
        {

            // create a database file
            if (!File.Exists(FileName))
            {
                SQLiteConnection.CreateFile(FileName);
            }
            else
            {
                File.Delete(FileName);
                SQLiteConnection.CreateFile(FileName);
            }

            // create a connection using connection string from https://www.connectionstrings.com/sqlite/
            using (SQLiteConnection theConnection = new SQLiteConnection("Data Source=" + FileName + ";Version=3;"))
            {
                // start the connection
                theConnection.Open();

                // create a table named students with 2 columns, the first contains names that contain maximum 30 characters, the second contains id
                string sql = "CREATE TABLE IF NOT EXISTS [students] ([name] VARCHAR(30), [id] INT)";

                // create SQL Command Object to execute the command
                SQLiteCommand theCommand = new SQLiteCommand(sql, theConnection);
                theCommand.ExecuteNonQuery();

                // start filling the table
                string sqlCommand1 = "INSERT INTO students (name, id) values ('Duc', 1234567)";
                SQLiteCommand Command1 = new SQLiteCommand(sqlCommand1, theConnection);
                Command1.ExecuteNonQuery();
                string sqlCommand2 = "INSERT INTO students (name, id) values ('Lan', 2104005)";
                Command1 = new SQLiteCommand(sqlCommand2, theConnection);
                Command1.ExecuteNonQuery();
                string sqlCommand3 = "INSERT INTO students (name, id) values ('ABC', 2342919)";
                Command1 = new SQLiteCommand(sqlCommand3, theConnection);
                Command1.ExecuteNonQuery();

                // get data from the table
                string sqlResult = "SELECT * FROM students order by id desc";   // query the database sorted by id in descending order

                // read the results of the query
                SQLiteCommand getCommand = new SQLiteCommand(sqlResult, theConnection);
                SQLiteDataReader reader = getCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name: " + reader["name"] + "\tStudent ID: " + reader["id"]);
                }

                // stop the connection after the job
                theConnection.Close();

                // keep the console open for observation
                Console.Read();
            }
        }
    }
}
