using AutoMapper;
using Entities;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApp.Controllers
{
    public class ClientCarsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientCarsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //Удаление записи по clientId и carId
        [Route("clients/{clientId}/cars/{carId}")]
        [HttpDelete]
        public IActionResult DeleteClientCar(int clientId, int carId)
        {
            var clientCar = _repository.ClientCars.GetClientCar(clientId, carId, trackChanges: false);
            if (clientCar == null)
            {
                _logger.LogInfo($"Нет такого клиента с id={clientId} и машиной id={carId}.");
                return NotFound();
            }

            _repository.ClientCars.DeleteClientCar(clientCar);
            _repository.Save();

            _logger.LogInfo($"Успешно удалена запись c clientId={clientId} и carId={carId}.");
            return NoContent();
        }

        //Получение данных о владельцах и их машинах
        [Route("clients/cars")]
        [HttpGet]
        public IActionResult GetClientCars()
        {
            try
            {
                var clients = _repository.Client.GetAllClients(trackChanges: false);
                if (clients == null)
                {
                    _logger.LogInfo($"В базе данных нет клиентов.");
                    return NotFound();
                }

                var cars = _repository.Car.GetAllCars(trackChanges: false);
                if (cars == null)
                {
                    _logger.LogInfo($"В базе данных нет машин.");
                    return NotFound();
                }
                var carIds = cars.Select(x => x.Id).ToList();

                var clientCars = _repository.ClientCars.GetAllClientCars(trackChanges: false);
                if (clientCars == null)
                {
                    _logger.LogInfo($"Нет данных о владельцах и их машина.");
                    return NotFound();
                }

                foreach (var item in clientCars)
                {
                    item.Car = cars.First(x => x.Id == item.CarId);
                    item.Client = clients.First(x => x.Id == item.ClientId);
                }

                var clientCarsReturn = _mapper.Map<IEnumerable<ClientCarsDTO>>(clientCars);

                _logger.LogInfo($"Получен список клиентов и их машин");
                return Ok(clientCarsReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Что-то пошло не так в {nameof(GetClientCars)}: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        //Получение данных о владельцах и их машинах
        [Route("clients/cars")]
        [HttpPost]
        public IActionResult AddClientCar([FromBody] ClientCarsForCreationDTO clientCarForCreation)
        {
            try
            {
                if (clientCarForCreation == null)
                {
                    _logger.LogError("Объект ClientCarsForCreationDTO отправленный от клиента null.");
                    return BadRequest("Объект ClientCarsForCreationDTO null");
                }

                var clientCar = _mapper.Map<ClientCar>(clientCarForCreation);
                _repository.ClientCars.CreateClientCar(clientCar);
                _repository.Save();

                _logger.LogInfo($"Запись с clientId={clientCarForCreation.ClientId} и carId={clientCarForCreation.CarId} успешно добавлена");
                return Ok(clientCarForCreation);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Что-то пошло не так в {nameof(GetClientCars)}: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        //Получение данных о владельце и его машине
        [Route("clients/{clientId}/cars/{carId}")]
        [HttpGet]
        public IActionResult GetClientCar(int clientId, int carId)
        {
            try
            {
                var client = _repository.Client.GetClient(clientId, trackChanges: false);
                if (client == null)
                {
                    _logger.LogInfo($"Клиента с id={clientId} не существует.");
                    return NotFound();
                }

                var car = _repository.Car.GetCar(carId, trackChanges: false);
                if (car == null)
                {
                    _logger.LogInfo($"Машины с id={carId} не существует.");
                    return NotFound();
                }

                var clientCar = _repository.ClientCars.GetClientCar(clientId, carId, trackChanges: false);
                if (clientCar == null)
                {
                    _logger.LogInfo($"У клиента с id={clientId} нет машины с id={carId}.");
                    return NotFound();
                }

                clientCar.Client = client;
                clientCar.Car = car;

                var clientCarReturn = _mapper.Map<ClientCarsDTO>(clientCar);

                _logger.LogInfo($"Получен клиент с id={clientId} и его машина c id={carId}");
                return Ok(clientCarReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Что-то пошло не так в {nameof(GetClientCar)}: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
