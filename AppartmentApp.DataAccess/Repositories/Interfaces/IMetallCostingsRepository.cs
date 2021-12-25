using AppartmentApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IMetallCostingsRepository
    {
        public Task<IEnumerable<MetallCosting>> Get();
        public Task<double> Cost(string materialConveyor);
        public Task<bool> Post(MetallCosting metallCosting);
    }
}
