using Voucher.Api.ServiceRepository;
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
    public class AccommodationVoucherController : ControllerBase
    {
        private readonly IAccommodationVoucherAppService _accommodationVoucherAppService;

        public AccommodationVoucherController(IAccommodationVoucherAppService accommodationVoucherAppService)
        {
            _accommodationVoucherAppService = accommodationVoucherAppService;
        }

        [HttpPost]
        public ActionResult<string> GetEmailBody(AccommodationVoucher voucher)
        {
            try
            {
                return _accommodationVoucherAppService.AcomodationEmail(voucher);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public async Task<ActionResult<AccommodationVoucher>> Insert([FromBody] AccommodationVoucherRequest request)
        {
            try
            {
                return await _accommodationVoucherAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertRange(List<AccommodationVoucherRequest> modelList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _accommodationVoucherAppService.InsertRange(modelList);
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


    //try
    //{
    //    return await _accommodationVoucherAppService.InsertRange(modelList);
    //}
    //catch (Exception ex)
    //{
    //    throw ex;
    //}



        [HttpGet]
        public async Task<ActionResult<AccommodationVoucher>> Get(long Id)
        {
            try
            {
                return await _accommodationVoucherAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<AccommodationVoucher>> GetList()
        {
            try
            {
                return await _accommodationVoucherAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<AccommodationVoucher>> Delete(long Id)
        {
            try
            {
                return await _accommodationVoucherAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<AccommodationVoucher>> Update([FromBody] AccommodationVoucherRequest request)
        {
            try
            {
                return await _accommodationVoucherAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
