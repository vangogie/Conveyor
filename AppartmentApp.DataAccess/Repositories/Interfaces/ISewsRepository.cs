using AppartmentApp.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppartmentApp.DataAccess.Repositories.Interfaces
{
    public interface ISewsRepository
    {
        public Task<IEnumerable<Sew>> Get();
        public Task<IEnumerable<Sew>> Get(double power);
        public Task<bool> Post(Sew sew);
        public Task<bool> Update(Sew sew);
    }
}
