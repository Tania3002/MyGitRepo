using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=students.db";

        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"CREATE TABLE IF NOT EXISTS Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT,
                Age INTEGER,
                Course TEXT
            );";

            command.ExecuteNonQuery();
        }

        public void AddStudent(string name, int age, string course)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"INSERT INTO Students (Name, Age, Course)
              VALUES ($name, $age, $course)";

            command.Parameters.AddWithValue("$name", name);
            command.Parameters.AddWithValue("$age", age);
            command.Parameters.AddWithValue("$course", course);

            command.ExecuteNonQuery();
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>();

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Age, Course FROM Students";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    Course = reader.GetString(3)
                });
            }

            return students;
        }
    }
}