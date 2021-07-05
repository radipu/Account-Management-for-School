using OE.Data;
using System.Collections.Generic;

namespace OE.Repo
{
    public interface IGendersRepo<T> where T : BaseEntity
    {
        #region "Get methods"
        IEnumerable<T> GetAll();
        T Get(long id);
        #endregion "Get methods"      
    }
}