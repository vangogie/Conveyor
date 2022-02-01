using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IMetallCostingsService
    {
        Task<IEnumerable<GetMetallCostingViewModel>> Get();
        Task<double> Cost(string materialConveyor);
        Task<bool> Post(PostMetallCostingViewModel metallModel);
        Task<GetMetallCostingViewModel> GetOne(int id);
        Task<bool> Update(GetMetallCostingViewModel metallModel);
    }
}
