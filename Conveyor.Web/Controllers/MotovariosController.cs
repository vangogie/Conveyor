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
    }
}
