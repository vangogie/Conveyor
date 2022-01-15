using Conveyor.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IConveyorBeltsRepository
    {
        public Task<IEnumerable<ConveyorBelt>> Get();
        Task<double> Cost(string beltType);
        Task<bool> Post(ConveyorBelt conveyorBelt);
    }
}
