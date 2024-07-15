using Microsoft.EntityFrameworkCore;
using AdSetIntegrador.Data.Entities;

namespace AdSetIntegrador.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPhoto> CarPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Fotos)
                .WithOne(f => f.Car)
                .HasForeignKey(f => f.CarId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
