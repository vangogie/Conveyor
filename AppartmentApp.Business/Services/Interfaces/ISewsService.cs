using AppartmentApp.ViewModels.ViewModels;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface ISewsService
    {
        public Task<IEnumerable<GetSewViewModel>> Get();
        public Task<double> AwerageCost(double power);
        public Task<bool> Post(PostSewViewModel sewModel);
        public Task<bool> Update(GetSewViewModel sewModel);
    }
}
