using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using References;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectApp.Controllers
{
    [Route("[controller]")] //https://localhost:5001/clients
    public class ClientsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //Получение списка всех клиентов    https://localhost:5001/clients
        [HttpGet]
        public IActionResult GetClients()
        {
            try
            {
                var clients = _repository.Client.GetAllClients(trackChanges: false);

                var clientsDto = _mapper.Map<IEnumerable<ClientDTO>>(clients);

                _logger.LogInfo($"Получен список всех клиентов");
                return Ok(clientsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Что-то пошло не так в {nameof(GetClients)}: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        //Получение клиета по id    https://localhost:5001/clients/5
        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _repository.Client.GetClient(id, trackChanges: false);
            if (client == null)
            {
                _logger.LogInfo($"Клиент с id={id} не существует.");
                return NotFound();
            }
            else
            {
                var clientDto = _mapper.Map<ClientDTO>(client);
                _logger.LogInfo($"Найден клиент с id={id}.");
                return Ok(clientDto);
            }
        }

        //Создание клиента      https://localhost:5001/clients
        [HttpPost]
        public IActionResult CreateCompany([FromBody] ClientForCreationDTO client)
        {
            if (client == null)
            {
                _logger.LogError("Объект ClientForCreationDTO отправленный от клиента null.");
                return BadRequest("Объект ClientForCreationDTO null");
            }

            var clientEntity = _mapper.Map<Client>(client);

            _repository.Client.CreateClient(clientEntity);
            _repository.Save();

            var clientToReturn = _mapper.Map<ClientDTO>(clientEntity);

            _logger.LogInfo($"Успешно создан новый клиент.");
            return Ok(clientToReturn);
        }

        //Удаление клиента по id      https://localhost:5001/clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _repository.Client.GetClient(id, trackChanges: false);
            if (client == null)
            {
                _logger.LogInfo($"Клиент с id={id} не существует.");
                return NotFound();
            }

            _repository.Client.DeleteClient(client);
            _repository.Save();

            _logger.LogInfo($"Успешно удален клиент с id={id}.");
            return NoContent();
        }

        //Редактирование клиента по id     https://localhost:5001/clients/5
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientForUpdateDTO client)
        {
            if (client == null)
            {
                _logger.LogError("Объект ClientForUpdateDTO отправленный от клиента null.");
                return BadRequest("Объект ClientForCreationDTO null");
            }

            var clientEntity = _repository.Client.GetClient(id, trackChanges: true);
            if (clientEntity == null)
            {
                _logger.LogInfo($"Клиент с id={id} не существует.");
                return NotFound();
            }

            _mapper.Map(client, clientEntity);
            _repository.Save();

            _logger.LogInfo($"Клиент с id={id} успешно отредактирован.");
            return NoContent();
        }
    }
}
