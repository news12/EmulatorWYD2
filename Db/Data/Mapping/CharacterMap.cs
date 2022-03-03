using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class CharacterMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired().HasColumnType("varchar")
                .HasMaxLength(50);

            builder.HasOne(x => x.Bag);
            builder.HasOne(x => x.LastPosition);
            builder.HasOne(x => x.Equip);
            builder.HasOne(x => x.Affect);
            builder.HasOne(x => x.CurrentStatus);

        }
    }
}