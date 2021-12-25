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
    }
}
