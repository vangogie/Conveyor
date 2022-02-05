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
    public class MotovariosController : ControllerBase
    {
        public readonly IMotovariosService _motovariosService;
        public MotovariosController(IMotovariosService motovariosService)
        {
            _motovariosService = motovariosService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetMotovarioViewModel>> Get()
        {
            return await _motovariosService.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<GetMotovarioViewModel> GetOne(int id)
        {
            var engine = await _motovariosService.GetOne(id);
            return engine;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostMotovarioViewModel MotovarioModel)
        {
            var result = await _motovariosService.Post(MotovarioModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] GetMotovarioViewModel sewModel)
        {
            var result = await _motovariosService.Update(sewModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _motovariosService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
