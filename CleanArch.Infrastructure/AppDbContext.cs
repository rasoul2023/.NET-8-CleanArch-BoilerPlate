using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Models;

namespace CleanArch.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<ListItemValue> ListItemValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            switch (Settings.Default.DbType) {
                case "Postgresql":
                    optionsBuilder.UseNpgsql($"Host={Settings.Default.dbAddress};Database={Settings.Default.dbName};Username={Settings.Default.dbUser};Password={Settings.Default.dbPass}");
                    break;
                case "MsSQL": 
                    break;
                case "MariaDb":
                    break;  
            } 

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ListItem>()
                .HasMany(li => li.Values)
                .WithOne(lv => lv.ListItem)
                .HasForeignKey(lv => lv.ListItemId);
        }
    }
}
