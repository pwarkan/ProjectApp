using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ClientCarConfiguration : IEntityTypeConfiguration<ClientCar>
    {
        public void Configure(EntityTypeBuilder<ClientCar> builder)
        {
            builder.HasData
             (
                 new ClientCar
                 {
                     ClientId = 1,
                     CarId = 4
                 },
                 new ClientCar
                 {
                     ClientId = 2,
                     CarId = 3
                 },
                 new ClientCar
                 {
                     ClientId = 3,
                     CarId = 5
                 },
                 new ClientCar
                 {
                     ClientId = 4,
                     CarId = 2
                 },
                 new ClientCar
                 {
                     ClientId = 5,
                     CarId = 1
                 }
             );
        }
    }
}
