
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Repo
{
    public interface IDesignationsRepo<T> where T : BaseEntity
    {
        #region "Get methods"
        IEnumerable<T> GetAll();
        Int64 GetLastId();
        T Get(long id);
        #endregion "Get methods"

        #region "Insert Update Delete"
        void Insert(T entity);
       
        void Update(T entity);      

      
        void Delete(T entity);
        void Remove(T entity);
       
        #endregion "Insert Update Delete"

    }
}