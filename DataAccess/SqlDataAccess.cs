using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public IEnumerable<T> GetData<T, P>(string procedureName, P parameters, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Query<T>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public int SaveData<T>(string procedureName, T parameters, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Execute(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
