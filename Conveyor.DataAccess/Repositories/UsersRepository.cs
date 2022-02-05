using Conveyor.DataAccess.Context;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CustomDbContext _dbContext;
        private readonly int limit = 500;

        public UsersRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
        }

        public async Task<User> IsValidUser(User user)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        }
    }
}
