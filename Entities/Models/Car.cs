using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Model { get; set; }

        [Required]
        [MaxLength(128)]
        public string Brand { get; set; }

        [Required]
        public DateTime ManufacturedYear { get; set; }

        [Required]
        public DateTime ManufacturedMonth { get; set; }

        [Required]
        [MaxLength(10)]
        public string RegistrationPlate { get; set; }

        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }

        public ICollection<ClientCar> ClientCars { get; set; }
    }
}
