using System;
using System.Linq;
using System.Linq.Expressions;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edelweiss.DAL.Repositories
{
    public class CellPhoneMaskRepository : IRepository<CellPhoneMask>
    {
        private ApplicationDbContext _context;

        public CellPhoneMaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CellPhoneMask> GetAll()
        {
            return _context.CellPhoneMasks.Include(c => c.Country);
        }

        public CellPhoneMask Get(int id)
        {
            return _context.CellPhoneMasks
                .Include(c => c.Country)
                .SingleOrDefault(c => c.Id == id);
        }

        public CellPhoneMask SingleOrDefault(Func<CellPhoneMask, bool> predicate)
        {
            return _context.CellPhoneMasks.SingleOrDefault(predicate);
        }

        public IQueryable<CellPhoneMask> Find(Expression<Func<CellPhoneMask, bool>> predicate)
        {
            return _context.CellPhoneMasks.Where(predicate);
        }

        public void Create(CellPhoneMask item)
        {
            _context.CellPhoneMasks.Add(item);
        }

        public void Update(CellPhoneMask item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var cellPoneMask = _context.CellPhoneMasks.Find(id);
            if (cellPoneMask != null) _context.CellPhoneMasks.Remove(cellPoneMask);
        }
    }
}
