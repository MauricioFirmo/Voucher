using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Http;
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
    public class FoodProviderController : ControllerBase
    {
        private readonly IFoodProviderAppService _foodProviderAppService;

        public FoodProviderController(IFoodProviderAppService foodProviderAppService)
        {
            _foodProviderAppService = foodProviderAppService;
        }

        [HttpPost]
        public async Task<ActionResult<FoodProvider>> Insert([FromBody] FoodProviderRequest request)
        {
            try
            {
                return await _foodProviderAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<FoodProvider>> Get(long Id)
        {
            try
            {
                return await _foodProviderAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<FoodProvider>> GetList()
        {
            try
            {
                return await _foodProviderAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<FoodProvider>> GetListByIataCode(string AirportIataCode, string Name)
        {
            try
            {
                return await _foodProviderAppService.GetListByIataCode(AirportIataCode, Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<FoodProvider>> Delete(long Id)
        {
            try
            {
                return await _foodProviderAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<FoodProvider>> Update([FromBody] FoodProviderRequest request)
        {
            try
            {
                return await _foodProviderAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
