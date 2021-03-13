using ProjectApp.Models;
using System.Collections.Generic;

namespace ProjectApp.Services
{
    public interface ICarService
    {
        List<Car> GetCars();
        Car GetCar(int id);
        void AddCar(Car car);
        void DeleteCar(int id);
        void UpdateCar(Car car);
    }
}
