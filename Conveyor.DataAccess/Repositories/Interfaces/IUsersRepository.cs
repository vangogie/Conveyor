using Conveyor.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> IsValidUser(User user);
        Task<IEnumerable<User>> Get();
        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
}
