using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.DataAccess
{
    public interface ISqlDataAccess
    {
        IEnumerable<T> GetData<T, P>(string procedureName, P parameters, string connectionString);
        int SaveData<T>(string procedureName, T parameters, string connectionString);
    }
}
