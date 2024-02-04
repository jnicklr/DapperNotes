using Dapper;
using DapperNotes.DataAccess;
using DapperNotes.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly string _connectionString;
        private readonly SqlDataAccess _dataAccess;
        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dataAccess = new SqlDataAccess();
        }

        public int Add(Course course)
        {
            string query = "spAddCourse";
            return _dataAccess.SaveData(query, new
            {
                Name = course.Name,
                MonthlyPrice = course.MonthlyPrice,
                CourseTime = course.CourseTime
            }, _connectionString);
        }

        public int Update(Course course, int id)
        {
            string query = "spUpdateCourse";
            return _dataAccess.SaveData(query, new
            {
                Name = course.Name,
                MonthlyPrice = course.MonthlyPrice,
                CourseTime = course.CourseTime,
                Id = id
            }, _connectionString);
        }

        public int Delete(int id)
        {
            string query = "spDeleteCourse";
            return _dataAccess.SaveData(query, new { Id = id }, _connectionString);
        }

        public IEnumerable<Course> Get()
        {
            string query = "SELECT * FROM [vwGetCourses]";
            return _dataAccess.GetData<Course, dynamic>(query, new {}, _connectionString);
        }

        public IEnumerable<Course> GetById(int id)
        {
            string query = "SELECT * FROM [vwGetCourses] WHERE [Id]=@Id";
            return _dataAccess.GetData<Course, dynamic>(query, new { Id = id }, _connectionString);
        }
    }
}
