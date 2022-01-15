using Conveyor.ViewModels.ViewModels;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface ISewsService
    {
        Task<IEnumerable<GetSewViewModel>> Get();
        Task<double> AwerageCost(double power);
        Task<bool> Post(PostSewViewModel sewModel);
        Task<bool> Update(GetSewViewModel sewModel);
        Task<GetSewViewModel> GetOne(int id);
        Task<bool> Delete(int id);
    }
}
