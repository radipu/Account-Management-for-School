using System;
using System.Linq;
using System.Collections.Generic;
using OE.Data;
using Microsoft.EntityFrameworkCore;

namespace OE.Repo
{
    public class UserAuthenticationsRepo<T> : IUserAuthenticationsRepo<T> where T : UserAuthentications
    {
        private readonly OurEduMediaContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public UserAuthenticationsRepo(OurEduMediaContext context)
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
        public long GetLastId()
        {
            long lastId = GetAll().Count() == 0 ? 0 : GetAll().Last().Id;
            return lastId;
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
                throw new ArgumentNullException("Please provide all information correctly");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Delete is not successful");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
