using AppartmentApp.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppartmentApp.DataAccess.Repositories.Interfaces
{
    public interface ISewsRepository
    {
        Task<IEnumerable<Sew>> Get();
        Task<IEnumerable<Sew>> Get(double power);
        Task<bool> Post(Sew sew);
        Task<bool> Update(Sew sew);
        Task<Sew> GetOne(int id);
        Task<bool> Delete(int id);
    }
}
