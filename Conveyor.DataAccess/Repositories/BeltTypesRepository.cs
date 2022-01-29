using Conveyor.DataAccess.Context;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Repositories
{
    public class BeltTypesRepository : IBeltTypesRepository
    {
        private readonly CustomDbContext _dbContext;
        private readonly int limit = 500;
        public BeltTypesRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
            var builder = new DbContextOptionsBuilder<CustomDbContext>(); //startup
        }

        public async Task<bool> Add(BeltType entity)
        {
            var newEntity = _dbContext.BeltTypes.Add(entity);
            await _dbContext.SaveChangesAsync();
            //appartment = entity.Entity; //для возврата добавленного объекта
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var beltType = await _dbContext.BeltTypes.FirstOrDefaultAsync(s => s.Id == id);
            _dbContext.BeltTypes.Remove(beltType);
            int result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BeltType>> Get()
        {
            var data = await _dbContext.BeltTypes.Take(limit).ToListAsync();
            return data;
        }

        public async Task<BeltType> Get(string BeltTypeName)
        {
            var data = await _dbContext.BeltTypes.FirstOrDefaultAsync(x => x.Type == BeltTypeName);
            return data;
        }

        public async Task<BeltType> GetOne(int id)
        {
            return await _dbContext.BeltTypes.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Update(BeltType model)
        {
            var entity = await _dbContext.BeltTypes.FirstOrDefaultAsync(bt => bt.Id == model.Id);
            entity.Type = model.Type;
            _dbContext.BeltTypes.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
