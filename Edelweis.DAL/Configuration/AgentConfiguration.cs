using Edelweiss.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edelweiss.DAL.Configuration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {   
            builder.HasMany(a => a.SysTransactionsFrom)
                .WithOne(t => t.AgentFrom)
                .HasForeignKey(fk => fk.AgentFromId);

            builder.HasMany(a => a.SysTransactionsTo)
                .WithOne(t => t.AgentTo)
                .HasForeignKey(fk => fk.AgentToId);
        }
    }
}
