using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IBeltTypesService
    {
        Task<IEnumerable<GetBeltTypeViewModel>> Get();
        Task<bool> Add(GetBeltTypeViewModel beltType);
        Task<bool> Update(GetBeltTypeViewModel beltType);
        Task<bool> Delete(int id);
        Task<GetBeltTypeViewModel> GetOne(int id);
    }
}
