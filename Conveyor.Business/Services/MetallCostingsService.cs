using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
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

        public async Task<GetMetallCostingViewModel> GetOne(int id)
        {
            var entity = await _metallCostingsRepository.GetOne(id);
            return new GetMetallCostingViewModel
            {
                Id = entity.Id,
                Cost = entity.Cost,
                Name = entity.Name
            };
        }

        public async Task<bool> Post(PostMetallCostingViewModel metallModel)
        {
            MetallCosting metallCosting = new MetallCosting { Cost = metallModel.Cost, Name = metallModel.Name };
            return await _metallCostingsRepository.Post(metallCosting);
        }

        public async Task<bool> Update(GetMetallCostingViewModel metallModel)
        {
            MetallCosting metallCosting = new MetallCosting 
            {
                Id = metallModel.Id,
                Cost = metallModel.Cost, 
                Name = metallModel.Name 
            };
            return await _metallCostingsRepository.Update(metallCosting);
        }
    }
}
