using Conveyor.Business.Services;
using Conveyor.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Conveyor.Business
{
    public static class Startup
    {
        public static void Start(IServiceCollection services, string connectStr)
        {
            services.AddTransient<ISewsService, SewsService>();
            services.AddTransient<IMotovariosService, MotovariosService>(); 
            services.AddTransient<IBeltTypesService, BeltTypesService>();
            services.AddTransient<IConveyorBeltsService, ConveyorBeltsService>();
            services.AddTransient<IMetallCostingsService, MetallCostingsService>();
            services.AddTransient<IUsersService, UsersService>();
            Conveyor.DataAccess.Startup.Start(services, connectStr);
        }
    }
}
