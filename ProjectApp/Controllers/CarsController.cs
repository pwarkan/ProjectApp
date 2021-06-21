using System;
using System.Collections.Generic;
using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using References;

namespace ProjectApp.Controllers
{
    [Route("[controller]")] //https://localhost:5001/cars
    public class CarsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CarsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //��������� ������ ���� �����    https://localhost:5001/cars
        [HttpGet]
        public IActionResult GetCars()
        {
            try
            {
                var cars = _repository.Car.GetAllCars(trackChanges: false);

                var carsDto = _mapper.Map<IEnumerable<CarDTO>>(cars);

                _logger.LogInfo($"������� ������ ���� �����");
                return Ok(carsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"���-�� ����� �� ��� � {nameof(GetCars)}: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        //��������� ������ �� id    https://localhost:5001/cars/5
        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = _repository.Car.GetCar(id, trackChanges: false);
            if (car == null)
            {
                _logger.LogInfo($"������ � id={id} �� ����������.");
                return NotFound();
            }
            else
            {
                var carDto = _mapper.Map<CarDTO>(car);
                _logger.LogInfo($"������� ������ � id={id}.");
                return Ok(carDto);
            }
        }

        //�������� ������      https://localhost:5001/cars
        [HttpPost]
        public IActionResult CreateCar([FromBody] CarForCreationDTO car)
        {
            if (car == null)
            {
                _logger.LogError("������ CarForCreationDTO ������������ �� ������� null.");
                return BadRequest("������ CarForCreationDTO null");
            }

            var carEntity = _mapper.Map<Car>(car);

            _repository.Car.CreateCar(carEntity);
            _repository.Save();

            var carToReturn = _mapper.Map<CarDTO>(carEntity);

            _logger.LogInfo($"������� ������� ����� ������.");
            return Ok(carToReturn);
        }

        //�������� ������ �� id     https://localhost:5001/cars/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _repository.Car.GetCar(id, trackChanges: false);
            if (car == null)
            {
                _logger.LogInfo($"������ � id={id} �� ����������.");
                return NotFound();
            }

            _repository.Car.DeleteCar(car);
            _repository.Save();

            _logger.LogInfo($"������� ������� ������ � id={id}.");
            return NoContent();
        }

        //�������������� ������ �� id     https://localhost:5001/cars/5
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] CarForUpdateDTO car)
        {
            if (car == null)
            {
                _logger.LogError("������ CarForUpdateDTO ������������ �� ������� null.");
                return BadRequest("������ CarForUpdateDTO null");
            }

            var carEntity = _repository.Car.GetCar(id, trackChanges: true);
            if (carEntity == null)
            {
                _logger.LogInfo($"������ � id={id} �� ����������.");
                return NotFound();
            }

            _mapper.Map(car, carEntity);
            _repository.Save();

            _logger.LogInfo($"������ � id={id} ������� ���������������.");
            return NoContent();
        }
    }
}