using Conveyor.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IMetallCostingsRepository
    {
        Task<IEnumerable<MetallCosting>> Get();
        Task<double> Cost(string materialConveyor);
        Task<bool> Post(MetallCosting metallCosting);
        Task<MetallCosting> GetOne(int id);
        Task<bool> Update(MetallCosting metallCosting);
    }
}
