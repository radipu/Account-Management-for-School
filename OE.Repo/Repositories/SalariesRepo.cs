
using Microsoft.EntityFrameworkCore;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Repo
{
    public class SalariesRepo<T> : ISalariesRepo<T> where T : Salaries
    {
        private readonly OurEduMediaContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public SalariesRepo(OurEduMediaContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public Int64 GetLastId()
        {
            Int64 lastId = GetAll().Count() == 0 ? 0 : GetAll().Last().Id;
            return lastId;
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(Int64 id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

       
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is not save");
            }
            entity.Id = GetLastId() + 1;
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is not update");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }
       
    }
}
