using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Repositories
{
    public interface IRepository<T>
    {
        int Add(T obj);
        int Update(T obj, int id);
        int Delete(int id);
        IEnumerable<T> Get();
        IEnumerable<T> GetById(int id);
    }
}
