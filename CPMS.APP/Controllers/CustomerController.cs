using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ActionResult SaveAddress([FromBody] CustomerModel item)
        {
            try
            {
                var result = _mapper.Map<Customer>(item);
                _service.Add(result);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }
    }
}
