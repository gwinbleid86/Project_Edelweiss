using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edelweiss.DAL.Repositories
{
    public class CurrencyRepository : IRepository<Currency>
    {
        private ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Currency> GetAll()
        {
            return _context.Currencies;
        }

        public Currency Get(int id)
        {
            return _context.Currencies.Find(id);
        }

        public Currency SingleOrDefault(Func<Currency, bool> predicate)
        {
            return _context.Currencies.SingleOrDefault(predicate);
        }

        public IQueryable<Currency> Find(Expression<Func<Currency, bool>> predicate)
        {
            return _context.Currencies.Where(predicate);
        }

        public void Create(Currency item)
        {
            _context.Currencies.Add(item);
        }

        public void Update(Currency item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var country = _context.Currencies.Find(id);
            if (country != null) _context.Currencies.Remove(country);
        }
    }
}
