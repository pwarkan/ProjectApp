using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ClientCar
    {
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public Client Client { get; set; }
    }
}