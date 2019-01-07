using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMS.BL.Services;
using AutoMapper;
using CPMS.APP.Models;
using CPMS.BL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CPMS.APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _service;
        private readonly IMapper _mapper;

        public DeveloperController(IDeveloperService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> Get(int id)
        {
            var result = await _service.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> Get()
        {
            var result = await _service.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpPost]
        public ActionResult Save([FromBody] DeveloperModel item)
        {
            try
            {
                var developer = _mapper.Map<Developer>(item);
                var result = _service.Add(developer, item.Password);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }
        
        [HttpPost("Authenticate")]
        public ActionResult Auth([FromBody] AuthModel item)
        {
            try
            {
                var result = _service.Authenticate(item.UserName, item.Password);
                if (result == null)
                {
                    return BadRequest();
                }
                    
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }

        [HttpPut("Edit")]
        public ActionResult Edit([FromBody] Developer item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            try
            {
                _service.Update(item);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }
    }
}
