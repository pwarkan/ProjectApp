using ProjectApp.Models;
using System.Collections.Generic;

namespace ProjectApp.Data
{
    public static class CarMock
    {
       public static List<Car> GetItems()
        {
            var cars = new List<Car>
            {
                new Car { Id = 1, Name = "MX-5", Brand = "Mazda", Price = 26830 },
                new Car { Id = 2, Name = "911", Brand = "Porsche", Price = 99200 },
                new Car { Id = 3, Name = "Alpine A110", Brand = "Renault", Price = 75000 },
                new Car { Id = 4, Name = "GT-R Nismo", Brand = "Nissan", Price = 210740},
                new Car { Id = 5, Name = "GR Supra", Brand = "Toyota", Price = 44673 },
                new Car { Id = 6, Name = "Mustang", Brand = "Ford", Price = 36120 },
                new Car { Id = 7, Name = "570S", Brand = "McLaren", Price = 191100 }
            };
            return cars;
        }
    }
}
