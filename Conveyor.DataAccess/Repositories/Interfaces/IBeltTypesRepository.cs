using Conveyor.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IBeltTypesRepository
    {
        Task<IEnumerable<BeltType>> Get();
        Task<BeltType> Get(string BeltTypeName);
        Task<bool> Add(BeltType entity);
        Task<bool> Update(BeltType model);
        Task<bool> Delete(int id);
        Task<BeltType> GetOne(int id);
    }
}
