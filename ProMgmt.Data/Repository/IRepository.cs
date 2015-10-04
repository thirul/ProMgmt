using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMgmt.Data.Repository
{
    public interface IRepository<T>
    {
       
        IEnumerable<T> Get();
        void Insert(T Entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveAll();
    }
}
