using Interest.Application.Interfaces.Persistence;
using Interest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Persistence.Shared
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly InterestDbContext context;
        public Repository(InterestDbContext dbContext)
        {
            context = dbContext;
        }
        public T Get(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        IQueryable<T> IRepository<T>.All()
        {
            return context.Set<T>();
        }
    }
}
