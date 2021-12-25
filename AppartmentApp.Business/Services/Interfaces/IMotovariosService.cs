using AppartmentApp.ViewModels.ViewModels;
using Conveyor.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.Business.Services.Interfaces
{
    public interface IMotovariosService
    {
        public Task<IEnumerable<GetMotovarioViewModel>> Get();
        public Task<double> AwerageCost(double power);
        public Task<bool> Post(PostMotovarioViewModel MotovarioModel);
    }
}
