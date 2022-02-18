using Conveyor.Business.Services.Interfaces;
using Conveyor.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conveyor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetallCostingsController : ControllerBase
    {
        public readonly IMetallCostingsService _metallCostingsService;
        public MetallCostingsController(IMetallCostingsService metallCostingsService)
        {
            _metallCostingsService = metallCostingsService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetMetallCostingViewModel>> Get()
        {
            return await _metallCostingsService.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<GetMetallCostingViewModel> GetOne(int id)
        {
            return await _metallCostingsService.GetOne(id);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostMetallCostingViewModel metallModel)
        {
            var result = await _metallCostingsService.Post(metallModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] GetMetallCostingViewModel metallModel)
        {
            var result = await _metallCostingsService.Update(metallModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
