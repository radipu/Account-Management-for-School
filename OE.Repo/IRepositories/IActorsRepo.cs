using System.Collections.Generic;
using OE.Data;

namespace OE.Repo
{
    public interface IActorsRepo<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
    }
}
