using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetBackendTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeFeatureEntitiesController : ControllerBase
    {
        ISomeFeatureEntityService _someFeatureEntityService;

        public SomeFeatureEntitiesController(ISomeFeatureEntityService someFeatureEntityService)
        {
            _someFeatureEntityService = someFeatureEntityService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _someFeatureEntityService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(SomeFeatureEntity someFeatureEntity)
        {
            var result = _someFeatureEntityService.Add(someFeatureEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SomeFeatureEntity someFeatureEntity)
        {
            var result = _someFeatureEntityService.Update(someFeatureEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SomeFeatureEntity someFeatureEntity)
        {
            var result = _someFeatureEntityService.Delete(someFeatureEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

