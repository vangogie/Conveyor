using Conveyor.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IConveyorBeltsRepository
    {
        Task<IEnumerable<ConveyorBelt>> Get();
        Task<double> Cost(string beltType);
        Task<bool> Post(ConveyorBelt conveyorBelt);
        Task<bool> Delete(int id);
        Task<ConveyorBelt> GetOne(int id);
        Task<bool> Update(ConveyorBelt conveyorBelt);
    }
}
