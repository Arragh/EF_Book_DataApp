using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public interface IGenericRepository<T> where T : class
    {
        T GetObject(long objectId);
        IEnumerable<T> GetAllObjects();
        void CreateObject(T newObject);
        void UpdateObject(T changedObject);
        void Delete(long objectId);
    }
}
