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
    public class TransportVoucherController : ControllerBase
    {
        private readonly ITransportVoucherAppService _transportVoucherAppService;

        public TransportVoucherController(ITransportVoucherAppService transportVoucherAppService)
        {
            _transportVoucherAppService = transportVoucherAppService;
        }

        [HttpPost]
        public async Task<ActionResult<TransportVoucher>> Insert([FromBody] TransportVoucherRequest request)
        {
            try
            {
                return await _transportVoucherAppService.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertRange(List<TransportVoucher> modelList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _transportVoucherAppService.InsertRange(modelList);
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
        public async Task<ActionResult<TransportVoucher>> Get(long Id)
        {
            try
            {
                return await _transportVoucherAppService.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<TransportVoucher>> GetList()
        {
            try
            {
                return await _transportVoucherAppService.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult<TransportVoucher>> Delete(long Id)
        {
            try
            {
                return await _transportVoucherAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<TransportVoucher>> Update([FromBody] TransportVoucherRequest request)
        {
            try
            {
                return await _transportVoucherAppService.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
