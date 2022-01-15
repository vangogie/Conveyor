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
    }
}
