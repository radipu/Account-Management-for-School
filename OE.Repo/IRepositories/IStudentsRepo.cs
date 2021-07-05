using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Repo
{
    public interface IStudentsRepo<T> where T : BaseEntity
    {
        #region "Get methods"
        IEnumerable<T> GetAll();
        T Get(long id);      
        Int64 GetLastId();
        #endregion "Get methods"

       
        #region "Insert update and delete methods"
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        #endregion "Insert update and delete methods"  
        
    }
}