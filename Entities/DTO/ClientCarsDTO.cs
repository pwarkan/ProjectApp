using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ClientCarsDTO
    {
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime ManufacturedYear { get; set; }
        public DateTime ManufacturedMonth { get; set; }
        public string RegistrationPlate { get; set; }
        public string VIN { get; set; }
    }
}
