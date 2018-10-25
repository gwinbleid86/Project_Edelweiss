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
    public class CommissionRepository : ICommissionRepository
    {
        private ApplicationDbContext _context;

        public CommissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Commission> GetAll()
        {
            return _context.Commissions;
        }

        public Commission Get(int id)
        {
            return _context.Commissions.Find(id);
        }

        public Commission SingleOrDefault(Func<Commission, bool> predicate)
        {
            return _context.Commissions.SingleOrDefault(predicate);
        }

        public IQueryable<Commission> Find(Expression<Func<Commission, bool>> predicate)
        {
            return _context.Commissions.Where(predicate);
        }

        public void Create(Commission item)
        {
            _context.Commissions.Add(item);
        }

        public void Update(Commission item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Commission commission = _context.Commissions.Find(id);
            if (commission != null)
                _context.Commissions.Remove(commission);
        }

        public Commission FirstOrDefault()
        {
            return _context.Commissions.FirstOrDefault();
        }
    }
}
