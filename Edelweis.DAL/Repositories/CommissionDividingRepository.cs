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
    public class CommissionDividingRepository : ICommissionsDividingRepository
    {
        private ApplicationDbContext _context;

        public CommissionDividingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<CommissionDividing> GetAll()
        {
            return _context.CommissionDividing;
        }

        public CommissionDividing Get(int id)
        {
            return _context.CommissionDividing.Find(id);
        }

        public CommissionDividing SingleOrDefault(Func<CommissionDividing, bool> predicate)
        {
            return _context.CommissionDividing.SingleOrDefault(predicate);
        }

        public IQueryable<CommissionDividing> Find(Expression<Func<CommissionDividing, bool>> predicate)
        {
            return _context.CommissionDividing.Where(predicate);
        }

        public void Create(CommissionDividing item)
        {
            _context.CommissionDividing.Add(item);
        }

        public void Update(CommissionDividing item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CommissionDividing commission = _context.CommissionDividing.Find(id);
            if (commission != null)
                _context.CommissionDividing.Remove(commission);
        }

        public CommissionDividing FirstOrDefault()
        {
            return _context.CommissionDividing.FirstOrDefault();
        }
    }
}
