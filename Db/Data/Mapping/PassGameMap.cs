using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class PassGameMap : IEntityTypeConfiguration<PassGame>
    {
        public void Configure(EntityTypeBuilder<PassGame> builder)
        {
            builder.ToTable("send_pass_game");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Game_Id)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(x => x.Password)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(20);

            builder.Property(x => x.Numeric)
             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(10);

            builder.Property(x => x.Status)
             .HasColumnType("smallint")
             .HasDefaultValue(0);


        }
    }
}