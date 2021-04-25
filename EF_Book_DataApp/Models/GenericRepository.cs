using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFDatabaseContext context;
        public GenericRepository(EFDatabaseContext context) => this.context = context;

        public virtual T GetObject(long objectId) => context.Set<T>().Find(objectId);

        public virtual IEnumerable<T> GetAllObjects() => context.Set<T>();

        public virtual void CreateObject(T newObject)
        {
            context.Set<T>().Add(newObject);
            context.SaveChanges();
        }

        public virtual void UpdateObject(T changedObject)
        {
            context.Set<T>().Update(changedObject);
            context.SaveChanges();
        }

        public virtual void Delete(long objectId)
        {
            T thisObject = context.Set<T>().Find(objectId);
            context.Set<T>().Remove(thisObject);
            context.SaveChanges();
        }
    }
}
