
using Microsoft.EntityFrameworkCore;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Repo
{
    public class GendersRepo<T> : IGendersRepo<T> where T : Genders
    {
        private readonly OurEduMediaContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public GendersRepo(OurEduMediaContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
    }
}
