using System.Collections.Generic;
using OE.Data;

namespace OE.Repo
{
    public interface IUsersRepo<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long? id);
        long GetLastId();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
