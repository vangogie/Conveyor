using AppartmentApp.DataAccess.Entities;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.DataAccess.Repositories.Interfaces;
using AppartmentApp.ViewModels.ViewModels;
using Conveyor.Business.Services.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Business.Services
{
    public class SewsService : ISewsService
    {
        private readonly ISewsRepository _sewsRepository;
        public SewsService(ISewsRepository sewsRepository)
        {
            _sewsRepository = sewsRepository;
        }

        public async Task<IEnumerable<GetSewViewModel>> Get()
        {
            var data = await _sewsRepository.Get();
            var model = new List<GetSewViewModel>();
            foreach (var item in data)
            {
                model.Add(new GetSewViewModel
                {
                    Id = item.Id,
                    Power = item.Power,
                    Cost = item.Cost
                });
            }
            return model;
        }

        public async Task<double> AwerageCost(double power)
        {
            var enginesByPower = await _sewsRepository.Get(power);
            if (((List<Sew>)enginesByPower).Count == 0)
            {
                return 0;
            }
            double awerageCost = 0;
            foreach (var engine in enginesByPower)
            {
                awerageCost += engine.Cost;
            }
            return awerageCost/((List<Sew>)enginesByPower).Count;
        }

        public async Task<bool> Post(PostSewViewModel sewModel)
        {
            Sew sew = new Sew { Cost = sewModel.Cost, Power = sewModel.Power };
            return await _sewsRepository.Post(sew);
        }

        public async Task<bool> Update(GetSewViewModel sewModel)
        {
            var sew = new Sew { Id = sewModel.Id, Cost = sewModel.Cost, Power = sewModel.Power };
            return await _sewsRepository.Update(sew);
        }

        public async Task<GetSewViewModel> GetOne(int id)
        {
            var data = await _sewsRepository.GetOne(id);
            var model = new GetSewViewModel
            {
                Id = data.Id,
                Power = data.Power,
                Cost = data.Cost
            };


            return model;
        }

        public async Task<bool> Delete(int id)
        {
            return await _sewsRepository.Delete(id);
        }
    }
}
