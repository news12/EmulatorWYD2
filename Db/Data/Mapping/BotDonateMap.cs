using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class BotDonateMap : IEntityTypeConfiguration<BotDonate>
    {
        public void Configure(EntityTypeBuilder<BotDonate> builder)
        {
            builder.ToTable("bot_donate");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.User_Id)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(x => x.Admin_Id)
              .IsRequired()
              .HasColumnType("bigint");

            builder.Property(x => x.Name)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(20);

            builder.Property(x => x.Token)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(20);

            builder.Property(x => x.Value)
            .HasDefaultValue(0)
           .HasColumnType("smallint")
           .HasDefaultValue(0);


            builder.Property(x => x.Status)
             .HasColumnType("smallint")
             .HasDefaultValue(0);


        }
    }
}