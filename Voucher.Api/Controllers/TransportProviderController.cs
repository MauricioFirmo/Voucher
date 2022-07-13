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
    public class TransportProviderController : ControllerBase
    {
        private readonly ITransportProviderAppService _transportProviderAppService;

        public TransportProviderController(ITransportProviderAppService transportProviderAppService)
        {
            _transportProviderAppService = transportProviderAppService;
        }

        [HttpPost]
        public async Task<ActionResult<TransportProvider>> Insert([FromBody] TransportProviderRequest request)
        {
            try
            {
                return await _transportProviderAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<TransportProvider>> Get(long Id)
        {
            try
            {
                return await _transportProviderAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<TransportProvider>> GetList()
        {
            try
            {
                return await _transportProviderAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<TransportProvider>> GetListByIataCode(string AirportIataCode, string Name)
        {
            try
            {
                return await _transportProviderAppService.GetListByIataCode(AirportIataCode, Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<TransportProvider>> Delete(long Id)
        {
            try
            {
                return await _transportProviderAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<TransportProvider>> Update([FromBody] TransportProviderRequest request)
        {
            try
            {
                return await _transportProviderAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
