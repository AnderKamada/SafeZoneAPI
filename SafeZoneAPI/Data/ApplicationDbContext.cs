using Microsoft.EntityFrameworkCore;
using SafeZoneAPI.Models;

namespace SafeZoneAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegiaoRisco> RegioesRisco { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Abrigo> Abrigos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegiaoRisco>()
                .HasMany(r => r.Alertas)
                .WithOne(a => a.RegiaoRisco!)
                .HasForeignKey(a => a.RegiaoRiscoId);
        }
    }
}
