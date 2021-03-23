using Entities;
using References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    //Данный репозиторий-менеджер сохраняет данные в базе через контекст
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CarServiceContext _carServiceContext;
        private ICarRepository _carRepository;
        private IClientRepository _clientRepository;
        private IClientCarsRepository clientCarsRepository;

        public RepositoryManager(CarServiceContext carServiceContext)
        {
            _carServiceContext = carServiceContext;
        }

        public IClientRepository Client
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(_carServiceContext);

                return _clientRepository;
            }
        }

        public ICarRepository Car
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_carServiceContext);

                return _carRepository;
            }
        }

        public IClientCarsRepository ClientCars
        {
            get
            {
                if (clientCarsRepository == null)
                    clientCarsRepository = new ClientCarsRepository(_carServiceContext);

                return clientCarsRepository;
            }
        }

        public void Save() => _carServiceContext.SaveChanges();
    }
}
