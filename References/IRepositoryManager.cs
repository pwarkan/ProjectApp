using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References
{
    public interface IRepositoryManager
    {
        IClientRepository Client { get; }
        ICarRepository Car { get; }
        IClientCarsRepository ClientCars { get; }
        void Save();
    }
}
