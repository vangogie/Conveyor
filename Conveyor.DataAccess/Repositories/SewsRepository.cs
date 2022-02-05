using Conveyor.DataAccess.Context;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories
{
    public class SewsRepository : ISewsRepository
    {
        private readonly CustomDbContext _dbContext;
        private readonly int limit = 500;
        public SewsRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
            var builder = new DbContextOptionsBuilder<CustomDbContext>(); //startup
        }

        public async Task<bool> Delete(int id)
        {
            var engine = await _dbContext.Sews.FirstOrDefaultAsync(s => s.Id == id);
            _dbContext.Sews.Remove(engine);
            int result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Sew>> Get()
        {
            var data = await _dbContext.Sews.Take(limit).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Sew>> Get(double power)
        {
            return await _dbContext.Sews.Where(x => x.Power == power).ToListAsync();
        }

        public async Task<Sew> GetOne(int id)
        {
            return await _dbContext.Sews.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Post(Sew sew)
        {
            var entity = _dbContext.Sews.Add(sew);
            await _dbContext.SaveChangesAsync();
            //appartment = entity.Entity; //для возврата добавленного объекта
            return true;
        }

        public async Task<bool> Update(Sew sew)
        {
            var entity = await _dbContext.Sews.FirstOrDefaultAsync(engine => engine.Id == sew.Id);
            entity.Power = sew.Power;
            entity.Cost = sew.Cost;
             _dbContext.Sews.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
