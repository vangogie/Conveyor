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
        public async Task<IEnumerable<Motovario>> Get()
        {
            var data = await _dbContext.Motovarios.Take(limit).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Motovario>> Get(double power)
        {
            return await _dbContext.Motovarios.Where(x => x.Power == power).ToListAsync(); ;
        }

        public async Task<bool> Post(Motovario motovario)
        {
            var entity = _dbContext.Motovarios.Add(motovario);
            await _dbContext.SaveChangesAsync();
            //appartment = entity.Entity; //для возврата добавленного объекта
            return true;
        }
    }
}
