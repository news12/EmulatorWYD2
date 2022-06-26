using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Data.Mapping
{
    public class CharacterBagMap : IEntityTypeConfiguration<CharacterBag>
    {
        public void Configure(EntityTypeBuilder<CharacterBag> builder)
        {
            builder.ToTable("CharacterBag");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Character);

        }
    }
}