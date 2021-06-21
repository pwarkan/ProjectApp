using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars(bool trackChanges);
        Car GetCar(int carId, bool trackChanges);
        void CreateCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);
    }
}
