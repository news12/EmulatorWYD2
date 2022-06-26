
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
            modelBuilder.ApplyConfiguration(new DonateGameMap());
            modelBuilder.ApplyConfiguration(new PassGameMap());
            modelBuilder.ApplyConfiguration(new CharacterMap());
            modelBuilder.ApplyConfiguration(new BotDonateMap());

            modelBuilder.Entity<Account>().Ignore(d => d.Donates);

        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<DonateGame>? Donates { get; set; }
        public DbSet<PassGame>? Passwords { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<BotDonate> BotDonates { get; set; }


    }


}