using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.Models;
using Dapper;

namespace DapperNotes.Repositories
{
    public class ProfessorRepository
    {
        private string _connectionString;
        public ProfessorRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public int Add(Professor professor)
        {
            string query = @"INSERT INTO [Professor] VALUES(@Name, @ValuePerHour, @AcademicDegree)";
            using(SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, 
                    new { 
                        Name=professor.Name, 
                        ValuePerHour=professor.ValuePerHour,
                        AcademicDegree=professor.AcademicDegree
                    });
            } 
        }

        public int Update(Professor professor, int id)
        {
            string query = @"UPDATE [Professor] SET [Name]=@Name, [ValuerPerHour]=@ValuePerHour, [AcademicDegree]=@AcademicDegree WHERE [Id]=@Id";
            using(SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, 
                    new { 
                        Name=professor.Name,
                        ValuePerHour = professor.ValuePerHour,
                        AcademicDegree = professor.AcademicDegree,
                        Id=id
                    });
            }
        }

        public int Delete(int id)
        {
            string query = @"DELETE FROM [Professor] WHERE [Id]=@Id";
            using(SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, new { Id=id });
            }
        }

        public IEnumerable<Professor> Get()
        {
            string query = @"SELECT [Id], [Name], [ValuerPerHour], [AcademicDegree] FROM [Professor]";
            using(SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Professor>(query);
            }
        }

        public IEnumerable<Professor> GetById(int id)
        {
            string query = @"SELECT [Id], [Name], [ValuerPerHour], [AcademicDegree] FROM [Professor] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Professor>(query, new { Id=id });
            }
        }
    }
}
