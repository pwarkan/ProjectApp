using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [Route("[controller]")]
    class CarsFakeController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarsFakeController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars() {
            var result = _repository.GetAllCars(trackChanges: false)
                .ToList();
            return Ok(result);
        }

       [HttpGet("{id}")]
        public ActionResult GetCar(int id)
        {
            var car = _repository.GetCar(id, false);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public ActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateCar(car);
            }
            else
            {
                return BadRequest();
            }
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveCar(Car car)
        {
            var carEntity = _repository.GetCar(car.Id, false);
            if (carEntity == null)
            {
                return NotFound();
            }
            _repository.DeleteCar(carEntity);
            return NoContent();
        }
    }
}
