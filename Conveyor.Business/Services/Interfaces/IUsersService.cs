using Conveyor.DataAccess.Entities;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ClaimsIdentity> IsValidUser(UserModel userModel);
        Task<IEnumerable<UserEmail>> Get();
        Task<bool> Add(UserModel model);
        Task<bool> Update(UserModel model);
        Task<bool> Delete(int id);
    }
}
