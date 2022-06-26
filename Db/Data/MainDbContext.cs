
using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Db.Data.Mapping;


namespace Db.Data
{
    public class MainDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Config.ConfigLoad();
            optionsBuilder.UseMySql(Config.MysqlConnectionString, ServerVersion.AutoDetect(Config.MysqlConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());

            modelBuilder.Entity<Account>().Ignore(d => d.NumericFail);
            modelBuilder.Entity<Account>().Ignore(d => d.Character);
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Character>? Characters { get; set; }
        public DbSet<CharacterLastPosition>? CharacterLastPosition { get; set; }
        public DbSet<CharacterBag>? CharacterBag { get; set; }
        public DbSet<CharacterEquip>? CharacterEquip { get; set; }
        public DbSet<CharacterStatus>? CharacterStatus { get; set; }


    }


}