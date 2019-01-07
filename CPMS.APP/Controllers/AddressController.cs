using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AddressController : Controller
    {
        private readonly IAddressService _service;
        private readonly IMapper _mapper;

        public AddressController(IAddressService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var address = await _service.GetById(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public ActionResult SaveAddress([FromBody] AddressModel item)
        {
            try
            {
                var address = _mapper.Map<Address>(item);
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
        public ActionResult Edit([FromBody] Address item)
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

    }
}
