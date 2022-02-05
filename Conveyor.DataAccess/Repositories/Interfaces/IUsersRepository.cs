using Conveyor.DataAccess.Entities;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> IsValidUser(User user);
    }
}
