using Conveyor.ViewModels.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ClaimsIdentity> IsValidUser(UserModel userModel);
    }
}
