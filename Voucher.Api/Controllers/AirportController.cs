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
    public class AirportController : ControllerBase
    {
        private readonly IAirportAppService _airportAppService;
        public AirportController(IAirportAppService airportAppService)
        {
            _airportAppService = airportAppService;
        }

        //[HttpGet]
        //public async Task<Airports> Get(int idAirport)
        //{
        //    return await _airportAppService.List(idAirport);
        //}

        [HttpGet]
        public async Task<IEnumerable<Airports>> GetList()
        {
            return await _airportAppService.GetList();
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(long idEmail)
        //{
        //    try
        //    {
        //        await _airportAppService.Delete(idEmail);
        //        return Ok("Email deletado com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro: {ex.Message}");
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> Update(Airports airport)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _airportAppService.Save(airport);
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

        [HttpPost]
        public async Task<IActionResult> Create(Airports airport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _airportAppService.Create(airport);
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
