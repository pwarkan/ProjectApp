using ProjectApp.Data;
using ProjectApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectApp.Services
{
    //���������� ���������� ICarService
    public class CarService : ICarService
    {
        private List<Car> _cars;

        public CarService()
        {
            _cars = CarMock.GetItems();
        }

        /// <summary>
        /// ���������� ������ � ������
        /// </summary>
        /// <param name="car"></param>
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        /// <summary>
        /// �������� ����������� ������ �� � id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCar(int id)
        {
            var item =_cars.Where(x => x.Id == id).FirstOrDefault();
            _cars.Remove(item);
        }

        /// <summary>
        /// ��������� ����������� ������ �� � id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            return _cars.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// ��������� ������ ���� �����
        /// </summary>
        /// <returns></returns>
        public List<Car> GetCars()
        {
            return _cars;
        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        /// <param name="car"></param>
        public void UpdateCar(Car car)
        {
            var index = _cars.FindIndex(x => x.Id == car.Id);
            _cars[index].Name = car.Name;
            _cars[index].Brand = car.Brand;
            _cars[index].Price = car.Price;
        }
    }
}
