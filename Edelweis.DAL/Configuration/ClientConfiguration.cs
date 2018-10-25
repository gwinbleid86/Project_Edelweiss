using Edelweiss.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edelweiss.DAL.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasMany(c => c.SysTransactionsFrom)
                .WithOne(t => t.ClientFrom)
                .HasForeignKey(fk => fk.ClientFromId);

            builder.HasMany(c => c.SysTransactionsTo)
                .WithOne(t => t.ClientTo)
                .HasForeignKey(fk => fk.ClientToId);

        }
    }
}
