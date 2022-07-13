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
    public class RemarksSabreController : ControllerBase
    {
        private readonly IRemarksSabreAppService _appService;
        public RemarksSabreController(IRemarksSabreAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<RemarksSabre> Get(int id)
        {
            return await _appService.List(id);
        }

        //[HttpGet]
        //public async Task<IEnumerable<RemarksSabre>> List()
        //{
        //    return await _appService.List();            
        //}

        [HttpDelete]
        public async Task<IActionResult> Delete(long idEmail)
        {
            try
            {
                await _appService.Delete(idEmail);
                return Ok("Email deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RemarksSabre email)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _appService.Save(email);
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

        [HttpPut]
        public async Task<IActionResult> Save(RemarksSabre email)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _appService.Save(email);
                    return Ok("Email alterado com sucesso!");
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
        public async Task<IActionResult> Create(RemarksSabre email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _appService.Create(email);
                    return Ok("Email inserido com sucesso!");
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
