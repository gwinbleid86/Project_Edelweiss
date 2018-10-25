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
    public class TariffRepository: IRepository<Tariff>
    {
        private ApplicationDbContext _context;

        public TariffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Tariff> GetAll()
        {
            return _context.Tariffs.Include(t => t.Country)
                .Include(t => t.Agent)
                .Include(t => t.Currency)
                .GroupJoin(_context.Ranges, itemA => itemA.Range.Id, itemB => itemB.Id,
                    (itemA, outer) => new { itemA, outer })
                .SelectMany(@t1 => @t1.outer.DefaultIfEmpty(), (@t1, itemO) => new { @t1.itemA, itemO })
                .Select(x => new Tariff
                {
                    Id = x.itemA.Id,
                    StartTime = x.itemA.StartTime,
                    Agent = x.itemA.Agent,
                    Country = x.itemA.Country,
                    RangeId = x.itemO.Id,
                    Range = x.itemO,
                    Currency = x.itemA.Currency,
                    CommissionType = x.itemA.CommissionType,
                    Value = x.itemA.Value
                });
        }

        public Tariff Get(int id)
        {
            return _context.Tariffs
                .Include(t => t.Country)
                .Include(t => t.Agent)
                .Include(t => t.Currency).FirstOrDefault(t => t.Id == id);
                ;
        }

        public Tariff SingleOrDefault(Func<Tariff, bool> predicate)
        {
            return _context.Tariffs.SingleOrDefault(predicate);
        }

        public IQueryable<Tariff> Find(Expression<Func<Tariff, bool>> predicate)
        {
            return _context.Tariffs.Where(predicate);
        }

        public void Create(Tariff item)
        {
            _context.Tariffs.Add(item);
        }

        public void Update(Tariff item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Tariff tariff = _context.Tariffs.Find(id);
            if (tariff != null)
                _context.Tariffs.Remove(tariff);
        }
    }
}
