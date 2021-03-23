using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CarForUpdateDTO
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime ManufacturedYear { get; set; }
        public DateTime ManufacturedMonth { get; set; }
        public string RegistrationPlate { get; set; }
        public string VIN { get; set; }
    }
}
