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
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Client> GetAll()
        {
            return _context.Clients;
        }

        public Client Get(int id)
        {
            return _context.Clients.Find(id);
        }

        public Client SingleOrDefault(Func<Client, bool> predicate)
        {
            return _context.Clients.FirstOrDefault(predicate);
        }

        public IQueryable<Client> Find(Expression<Func<Client, bool>> predicate)
        {
            return _context.Clients.Where(predicate);
        }


        public IEnumerable<Client> Find(Func<Client, bool> predicate)
        {
            return _context.Clients.Where(predicate).ToList();
        }

        public void Create(Client item)
        {
            _context.Clients.Add(item);
            _context.SaveChanges();
        }

        public void Update(Client item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            Client client = _context.Clients.Find(id);
            if (client != null)
                _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public Client FirstOrDefault(Func<Client, bool> predicate)
        {
            return _context.Clients.FirstOrDefault(predicate);
        }

        public IQueryable<Client> Contains(string predicate)
        {
            return
                _context.Clients
                    .Where(t => t.LastName.Contains(predicate));
        }
    }
}
