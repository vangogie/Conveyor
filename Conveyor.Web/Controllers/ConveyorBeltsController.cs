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
    public class ConveyorBeltsController : ControllerBase
    {
        public readonly IConveyorBeltsService _conveyorBeltsService;
        public ConveyorBeltsController(IConveyorBeltsService conveyorBeltsService)
        {
            _conveyorBeltsService = conveyorBeltsService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetConveyorBeltViewModel>> Get()
        {
            return await _conveyorBeltsService.Get();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostConveyorBeltViewModel BeltModel)
        {
            var result = await _conveyorBeltsService.Post(BeltModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
