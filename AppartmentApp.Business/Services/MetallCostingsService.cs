using AppartmentApp.DataAccess.Entities;
using AppartmentApp.ViewModels.ViewModels;
using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.Business.Services
{
    public class MetallCostingsService : IMetallCostingsService
    {
        private readonly IMetallCostingsRepository _metallCostingsRepository;
        public MetallCostingsService(IMetallCostingsRepository metallCostingsRepository)
        {
            _metallCostingsRepository = metallCostingsRepository;
        }

        public async Task<double> Cost(string materialConveyor)
        {
            return await _metallCostingsRepository.Cost(materialConveyor);
        }

        public async Task<IEnumerable<GetMetallCostingViewModel>> Get()
        {
            var data = await _metallCostingsRepository.Get();
            var model = new List<GetMetallCostingViewModel>();
            foreach (var item in data)
            {
                model.Add(new GetMetallCostingViewModel
                {
                    Id = item.Id, 
                    Cost = item.Cost, 
                    Name = item.Name
                });
            }
            return model;
        }

        public async Task<bool> Post(PostMetallCostingViewModel metallModel)
        {
            MetallCosting metallCosting = new MetallCosting { Cost = metallModel.Cost, Name = metallModel.Name };
            return await _metallCostingsRepository.Post(metallCosting);
        }
    }
}
