using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Models;
using Dapper;
using DapperNotes.DataAccess;

namespace DapperNotes.Repositories
{
    public class ProfessorRepository : IRepository<Professor>
    {
        private readonly string _connectionString;
        private readonly SqlDataAccess _dataAccess;
        public ProfessorRepository(string connectionString) 
        {
            _connectionString = connectionString;
            _dataAccess = new SqlDataAccess();
        }

        public int Add(Professor professor)
        {
            string query = "[spAddProfessor]";
            return _dataAccess.SaveData(query, new
            {
                Name = professor.Name,
                ValuePerHour = professor.ValuePerHour,
                AcademicDegree = professor.AcademicDegree
            }, _connectionString);
        }

        public int Update(Professor professor, int id)
        {
            string query = "[spUpdateProfessor]";
            return _dataAccess.SaveData(query, new
            {
                Name = professor.Name,
                ValuePerHour = professor.ValuePerHour,
                AcademicDegree = professor.AcademicDegree,
                Id = id
            }, _connectionString);
        }

        public int Delete(int id)
        {
            string query = "[spDeleteProfessor]";
            return _dataAccess.SaveData(query, new { Id = id }, _connectionString);
        }

        public IEnumerable<Professor> Get()
        {
            string query = "SELECT * FROM [vwGetProfessors]";
            return _dataAccess.GetData<Professor, dynamic>(query, new { }, _connectionString);
        }

        public IEnumerable<Professor> GetById(int id)
        {
            string query = "SELECT * FROM [vwGetProfessors] WHERE [Id] = @Id";
            return _dataAccess.GetData<Professor, dynamic>(query, new { Id = id }, _connectionString);
        }
    }
}
