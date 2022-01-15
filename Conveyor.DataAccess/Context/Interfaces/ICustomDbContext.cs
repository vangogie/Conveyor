using Conveyor.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conveyor.DataAccess.Context.Interfaces
{
    public interface ICustomDbContext
    {
        public DbSet<BeltType> BeltTypes { get; set; }
        public DbSet<ConveyorBelt> ConveyorBelts { get; set; }
        public DbSet<MetallCosting> MetallCostings { get; set; }
        public DbSet<Motovario> Motovarios { get; set; }
        public DbSet<Sew> Sews { get; set; }
    }
}
