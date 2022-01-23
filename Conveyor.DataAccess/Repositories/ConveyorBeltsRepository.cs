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
    public class ConveyorBeltsRepository : IConveyorBeltsRepository
    {
        private readonly CustomDbContext _dbContext;
        private readonly int limit = 500;
        public ConveyorBeltsRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
            var builder = new DbContextOptionsBuilder<CustomDbContext>(); //startup
        }

        public async Task<double> Cost(string beltType)
        {
            var belts = await _dbContext.ConveyorBelts
                .Include(x => x.BeltType)
                .Where(x => x.BeltType.Type == beltType).ToListAsync();
            if (belts!=null)
            {
                double cost = 0;
                foreach (var belt in belts)
                {
                    cost += belt.Cost;
                }
                cost /= belts.Count;
                return cost;
            }
            return 0;
        }

        public async Task<bool> Delete(int id)
        {
            var belt = await _dbContext.ConveyorBelts.FirstOrDefaultAsync(cb => cb.Id == id);
            _dbContext.ConveyorBelts.Remove(belt);
            int result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ConveyorBelt>> Get()
        {
            var data = await _dbContext.ConveyorBelts.Include(x=>x.BeltType).Take(limit).ToListAsync();
            return data;
        }

        public async Task<ConveyorBelt> GetOne(int id)
        {
            return await _dbContext.ConveyorBelts
                .AsNoTracking()
                .Include(cb => cb.BeltType)
                .FirstOrDefaultAsync(cb => cb.Id == id);
        }

        public async Task<bool> Post(ConveyorBelt conveyorBelt)
        {
            _dbContext.BeltTypes.Attach(conveyorBelt.BeltType);
            var entity = _dbContext.ConveyorBelts.Add(conveyorBelt);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(ConveyorBelt conveyorBelt)
        {
            var beltType = await _dbContext.BeltTypes.FirstOrDefaultAsync(bt => bt.Id == conveyorBelt.BeltType.Id);
            var belt = await _dbContext.ConveyorBelts.FirstOrDefaultAsync(cb => cb.Id == conveyorBelt.Id);
            belt.Name = conveyorBelt.Name;
            belt.Cost = conveyorBelt.Cost;
            belt.BeltType = beltType;
            _dbContext.ConveyorBelts.Update(belt);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
