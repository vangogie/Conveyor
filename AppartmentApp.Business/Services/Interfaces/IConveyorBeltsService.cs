using AppartmentApp.ViewModels.ViewModels;
using Conveyor.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IConveyorBeltsService
    {
        public Task<IEnumerable<GetConveyorBeltViewModel>> Get();
        public Task<double> Cost(string belt);
        public Task<bool> Post(PostConveyorBeltViewModel beltModel);
    }
}
