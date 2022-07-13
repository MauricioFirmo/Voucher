using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecialServiceController : ControllerBase
    {
        private readonly ISpecialServiceAppService _specialServiceAppService;

        public SpecialServiceController(ISpecialServiceAppService specialServiceAppService)
        {
            _specialServiceAppService = specialServiceAppService;
        }

        [HttpPost]
        public async Task<ActionResult<SpecialService>> Insert([FromBody] SpecialService request)
        {
            try
            {
                return await _specialServiceAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<SpecialService>> Get(long Id)
        {
            try
            {
                return await _specialServiceAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<SpecialService>> GetList()
        {
            try
            {
                return await _specialServiceAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<SpecialService>> Delete(long Id)
        {
            try
            {
                return await _specialServiceAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<SpecialService>> Update([FromBody] SpecialService request)
        {
            try
            {
                return await _specialServiceAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
