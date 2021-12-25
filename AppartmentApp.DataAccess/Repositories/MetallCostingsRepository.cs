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
    public class MetallCostingsRepository : IMetallCostingsRepository
    {
        private readonly CustomDbContext _dbContext;
        private readonly int limit = 500;
        public MetallCostingsRepository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelBuilderExtensions.Initialize(_dbContext);
            var builder = new DbContextOptionsBuilder<CustomDbContext>(); //startup
        }

        public async Task<double> Cost(string materialConveyor)
        {
            var data = await _dbContext.MetallCostings.FirstOrDefaultAsync(x => x.Name == materialConveyor);
            return data.Cost;
        }

        public async Task<IEnumerable<MetallCosting>> Get()
        {
            var data = await _dbContext.MetallCostings.Take(limit).ToListAsync();
            return data;
        }

        public async Task<bool> Post(MetallCosting metallCosting)
        {
            var data = await _dbContext.MetallCostings.FirstOrDefaultAsync(x => x.Name == metallCosting.Name);
            data.Cost = metallCosting.Cost;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
