using Conveyor.DataAccess.Context;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories
{
    public class MotovariosRepository : IMotovariosRepository
    {
        private readonly CustomDbContext _dbContext;
        private readonly int limit = 500;
        public MotovariosRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
            var builder = new DbContextOptionsBuilder<CustomDbContext>(); //startup
        }

        public async Task<bool> Delete(int id)
        {
            var engine = await _dbContext.Motovarios.FirstOrDefaultAsync(s => s.Id == id);
            _dbContext.Motovarios.Remove(engine);
            int result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Motovario>> Get()
        {
            var data = await _dbContext.Motovarios.Take(limit).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Motovario>> Get(double power)
        {
            return await _dbContext.Motovarios.Where(x => x.Power == power).ToListAsync(); ;
        }

        public async Task<Motovario> GetOne(int id)
        {
            return await _dbContext.Motovarios.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Post(Motovario motovario)
        {
            var entity = _dbContext.Motovarios.Add(motovario);
            await _dbContext.SaveChangesAsync();
            //appartment = entity.Entity; //для возврата добавленного объекта
            return true;
        }

        public async Task<bool> Update(Motovario motovario)
        {
            var entity = await _dbContext.Motovarios.FirstOrDefaultAsync(engine => engine.Id == motovario.Id);
            entity.Power = motovario.Power;
            entity.Cost = motovario.Cost;
            _dbContext.Motovarios.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
