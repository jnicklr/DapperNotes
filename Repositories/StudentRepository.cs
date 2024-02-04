using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using DapperNotes.DataAccess;

namespace DapperNotes.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly string _connectionString;
        private readonly SqlDataAccess _dataAccess;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dataAccess = new SqlDataAccess();
        }

        public int Add(Student student)
        {
            string query = "spAddStudent";
            return _dataAccess.SaveData(query, new { student.Name, student.CPF, student.BirthDate }, _connectionString);
        }

        public int Update(Student student, int id)
        {
            string query = "spUpdateStudent";
            return _dataAccess.SaveData(query, new { Name = student.Name, CPF = student.CPF, BirthDate = student.BirthDate, Id = id }, _connectionString);
        }

        public int Delete(int id)
        {
            string query = "spDeleteStudent";
            return _dataAccess.SaveData(query, new { Id = id }, _connectionString);
        }

        public IEnumerable<Student> Get()
        {
            string query = "SELECT * FROM [vwGetStudents]";
            return _dataAccess.GetData<Student, dynamic>(query, new{}, _connectionString);
        } 

        public IEnumerable<Student> GetById(int id)
        {
            string query = "SELECT * FROM [vwGetStudents] WHERE [Id] = @Id";
            return _dataAccess.GetData<Student, dynamic>(query, new { Id = id }, _connectionString);
        }
    }
}
