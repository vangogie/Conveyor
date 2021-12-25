using AppartmentApp.DataAccess.Context.Interfaces;
using AppartmentApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppartmentApp.DataAccess.Context
{
    public class CustomDbContext : DbContext, ICustomDbContext
    {
        public DbSet<BeltType> BeltTypes { get; set; }
        public DbSet<ConveyorBelt> ConveyorBelts { get; set; }
        public DbSet<MetallCosting> MetallCostings { get; set; }
        public DbSet<Motovario> Motovarios { get; set; }
        public DbSet<Sew> Sews { get; set; }


        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        private static DbContextOptions DbOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
