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
    public class ContentRepository
    {
        private string _connectionString;
        public ContentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(Content content)
        {
            string query = @"INSERT INTO [Content] VALUES(@Semester)";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        Semester = content.Semester
                    });
            }
        }

        public int Update(Content content, int id)
        {
            string query = @"UPDATE [Content] SET [Semester]=@Semester WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query,
                    new
                    {
                        Semester = content.Semester,
                        Id = id
                    });
            }
        }

        public int Delete(int id)
        {
            string query = @"DELETE FROM [Content] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(query, new { Id = id });
            }
        }

        public IEnumerable<Content> Get()
        {
            string query = @"SELECT [Id], [Semester] FROM [Content]";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Content>(query);
            }
        }

        public IEnumerable<Content> GetById(int id)
        {
            string query = @"SELECT [Id], [Semester] FROM [Content] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Content>(query, new { Id = id });
            }
        }
    }
}
