using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edelweiss.DAL.Entities;

namespace Edelweiss.DAL.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Client FirstOrDefault(Func<Client, bool> predicate);
        IQueryable<Client> Contains(string predicate);
    }
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetDetached(int id);
    }
    public interface IAgentRepository : IRepository<Agent>
    {
        Agent SingleOrDefaultAsNoTracking(Func<Agent, bool> predicate);
    }
}
