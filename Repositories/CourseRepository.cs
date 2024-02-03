using Dapper;
using DapperNotes.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Repositories
{
    public class CourseRepository
    {
        private string _connectionString;
        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Course course)
        {
            string query = @"INSERT INTO [Course] VALUES(@Name, @MonthlyPrice, @CourseTime)";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        Name = course.Name,
                        MonthlyPrice = course.MonthlyPrice,
                        CourseTime = course.CourseTime
                    });
            }
        }

        public int Update(Course course, int id)
        {
            string query = @"UPDATE [Course] SET [Name]=@Name, [MonthlyPrice]=@MonthlyPrice, [CourseTime]=@CourseTime WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        Name = course.Name,
                        MonthlyPrice = course.MonthlyPrice,
                        CourseTime = course.CourseTime,
                        Id = id
                    });
            }
        }

        public int Delete(int id)
        {
            string query = @"DELETE FROM [Course] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, new { Id = id });
            }
        }

        public IEnumerable<Course> Get()
        {
            string query = @"SELECT [Id], [Name], [MonthlyPrice], [CourseTime] FROM [Course]";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Course>(query);
            }
        }

        public IEnumerable<Course> GetById(int id)
        {
            string query = @"SELECT [Id], [Name], [MonthlyPrice], [CourseTime]  FROM [Course] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Course>(query, new { Id = id });
            }
        }
    }
}
