using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPMS.BL.Services;
using AutoMapper;
using CPMS.APP.Models;
using CPMS.BL.Entities;

namespace CPMS.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var result = await _service.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var result = await _service.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult SaveAddress([FromBody] CustomerModel item)
        {
            try
            {
                var address = _mapper.Map<Customer>(item);
                var result = _service.Add(address);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }

        [HttpPut("Edit")]
        public ActionResult Edit([FromBody] Customer item)
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
