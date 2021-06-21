using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References
{
    public interface IClientCarsRepository
    {
        IEnumerable<ClientCar> GetAllClientCars(bool trackChanges);
        ClientCar GetClientCar(int clientId, int carId, bool trackChanges);
        void CreateClientCar(ClientCar clientCar);
        void DeleteClientCar(ClientCar clientCar);
        void UpdateClientCar(ClientCar clientCar);
    }
}
