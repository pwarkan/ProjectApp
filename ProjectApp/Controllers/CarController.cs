using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Models;
using ProjectApp.Services;

namespace ProjectApp.Controllers
{
    [Route("[controller]")] //https://localhost:5001/car
    public class CarController : ControllerBase
    {
        private ICarService _carService;
        private ILoggerService _logger;

        public CarController(ICarService carService, ILoggerService logger)
        {
            _carService = carService;
            _logger = logger;
        }

        [HttpGet] //https://localhost:5001/car
        public ActionResult<List<Car>> Get()
        {
            _logger.LogInformation("Получен список всех машин");
            return _carService.GetCars();
        }

        [HttpGet("{id}")] //https://localhost:5001/car/1
        public ActionResult<Car> Get(int id)
        {
            Car car = _carService.GetCar(id);
            if (car == null)
            {
                _logger.LogError($"Не найдена машина с id = {id}");
                return NotFound();
            }

            _logger.LogInformation($"Получена машина с id = {id}");
            return car;
        }

        [HttpPost] //https://localhost:5001/car
        public ActionResult<Car> Add(Car car)
        {
            _carService.AddCar(car);
            _logger.LogInformation($"Добавлена машина с id = {car.Id}");
            return Ok($"Добавлена машина с id = {car.Id}");
        }

        [HttpPut] //https://localhost:5001/car
        public ActionResult<Car> Update(Car car)
        {
            _carService.UpdateCar(car);
            _logger.LogInformation($"Изменена машина с id = {car.Id}");
            return NoContent();
        }

        [HttpDelete("{id}")] //https://localhost:5001/car/1
        public ActionResult<Car> Delete(int id)
        {
            _carService.DeleteCar(id);
            _logger.LogInformation($"Удалена машина с id = {id}");
            return Ok($"Удалена машина с id = {id}");
        }
    }
}