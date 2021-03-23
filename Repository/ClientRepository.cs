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
    //Репозиторий клиентов
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(CarServiceContext carServiceContext)
            : base(carServiceContext)
        {
        }

        public void CreateClient(Client client) => Create(client);
        public void DeleteClient(Client client) => Delete(client);
        public void UpdateClient(Client client) => Update(client);

        public IEnumerable<Client> GetAllClients(bool trackChanges) =>
             FindAll(trackChanges)
            .ToList();

        public Client GetClient(int clientId, bool trackChanges) =>
                FindByCondition(c => c.Id.Equals(clientId), trackChanges)
                .SingleOrDefault();
    }
}
