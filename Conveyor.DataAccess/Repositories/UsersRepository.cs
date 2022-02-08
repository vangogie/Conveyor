using Conveyor.DataAccess.Context;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CustomDbContext _dbContext;

        public UsersRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
        }

        public async Task<bool> Add(User user)
        {
            var findSame = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (findSame == null)
            {
                var newEntity = _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                //appartment = entity.Entity; //для возврата добавленного объекта
                return true;
            }
            return false;
            
        }

        public async Task<bool> Delete(int id)
        {
            var count = _dbContext.Users.Count();
            if (count > 1)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                _dbContext.Users.Remove(user);
                int result = await _dbContext.SaveChangesAsync();
                if (result == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> IsValidUser(User user)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        }

        public async Task<bool> Update(User user)
        {
            var findSame = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (findSame != null)
            {
                findSame.Password = user.Password;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
