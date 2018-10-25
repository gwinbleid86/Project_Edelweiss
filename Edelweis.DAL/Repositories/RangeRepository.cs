using System;
using System.Linq;
using System.Linq.Expressions;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edelweiss.DAL.Repositories
{
    public class RangeRepository : IRepository<Range>
    {
        private ApplicationDbContext _context;

        public RangeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Range> GetAll()
        {
            return _context.Ranges;
        }

        public Range Get(int id)
        {
            return _context.Ranges.Find(id);
        }

        public Range SingleOrDefault(Func<Range, bool> predicate)
        {
            return _context.Ranges.SingleOrDefault(predicate);
        }

        public IQueryable<Range> Find(Expression<Func<Range, bool>> predicate)
        {
            return _context.Ranges.Where(predicate);
        }

        public void Create(Range item)
        {
            _context.Ranges.Add(item);
        }

        public void Update(Range item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Range range = _context.Ranges.Find(id);
            _context.Ranges.Remove(range);
        }
    }
}
