using Conveyor.ViewModels.ViewModels;
using Conveyor.Business.Services.Interfaces;
using Conveyor.ViewModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
