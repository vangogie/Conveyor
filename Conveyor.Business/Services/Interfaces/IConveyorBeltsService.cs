using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IConveyorBeltsService
    {
        Task<IEnumerable<GetConveyorBeltViewModel>> Get();
        Task<double> Cost(string belt);
        Task<bool> Post(PostConveyorBeltViewModel beltModel);
        Task<bool> Delete(int id);
        Task<GetConveyorBeltViewModel> GetOne(int id);
        Task<bool> Update(GetConveyorBeltViewModel beltModel);
    }
}
