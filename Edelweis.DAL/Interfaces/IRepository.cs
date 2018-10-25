using System;
using System.Linq;
using System.Linq.Expressions;

namespace Edelweiss.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        T SingleOrDefault(Func<T, bool> predicate);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
