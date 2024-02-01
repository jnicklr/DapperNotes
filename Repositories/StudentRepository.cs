using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperNotes.Repositories
{
    public class StudentRepository
    {
        private string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Student student)
        {
            string insertSQL = @"INSERT INTO [Student] VALUES(@Name, @CPF, @BirthDate)";
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(insertSQL, new { student.Name, student.CPF, student.BirthDate });
            }
        }

        public int Update(Student student, int id)
        {
            string insertSQL = @"UPDATE [Student] SET [Name] = @Name, [CPF] = @CPF, [BirthDate] = @BirthDate WHERE [Id] = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(insertSQL, new { Name=student.Name, CPF=student.CPF, BirthDate=student.BirthDate, Id = id });
            }
        }

        public int Delete(Student student, int id)
        {
            string insertSQL = @"DELETE FROM [Student] WHERE [Id] = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(insertSQL, new { Id=id });
            }
        }

        public IEnumerable<Student> Get()
        {
            string selectSQL = @"SELECT [Id], [Name], [CPF], [BirthDate] FROM [Student]";
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Student>(selectSQL);
            }
        }

        public IEnumerable<Student> GetById(int id)
        {
            string selectSQL = @"SELECT [Id], [Name], [CPF], [BirthDate] FROM [Student] WHERE [Id] = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Student>(selectSQL, new { Id = id });
            }
        }
    }
}
