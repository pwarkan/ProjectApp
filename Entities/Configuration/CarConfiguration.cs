using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
             builder.HasData
             (
                 new Car
                 {
                     Id = 1,
                     Model = "Phantom",
                     Brand = "Rolls-Royce",
                     ManufacturedYear = new System.DateTime(2008, 01, 01),
                     ManufacturedMonth = new System.DateTime(1970,01,01),
                     VIN = "JN1BJ0HP5FM865848",
                     RegistrationPlate = "L-255N"
                 }, 
                 new Car
                 {
                     Id = 2,
                     Model = "NX",
                     Brand = "Nissan",
                     ManufacturedYear = new System.DateTime(1992, 01, 01),
                     ManufacturedMonth = new System.DateTime(1970,02,01),
                     VIN = "WAUSF98E06A178440",
                     RegistrationPlate = "M-564N"
                 }, 
                 new Car
                 {
                     Id = 3,
                     Model = "DeVille",
                     Brand = "Cadillac",
                     ManufacturedYear = new System.DateTime(2000, 01, 01),
                     ManufacturedMonth = new System.DateTime(1970,08,01),
                     VIN = "3C6TD4DT1CG744582",
                     RegistrationPlate = "M-712W"
                 }, 
                 new Car
                 {
                     Id = 4,
                     Model = "Odyssey",
                     Brand = "Honda",
                     ManufacturedYear = new System.DateTime(2011, 01, 01),
                     ManufacturedMonth = new System.DateTime(1970,07,01),
                     VIN = "WAUSH98E27A557225",
                     RegistrationPlate = "E-8986"
                 },
                 new Car
                 {
                     Id = 5,
                     Model = "Caravan",
                     Brand = "Dodge",
                     ManufacturedYear = new System.DateTime(1995, 01, 01),
                     ManufacturedMonth = new System.DateTime(1970, 06, 01),
                     VIN = "4JGCB2FB9AA509989",
                     RegistrationPlate = "E-968W"
                 }
             );
        }
    }
}
