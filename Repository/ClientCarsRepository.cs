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
    public class ClientCarsRepository : RepositoryBase<ClientCar>, IClientCarsRepository
    {
        public ClientCarsRepository(CarServiceContext carServiceContext)
            : base(carServiceContext)
        {
        }

        public void CreateClientCar(ClientCar clientCar) => Create(clientCar);

        public void DeleteClientCar(ClientCar clientCar) => Delete(clientCar);

        public ClientCar GetClientCar(int clientId, int carId, bool trackChanges) =>
            FindByCondition(e => e.ClientId.Equals(clientId) && e.CarId.Equals(carId), trackChanges)
            .SingleOrDefault();

        public void UpdateClientCar(ClientCar clientCar) => Update(clientCar);

        public IEnumerable<ClientCar> GetAllClientCars(bool trackChanges) =>
            FindAll(false)
            .ToList();
    }
}
