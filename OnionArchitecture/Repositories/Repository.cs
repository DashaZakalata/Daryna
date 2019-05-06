using DAL;
using DomainCore.Interfaces;
using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCore;

namespace Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private ShopContext context;
        private DbSet<T> dbSet;

        public Repository(ShopContext context = null)
        {
            this.context = context ?? new ShopContext();
            dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Remove(int id)
        {
            var entity = Get(id);

            dbSet.Remove(entity);
        }
    }
}
