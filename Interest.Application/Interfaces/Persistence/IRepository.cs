using Interest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Interfaces.Persistence
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T Get(int id);
        IQueryable<T> All();

        void Save();

    }
}
