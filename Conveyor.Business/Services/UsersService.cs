using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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

        public async Task<bool> Add(UserModel model)
        {
            var criptingPassword = Cripting(model.Password);
            var user = new User { Email = model.Email, Password = criptingPassword };
            return await _usersRepository.Add(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await _usersRepository.Delete(id);
        }

        public async Task<IEnumerable<UserEmail>> Get()
        {
            var entities = await _usersRepository.Get();
            var userEmails = new List<UserEmail>();
            foreach (var e in entities)
            {
                userEmails.Add(new UserEmail { Id = e.Id, Email = e.Email });
            }
            return userEmails;
        }

        public async Task<ClaimsIdentity> IsValidUser(UserModel userModel)
        {
            var user = new User { Email = userModel.Email, Password = Cripting(userModel.Password) };
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

        public async Task<bool> Update(UserModel userModel)
        {
            var user = new User { Email = userModel.Email, Password = Cripting(userModel.Password) };
            return await _usersRepository.Update(user);
        }

        private string Cripting(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(checkSum).Replace("-", string.Empty);
        }
    }
}
