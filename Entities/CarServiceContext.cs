using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class CarServiceContext : DbContext
    {
        public CarServiceContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<ClientCar>(entity =>
            {
                entity.HasKey(k => new { k.ClientId, k.CarId });
                entity.HasIndex(i => i.ClientId).IsUnique();
                entity.HasIndex(i => i.CarId).IsUnique();
            });

            //делаем записи уникальными, так как VIN в реальном мире уникален и не бывает повторяющихся, тоже самое и с регистрационным номером машины
            modelBuilder.Entity<Car>(entity =>
             {
                 entity.HasIndex(i => i.VIN).IsUnique();
                 entity.HasIndex(i => i.RegistrationPlate).IsUnique();
             });

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new ClientCarConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ClientCar> ClientCars { get; set; }

    }
}
