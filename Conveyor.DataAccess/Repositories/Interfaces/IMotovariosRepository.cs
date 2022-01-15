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
        public Task<IEnumerable<Motovario>> Get();
        public Task<IEnumerable<Motovario>> Get(double power);
        public Task<bool> Post(Motovario motovario);
    }
}
