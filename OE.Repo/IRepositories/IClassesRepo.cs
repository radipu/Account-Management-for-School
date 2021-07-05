using System.Collections.Generic;
using OE.Data;

namespace OE.Repo
{
    public interface IClassesRepo<T> where T : BaseEntity
    {
        #region "Get methods"
        T Get(long id);
        long GetLastId();
        IEnumerable<T> GetAll();
        #endregion "Get methods"

        #region "Insert update and delete methods"
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        #endregion "Insert update and delete methods"
    }
}
