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
    public class AgentRepository : IAgentRepository
    {
        private ApplicationDbContext _context;

        public AgentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Agent> GetAll()
        {
            return _context.Agents.Include(a => a.User);
        }

        public Agent Get(int id)
        {
            return _context.Agents
                .Include(a => a.Country)
                .Include(a => a.ParentAgent)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent SingleOrDefault(Func<Agent, bool> predicate)
        {
            return _context.Agents.Include(a => a.User).SingleOrDefault(predicate);
        }

        public IQueryable<Agent> Find(Expression<Func<Agent, bool>> predicate)
        {
            return _context.Agents.Include(a => a.User).Where(predicate);
        }

        public IEnumerable<Agent> Find(Func<Agent, bool> predicate)
        {
            return _context.Agents.Where(predicate);
        }

        public void Create(Agent item)
        {
            _context.Agents.Add(item);
        }

        public void Update(Agent item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Agent agent = _context.Agents.Find(id);
            if (agent != null)
                _context.Agents.Remove(agent);
        }
        public Agent SingleOrDefaultAsNoTracking(Func<Agent, bool> predicate)
        {
            return _context.Agents.AsNoTracking().SingleOrDefault(predicate);
        }

        //public void Block(string agentName)
        //{
        //    Agent agent = _context.Agents.SingleOrDefault(a=>a.Name==agentName);
        //    if (agent != null)

        //        _context.Agents.Update(agent);
        //    _context.SaveChanges();
        //}
    }
}
