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
    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Country> GetAll()
        {
            return _context.Countries;
        }

        public Country Get(int id)
        {
            return _context.Countries.Find(id);
        }

        public Country GetDetached(int id)
        {
            var entity = _context.Countries.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public Country SingleOrDefault(Func<Country, bool> predicate)
        {
            return _context.Countries.SingleOrDefault(predicate);
        }

        public IQueryable<Country> Find(Expression<Func<Country, bool>> predicate)
        {
            return _context.Countries.Where(predicate);
        }

        public void Create(Country item)
        {
            _context.Countries.Add(item);
        }

        public void Update(Country item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country != null) _context.Countries.Remove(country);
        }
    }
}
