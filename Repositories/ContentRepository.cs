﻿using Dapper;
using DapperNotes.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperNotes.DataAccess;
using System.Reflection.Metadata;

namespace DapperNotes.Repositories
{
    public class ContentRepository : IRepository<Content>
    {
        private readonly string _connectionString;
        private readonly SqlDataAccess _dataAccess;
        public ContentRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dataAccess = new SqlDataAccess();
        }

        public int Add(Content content)
        {
            string query = "spAddContent";
            return _dataAccess.SaveData(query, new { Semester = content.Semester }, _connectionString);
        }

        public int Update(Content content, int id)
        {
            string query = "spUpdateContent";
            return _dataAccess.SaveData(query, new { Semester = content.Semester, Id = id }, _connectionString);
        }

        public int Delete(int id)
        {
            string query = "spDeleteContent";
            return _dataAccess.SaveData(query, new { Id = id }, _connectionString);
        }

        public IEnumerable<Content> Get()
        {
            string query = "SELECT * FROM [vwGetContents]";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Content>(query);
            }
        }

        public IEnumerable<Content> GetById(int id)
        {
            string query = "SELECT * FROM [vwGetContents] WHERE [Id]=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<Content>(query, new { Id = id });
            }
        }
    }
}
