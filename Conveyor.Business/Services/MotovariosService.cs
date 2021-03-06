using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.DataAccess.Repositories.Interfaces;
using Conveyor.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conveyor.Business.Services
{
    public class MotovariosService : IMotovariosService
    {
        private readonly IMotovariosRepository _motovarioRepository;
        public MotovariosService(IMotovariosRepository motovarioRepository)
        {
            _motovarioRepository = motovarioRepository;
        }

        public async Task<IEnumerable<GetMotovarioViewModel>> Get()
        {
            var appartments = await _motovarioRepository.Get();
            var model = new List<GetMotovarioViewModel>();
            foreach (var item in appartments)
            {
                model.Add(new GetMotovarioViewModel
                {
                    Id = item.Id,
                    Power = item.Power,
                    Cost = item.Cost
                });
            }
            return model.OrderByDescending(e=>e.Power);
        }

        public async Task<double> AwerageCost(double power)
        {
            var enginesByPower = await _motovarioRepository.Get(power);
            if (((List<Motovario>)enginesByPower).Count == 0)
            {
                return 0;
            }
            double awerageCost = 0;
            foreach (var engine in enginesByPower)
            {
                awerageCost += engine.Cost;
            }
            return awerageCost / ((List<Motovario>)enginesByPower).Count;
        }

        public async Task<bool> Post(PostMotovarioViewModel MotovarioModel)
        {
            Motovario motovario = new Motovario { Cost = MotovarioModel.Cost, Power = MotovarioModel.Power };
            return await _motovarioRepository.Post(motovario);
        }

        public async Task<bool> Update(GetMotovarioViewModel motovarioModel)
        {
            var motovario = new Motovario { Id = motovarioModel.Id, Cost = motovarioModel.Cost, Power = motovarioModel.Power };
            return await _motovarioRepository.Update(motovario);
        }

        public async Task<GetMotovarioViewModel> GetOne(int id)
        {
            var data = await _motovarioRepository.GetOne(id);
            var model = new GetMotovarioViewModel
            {
                Id = data.Id,
                Power = data.Power,
                Cost = data.Cost
            };

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            return await _motovarioRepository.Delete(id);
        }
    }
}
