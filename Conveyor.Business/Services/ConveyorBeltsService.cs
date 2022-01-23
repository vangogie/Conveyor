using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services
{
    public class ConveyorBeltsService : IConveyorBeltsService
    {
        private readonly IConveyorBeltsRepository _conveyorBeltsRepository;
        private readonly IBeltTypesRepository _beltTypesRepository;

        public ConveyorBeltsService(IConveyorBeltsRepository conveyorBeltsRepository, IBeltTypesRepository beltTypesRepository)
        {
            _conveyorBeltsRepository = conveyorBeltsRepository;
            _beltTypesRepository = beltTypesRepository;
        }

        public async Task<double> Cost(string belt)
        {
            return await _conveyorBeltsRepository.Cost(belt);
        }

        public async Task<IEnumerable<GetConveyorBeltViewModel>> Get()
        {
            var data = await _conveyorBeltsRepository.Get();
            var model = new List<GetConveyorBeltViewModel>();
            foreach (var item in data)
            {
                model.Add(new GetConveyorBeltViewModel
                {
                    Id = item.Id, 
                    BeltType = new GetBeltTypeViewModel { Id = item.BeltType.Id, Type = item.BeltType.Type }, 
                    Cost = item.Cost, 
                    Name = item.Name
                });
            }
            return model;
        }

        public async Task<bool> Post(PostConveyorBeltViewModel beltModel)
        {
            BeltType beltType = await _beltTypesRepository.Get(beltModel.BeltType);
            ConveyorBelt conveyorBelt = new ConveyorBelt { Cost = beltModel.Cost, Name = beltModel.Name, BeltType = beltType };
            return await _conveyorBeltsRepository.Post(conveyorBelt);
        }

        public async Task<bool> Delete(int id)
        {
            return await _conveyorBeltsRepository.Delete(id);
        }

        public async Task<GetConveyorBeltViewModel> GetOne(int id)
        {
            var data = await _conveyorBeltsRepository.GetOne(id);
            return new GetConveyorBeltViewModel
            {
                Id = data.Id,
                BeltType = new GetBeltTypeViewModel { Id = data.BeltType.Id, Type = data.BeltType.Type },
                Cost = data.Cost,
                Name = data.Name
            };
        }

        public async Task<bool> Update(GetConveyorBeltViewModel beltModel)
        {
            var beltType = new BeltType { Id = beltModel.BeltType.Id };
            var model = new ConveyorBelt { Id = beltModel.Id, Cost = beltModel.Cost, Name = beltModel.Name, BeltType = beltType };
            return await _conveyorBeltsRepository.Update(model);
        }
    }
}
