﻿using Conveyor.ViewModels.ViewModels;
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

        [HttpGet("{id:int}")]
        public async Task<GetBeltTypeViewModel> GetOne(int id)
        {
            return await _beltTypesService.GetOne(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GetBeltTypeViewModel BeltType)
        {
            var result = await _beltTypesService.Add(BeltType);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] GetBeltTypeViewModel BeltType)
        {
            var result = await _beltTypesService.Update(BeltType);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _beltTypesService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
