using Edelweiss.DAL.Configuration;
using Edelweiss.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Edelweiss.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<CommissionDividing> CommissionDividing { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Range> Ranges { get; set; }
        public DbSet<SysTransaction> Transactions { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<CellPhoneMask> CellPhoneMasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(string connectionString) : this(GetOptions(connectionString))
        {
        }

        private static DbContextOptions<ApplicationDbContext> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ApplicationDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgentConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

    }
}
