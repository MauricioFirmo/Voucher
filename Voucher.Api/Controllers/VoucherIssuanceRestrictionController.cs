using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoucherIssuanceRestrictionController : ControllerBase
    {
        private readonly IVoucherIssuanceRestrictionAppService _appService;
        public VoucherIssuanceRestrictionController(IVoucherIssuanceRestrictionAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<VoucherIssuanceRestriction> Get(long id)
        {
            return await _appService.List(id);
        }

        [HttpGet]
        public async Task<IEnumerable<VoucherIssuanceRestriction>> List()
        {
            return await _appService.List();            
        }

        [HttpGet]
        public async Task<IEnumerable<VoucherIssuanceRestriction>> GetList(string Flight, DateTime Date, string DepartureAirport)
        {
            return await _appService.GetList(Flight, Date, DepartureAirport);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _appService.Delete(id);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(VoucherIssuanceRestriction model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _appService.Save(model);
                    return Ok("Alterado com sucesso!");
                }
                else
                {
                    return BadRequest("Modelo inválido!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRange(List<VoucherIssuanceRestriction> model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _appService.SaveRange(model);
                    return Ok("Alterado com sucesso!");
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

        [HttpPost]
        public async Task<IActionResult> Create(List<VoucherIssuanceRestriction> model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _appService.Create(model);
                    return Ok("Inserido com sucesso!");
                }
                else
                {
                    return BadRequest("Modelo inválido!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
