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
    public class EnrollmentRepository
    {
        private string _connectionString;
        public EnrollmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Enrollment enrollment)
        {
            string query = @"INSERT INTO 
                                [Enrollment] 
                            VALUES(
                                @EnrollmentDate, 
                                @EnrollmentValue, 
                                @StudentClass, 
                                @StudentId, 
                                @CourseId)";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        EnrollmentDate = enrollment.EnrollmentDate,
                        EnrollmentValue = enrollment.EnrollmentValue,
                        StudentClass = enrollment.StudentClass,
                        StudentId = enrollment.Student.Id,
                        CourseId = enrollment.Course.Id
                    });
            }
        }

        public int Update(Enrollment enrollment, int id)
        {
            string query = @"UPDATE [Enrollment] 
                            SET 
                                [EnrollmentDate]=@EnrollmentDate, 
                                [EnrollmentValue]=@EnrollmentValue, 
                                [StudentClass]=@StudentClass, 
                                [StudentId]=@StudentId, 
                                [CourseId]=@CourseId, 
                            WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        EnrollmentDate = enrollment.EnrollmentDate,
                        EnrollmentValue = enrollment.EnrollmentValue,
                        StudentClass = enrollment.StudentClass,
                        StudentId = enrollment.Student.Id,
                        CourseId = enrollment.Course.Id,
                        Id = id
                    });
            }
        }

        public int Delete(int id)
        {
            string query = @"DELETE FROM [Enrollment] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, new { Id = id });
            }
        }

        public IEnumerable<Enrollment> Get()
        {
            string query = @"SELECT [Id], [EnrollmentDate], [EnrollmentValue], [StudentClass], [StudentId], [CourseId] FROM [Enrollment]";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Enrollment>(query);
            }
        }

        public IEnumerable<Enrollment> GetById(int id)
        {
            string query = @"SELECT [Id], [EnrollmentDate], [EnrollmentValue], [StudentClass], [StudentId], [CourseId] FROM [Enrollment] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Enrollment>(query, new { Id = id });
            }
        }
    }
}
