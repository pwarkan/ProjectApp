using Entities;
using Entities.Models;
using References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    //Репозиторий машин
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(CarServiceContext carServiceContext)
            : base(carServiceContext)
        {
        }

        public void CreateCar(Car car) => Create(car);
        public void DeleteCar(Car car) => Delete(car);
        public void UpdateCar(Car car) => Update(car);

        public IEnumerable<Car> GetAllCars(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();

        public Car GetCar(int carId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(carId), trackChanges)
            .FirstOrDefault();
    }
}
