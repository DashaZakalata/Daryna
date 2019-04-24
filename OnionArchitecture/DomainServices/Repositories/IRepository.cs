using DomainCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Repositories
{
    public interface IRepository<T>
        where T : class,IEntity
    {
        void Add(T entity);
        void Remove(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
