using AppartmentApp.ViewModels.ViewModels;
using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
