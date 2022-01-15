using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conveyor.ViewModels.ViewModels;
using Conveyor.Business.Services.Interfaces;
using Conveyor.ViewModels.ViewModels;

namespace Conveyor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SewsController : ControllerBase
    {
        public readonly ISewsService _sewsService;
        public SewsController(ISewsService appartmentService)
        {
            _sewsService = appartmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetSewViewModel>> Get()
        {
            return await _sewsService.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<GetSewViewModel> GetOne(int id)
        {
             var engine = await _sewsService.GetOne(id);
            return engine;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostSewViewModel sewModel)
        {
            var result = await _sewsService.Post(sewModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] GetSewViewModel sewModel)
        {
            var result = await _sewsService.Update(sewModel);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sewsService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
