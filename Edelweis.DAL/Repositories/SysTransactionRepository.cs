using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edelweiss.DAL.Repositories
{
    public class SysTransactionRepository : ISysTransactionRepository
    {
        private ApplicationDbContext _context;

        public SysTransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<SysTransaction> GetAll()
        {
            return _context.Transactions
                .Include(t => t.AgentTo)
                .Include(t => t.AgentFrom);
        }

        public SysTransaction Get(int id)
        {
            return _context.Transactions.Find(id);
        }

        public SysTransaction SingleOrDefault(Func<SysTransaction, bool> predicate)
        {
            return _context.Transactions.SingleOrDefault(predicate);
        }

        public IQueryable<SysTransaction> Find(Expression<Func<SysTransaction, bool>> predicate)
        {
            return _context.Transactions
                .Include(t => t.AgentTo)
                .Include(t => t.AgentFrom)
                .Include(t => t.ClientFrom)
                .Include(t => t.ClientTo)
                .Include(t => t.Country)
                .Include(t => t.Currency)
                .Include(t => t.Commissions)
                .ThenInclude(c => c.Agent)
                .Where(predicate);
        }
        
        public void Create(SysTransaction item)
        {
            _context.Transactions.Add(item);
        }

        public void Update(SysTransaction item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            //SysTransaction transaction = _context.Transactions
            //    .Include(t => t.ClientFrom)
            //    .Include(t => t.ClientTo)
            //    .FirstOrDefault(t => t.Id == item.Id);
            //transaction = item;
        }

        public void Delete(int id)
        {
            SysTransaction transaction = _context.Transactions.Find(id);
            if (transaction != null)
                _context.Transactions.Remove(transaction);
        }

        public SysTransaction GetByField(Func<SysTransaction, bool> predicate)
        {
            return _context.Transactions.FirstOrDefault(predicate);
        }

        public SysTransaction SingleIncludeAgents(int id)
        {
            return _context.Transactions
                .Include(t => t.AgentFrom)
                .Include(t => t.AgentTo)
                .Include(t => t.Country)
                .Include(t => t.Currency)
                .Include(t => t.Commissions)
                .Include(t => t.ClientFrom)
                .Include(t => t.ClientTo)
                .SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<SysTransaction> GetTransactionByCountry(string predicate)
        {
            //return _context.Transactions.Include(t => t.AgentTo.Country.Name == predicate)
            //    .Include(t => t.AgentFrom.Country.Name == predicate);
            return 
           _context.Transactions.Where(t => t.AgentFrom.Country.Name == predicate || t.AgentTo.Country.Name == predicate);
        }
    }
}
