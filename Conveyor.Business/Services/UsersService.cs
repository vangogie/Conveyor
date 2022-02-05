using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Conveyor.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<ClaimsIdentity> IsValidUser(UserModel userModel)
        {
            var user = new User { Email = userModel.Email, Password = userModel.Password };
            var entity = await _usersRepository.IsValidUser(user);
            if (entity != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, entity.Email)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
