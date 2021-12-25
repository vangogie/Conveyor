using AppartmentApp.DataAccess.Context;
using AppartmentApp.DataAccess.Entities;
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

        public async Task<IEnumerable<ConveyorBelt>> Get()
        {
            var data = await _dbContext.ConveyorBelts.Include(x=>x.BeltType).Take(limit).ToListAsync();
            return data;
        }

        public async Task<bool> Post(ConveyorBelt conveyorBelt)
        {
            _dbContext.BeltTypes.Attach(conveyorBelt.BeltType);
            var entity = _dbContext.ConveyorBelts.Add(conveyorBelt);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
