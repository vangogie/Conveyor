using Conveyor.ViewModels.ViewModels;
using Conveyor.Business.Services.Interfaces;
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
    public class BeltTypesController : ControllerBase
    {
        public readonly IBeltTypesService _beltTypesService;
        public BeltTypesController(IBeltTypesService beltTypesService)
        {
            _beltTypesService = beltTypesService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetBeltTypeViewModel>> Get()
        {
            return await _beltTypesService.Get();
        }
    }
}
