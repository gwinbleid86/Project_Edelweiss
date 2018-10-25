using System;
using System.Collections.Generic;
using Edelweiss.DAL.Entities;

namespace Edelweiss.DAL.Interfaces
{
    public interface ISysTransactionRepository : IRepository<SysTransaction>
    {
        SysTransaction GetByField(Func<SysTransaction, bool> predicate);
        SysTransaction SingleIncludeAgents(int id);
        IEnumerable<SysTransaction> GetTransactionByCountry(string predicate);
    }
}
