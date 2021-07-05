using Microsoft.EntityFrameworkCore;
using OE.Data;
using System.Collections.Generic;
using System.Linq;

namespace OE.Repo
{
    public class ActorsRepo<T> : IActorsRepo<T> where T : Actors
    {
        private readonly OurEduMediaContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public ActorsRepo(OurEduMediaContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
    }
}
