using Conveyor.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IBeltTypesRepository
    {
        public Task<IEnumerable<BeltType>> Get();
        public Task<BeltType> Get(string BeltTypeName);
    }
}
