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
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly string _connectionString;
        private readonly SqlDataAccess _dataAccess;
        public SubjectRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dataAccess = new SqlDataAccess();
        }

        public int Add(Subject subject)
        {
            string query = "spAddSubject";
            return _dataAccess.SaveData(query, new
            {
                Name = subject.Name,
                Description = subject.Description,
                SubjectTotalHours = subject.SubjectTotalHours
            }, _connectionString);
        }

        public int Update(Subject subject, int id)
        {
            string query = "spUpdateSubject";
            return _dataAccess.SaveData(query, new
            {
                Name = subject.Name,
                Description = subject.Description,
                SubjectTotalHours = subject.SubjectTotalHours,
                Id = id
            }, _connectionString);
        }

        public int Delete(int id)
        {
            string query = "spDeleteSubject";
            return _dataAccess.SaveData(query, new { Id = id }, _connectionString);
        }

        public IEnumerable<Subject> Get()
        {
            string query = "SELECT * FROM [vwGetSubjects]";
            return _dataAccess.GetData<Subject, dynamic>(query, new { }, _connectionString);
        }

        public IEnumerable<Subject> GetById(int id)
        {
            string query = "SELECT * FROM [vwGetSubjects] WHERE [Id]=@Id";
            return _dataAccess.GetData<Subject, dynamic>(query, new { Id = id }, _connectionString);
        }
    }
}
