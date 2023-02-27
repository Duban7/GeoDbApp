using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Geo.DAL.context
{
    public class GeoDBContext : DbContext
    {
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<PlannedExpedition> PlannedExpeditions { get; set; }
        public DbSet<Geologist> Geologists { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DUBAN;Database=GeoDB;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expedition>()
                .HasOne(expedidtion => expedidtion.Route)
                .WithMany(route => route.Expeditions)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlannedExpedition>()
                .HasOne(expedidtion => expedidtion.Route)
                .WithMany(route => route.PlannedExpeditions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
