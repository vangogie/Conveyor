using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services
{
    public class BeltTypesService : IBeltTypesService
    {
        private readonly IBeltTypesRepository _beltTypeRepository;

        public BeltTypesService(IBeltTypesRepository beltTypeRepository)
        {
            _beltTypeRepository = beltTypeRepository;
        }

        public async Task<bool> Add(GetBeltTypeViewModel beltType)
        {
            var entity = new BeltType { Type = beltType.Type };
            return await _beltTypeRepository.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _beltTypeRepository.Delete(id);
        }

        public async Task<IEnumerable<GetBeltTypeViewModel>> Get()
        {
            var data = await _beltTypeRepository.Get();
            var model = new List<GetBeltTypeViewModel>();
            foreach (var item in data)
            {
                model.Add(new GetBeltTypeViewModel
                {
                    Id = item.Id, 
                    Type = item.Type
                });
            }
            return model;
        }

        public async Task<GetBeltTypeViewModel> GetOne(int id)
        {
            var entity = await _beltTypeRepository.GetOne(id);
            return new GetBeltTypeViewModel
            {
                Id = entity.Id,
                Type = entity.Type
            };
        }

        public async Task<bool> Update(GetBeltTypeViewModel beltType)
        {
            var model = new BeltType { Id = beltType.Id, Type = beltType.Type };
            return await _beltTypeRepository.Update(model);
        }
    }
}
