using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IMotovariosService
    {
        Task<IEnumerable<GetMotovarioViewModel>> Get();
        Task<double> AwerageCost(double power);
        Task<bool> Post(PostMotovarioViewModel MotovarioModel);
        Task<bool> Update(GetMotovarioViewModel motovarioModel);
        Task<GetMotovarioViewModel> GetOne(int id);
        Task<bool> Delete(int id);
    }
}
