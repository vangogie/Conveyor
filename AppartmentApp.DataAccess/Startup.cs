using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.DataAccess.Repositories;

namespace AppartmentApp.DataAccess
{
    public static class Startup
    {
        public static void Start(IServiceCollection services, string connectStr)
        {
            services.AddTransient<ISewsRepository, SewsRepository>();
            services.AddTransient<IMotovariosRepository, MotovariosRepository>(); 
            services.AddTransient<IBeltTypesRepository, BeltTypesRepository>();
            services.AddTransient<IConveyorBeltsRepository, ConveyorBeltsRepository>();
            services.AddTransient<IMetallCostingsRepository, MetallCostingsRepository>();
            services.AddDbContext<Context.CustomDbContext>(options => options.UseSqlServer(connectStr));
        }
    }
}
