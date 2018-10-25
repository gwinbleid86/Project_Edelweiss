using System;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;

namespace Edelweiss.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public EFUnitOfWork(ApplicationDbContext context,
            IAgentRepository agentRepository, 
            ICountryRepository countryRepository,
            ICommissionRepository commissions,
            ICommissionsDividingRepository commissionsDividing,
            IRepository<Currency> currenciesRepository,
            IRepository<CellPhoneMask> cellPhoneMaskRepository, 
            IClientRepository clientRepository,
            IRepository<SysTransaction> transactions,
            IRepository<Tariff> tariffs,
            IRepository<Range> ranges,
            ISysTransactionRepository transactionsAC,
            IUserRepository users)
        {
            _context = context;
            Agents = agentRepository;
            Countries = countryRepository;
            Commissions = commissions;
            CommissionDividing = commissionsDividing;
            Currencies = currenciesRepository;
            CellPhoneMasks = cellPhoneMaskRepository;
            Clients = clientRepository;
            Transactions = transactions;
            Tariffs = tariffs;
            Ranges = ranges;
            TransactionsAC = transactionsAC;
            Users = users;
        }

        public IAgentRepository Agents { get; }
        public IClientRepository Clients { get; }
        public ICountryRepository Countries { get; }
        public ICommissionRepository Commissions { get; }
        public IRepository<Currency> Currencies { get; }
        public ICommissionsDividingRepository CommissionDividing { get; }
        public IRepository<CellPhoneMask> CellPhoneMasks { get; }
        public IRepository<Range> Ranges { get; }
        public IRepository<Tariff> Tariffs { get; }
        public IRepository<SysTransaction> Transactions { get; }
        public ISysTransactionRepository TransactionsAC { get; }
        public IUserRepository Users { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
