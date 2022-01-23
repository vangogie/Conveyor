using Conveyor.Business.Services.Interfaces;
using Conveyor.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("{id:int}")]
        public async Task<GetConveyorBeltViewModel> GetOne(int id)
        {
            return await _conveyorBeltsService.GetOne(id);
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

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] GetConveyorBeltViewModel BeltModel)
        {
            var result = await _conveyorBeltsService.Update(BeltModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _conveyorBeltsService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
