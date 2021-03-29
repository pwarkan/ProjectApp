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
    class ClientsFakeController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientsFakeController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
            var result = _repository.GetAllClients(trackChanges: false)
                .ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetClient(int id)
        {
            var client = _repository.GetClient(id, false);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateClient(client);
            }
            else
            {
                return BadRequest();
            }
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveClient(Client client)
        {
            var clientEntity = _repository.GetClient(client.Id, false);
            if (clientEntity == null)
            {
                return NotFound();
            }
            _repository.DeleteClient(clientEntity);
            return NoContent();
        }
    }
}
