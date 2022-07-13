using Voucher.Application.DTO;
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
    public class AccommodationProviderController : ControllerBase
    {
        private readonly IAccommodationProviderAppService _accommodationProviderAppService;

        public AccommodationProviderController(IAccommodationProviderAppService accommodationProviderAppService)
        {
            _accommodationProviderAppService = accommodationProviderAppService;
        }

        [HttpPost]
        public async Task<ActionResult<AccommodationProvider>> Insert([FromBody] AccommodationProviderRequest request)
        {
            try
            {
                return await _accommodationProviderAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<AccommodationProviderReponse>> Get(long Id)
        {
            try
            {
                return await _accommodationProviderAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<AccommodationProviderReponse>> GetList()
        {
            try
            {
                return await _accommodationProviderAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<AccommodationProvider>> Delete(long Id)
        {
            try
            {
                return await _accommodationProviderAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<AccommodationProvider>> Update([FromBody] AccommodationProviderRequest request)
        {
            try
            {
                return await _accommodationProviderAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
