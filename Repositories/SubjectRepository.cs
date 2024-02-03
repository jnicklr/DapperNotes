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
    public class SubjectRepository
    {
        private string _connectionString;
        public SubjectRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Subject subject)
        {
            string query = @"INSERT INTO [Subject] VALUES(@Name, @Description, @SubjectTotalHours)";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        Name = subject.Name,
                        Description = subject.Description,
                        SubjectTotalHours = subject.SubjectTotalHours
                    });
            }
        }

        public int Update(Subject subject, int id)
        {
            string query = @"UPDATE [Subject] SET [Name]=@Name, [Description]=@Description, [SubjectTotalHours]=@SubjectTotalHours WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        Name = subject.Name,
                        Description = subject.Description,
                        SubjectTotalHours = subject.SubjectTotalHours,
                        Id = id
                    });
            }
        }

        public int Delete(int id)
        {
            string query = @"DELETE FROM [Subject] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, new { Id = id });
            }
        }

        public IEnumerable<Subject> Get()
        {
            string query = @"SELECT [Id], [Name], [Description], [SubjectTotalHours] FROM [Subject]";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Subject>(query);
            }
        }

        public IEnumerable<Subject> GetById(int id)
        {
            string query = @"SELECT [Id], [Name], [Description], [SubjectTotalHours] FROM [Subject] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Subject>(query, new { Id = id });
            }
        }
    }
}
