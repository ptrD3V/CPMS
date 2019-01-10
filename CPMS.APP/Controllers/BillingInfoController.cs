using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CPMS.BL.Services;
using AutoMapper;
using CPMS.APP.Models;
using CPMS.BL.Entities;

namespace CPMS.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInfoController : Controller
    {
        private readonly IBillingInfoService _service;
        private readonly IMapper _mapper;

        public BillingInfoController(IBillingInfoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillingInfo>> Get(int id)
        {
            var result = await _service.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult SaveAddress([FromBody] BillingInfoModel item)
        {
            try
            {
                var billingInfo = _mapper.Map<BillingInfo>(item);
                var result = _service.Add(billingInfo);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }

        [HttpPut("Edit")]
        public ActionResult Edit([FromBody] BillingInfo item)
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
