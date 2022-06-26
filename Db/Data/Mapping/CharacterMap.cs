using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class CharacterMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("game_characters");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.User_Id)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(x => x.Game_id)
              .IsRequired()
              .HasColumnType("bigint");

            builder.Property(x => x.UserName)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(20);

            builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(20);

            builder.Property(x => x.Fame)
            .HasDefaultValue(0)
           .HasColumnType("smallint");

            builder.Property(x => x.CapeInfo)
                .HasDefaultValue(0)
                .HasColumnType("smallint");

            builder.Property(x => x.GuildIndex)
                .HasDefaultValue(0)
                .HasColumnType("smallint");

            builder.Property(x => x.ClassInfo)
                .HasDefaultValue(4)
                .HasColumnType("smallint");

            builder.Property(x => x.Exp)
                .HasDefaultValue(0)
                .HasColumnType("bigint");

            builder.Property(x => x.Level)
               .HasDefaultValue(0)
               .HasColumnType("int");


            builder.Property(x => x.GuildMemberType)
               .HasDefaultValue(0)
               .HasColumnType("smallint");


            builder.Property(x => x.Evo)
               .HasDefaultValue(0)
               .HasColumnType("smallint");

            builder.Property(x => x.Status)
             .HasColumnType("smallint")
             .HasDefaultValue(0);


        }
    }
}