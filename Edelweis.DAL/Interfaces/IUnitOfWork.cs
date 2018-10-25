using System;
using Edelweiss.DAL.Entities;

namespace Edelweiss.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAgentRepository Agents { get; }
        IClientRepository Clients { get; }
        ICountryRepository Countries { get; }
        ICommissionRepository Commissions { get; }
        IRepository<Currency> Currencies { get; }
        ICommissionsDividingRepository CommissionDividing { get; }
        IRepository<CellPhoneMask> CellPhoneMasks { get; }
        IRepository<Range> Ranges { get; }
        IRepository<Tariff> Tariffs { get; }
        ISysTransactionRepository TransactionsAC { get; }
        IUserRepository Users { get; }
        void Save();
    }
}
