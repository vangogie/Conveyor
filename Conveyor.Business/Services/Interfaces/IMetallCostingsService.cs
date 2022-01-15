using Conveyor.ViewModels.ViewModels;
using Conveyor.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IMetallCostingsService
    {
        public Task<IEnumerable<GetMetallCostingViewModel>> Get();
        public Task<double> Cost(string materialConveyor);
        public Task<bool> Post(PostMetallCostingViewModel metallModel);
    }
}
