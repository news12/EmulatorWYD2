using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class DonateGameMap : IEntityTypeConfiguration<DonateGame>
    {
        public void Configure(EntityTypeBuilder<DonateGame> builder)
        {
            builder.ToTable("send_donate_game");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Game_Id)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(x => x.User_Id)
              .IsRequired()
              .HasColumnType("bigint");

            builder.Property(x => x.Donate)
              .IsRequired()
              .HasColumnType("bigint");

            builder.Property(x => x.Status)
             .HasColumnType("smallint")
             .HasDefaultValue(0);

            builder.Property(x => x.Created_At)
             .IsRequired()
             .HasColumnType("timestamp");


        }
    }
}