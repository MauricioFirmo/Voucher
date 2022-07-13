using Voucher.Api.ServiceRepository.Extensions;
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
    public class FoodVoucherController : ControllerBase
    {
        private readonly IFoodVoucherAppService _foodVoucherAppService;

        public FoodVoucherController(IFoodVoucherAppService foodVoucherAppService)
        {
            _foodVoucherAppService = foodVoucherAppService;
        }

        [HttpPost]
        public async Task<ActionResult<FoodVoucher>> Insert([FromBody] FoodVoucherRequest request)
        {
            try
            {
                return await _foodVoucherAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertRange(List<FoodVoucherRequest> modelList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _foodVoucherAppService.InsertRange(modelList);
                    return Ok("Inserido com sucesso!");
                }
                else
                {
                    return BadRequest("Modelo inválido!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<FoodVoucher>> Get(long Id)
        {
            try
            {
                return await _foodVoucherAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<FoodVoucher>> GetList()
        {
            try
            {
                return await _foodVoucherAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<FoodVoucher>> Delete(long Id)
        {
            try
            {
                return await _foodVoucherAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<FoodVoucher>> Update([FromBody] FoodVoucherRequest request)
        {
            try
            {
                return await _foodVoucherAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
