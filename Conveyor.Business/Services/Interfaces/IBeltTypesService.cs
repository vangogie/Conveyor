using Conveyor.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IBeltTypesService
    {
        public Task<IEnumerable<GetBeltTypeViewModel>> Get();
    }
}
