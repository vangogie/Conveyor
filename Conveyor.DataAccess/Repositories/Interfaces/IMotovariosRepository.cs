using Conveyor.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IMotovariosRepository
    {
        Task<IEnumerable<Motovario>> Get();
        Task<IEnumerable<Motovario>> Get(double power);
        Task<bool> Post(Motovario motovario);
        Task<bool> Update(Motovario motovario);
        Task<Motovario> GetOne(int id);
        Task<bool> Delete(int id);
    }
}
