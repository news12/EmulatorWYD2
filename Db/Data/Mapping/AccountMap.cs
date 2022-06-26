using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("game_accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired().HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Status)
             .HasColumnType("smallint")
             .HasDefaultValue(0);

            builder.HasMany(x => x.Donates);


        }
    }
}
