using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.APP.Models;
using CPMS.BL.Entities;
using CPMS.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : Controller
    {
        private readonly ITimeService _service;
        private readonly IMapper _mapper;

        public TimeController(ITimeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> Get(int id)
        {
            var address = await _service.GetById(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> Get()
        {
            var result = await _service.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("task/{id}")]
        public async Task<ActionResult<IEnumerable<Time>>> GetByTask(int id)
        {
            var result = await _service.GetByTask(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Save([FromBody] TimeModel item)
        {
            try
            {
                var task = _mapper.Map<Time>(item);
                var result = _service.Add(task);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }

        [HttpPut("Edit")]
        public ActionResult Edit([FromBody] Time item)
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