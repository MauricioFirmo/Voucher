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
    public class EmailController : ControllerBase
    {
        private readonly IEmailAppService _emailAppService;
        public EmailController(IEmailAppService emailAppService)
        {
            _emailAppService = emailAppService;
        }

        [HttpGet]
        public async Task<AccommodationEmailTemplate> Get(int idEmail)
        {
            return await _emailAppService.List(idEmail);
        }

        [HttpGet]
        public async Task<IEnumerable<AccommodationEmailTemplate>> List()
        {
            return await _emailAppService.List();            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long idEmail)
        {
            try
            {
                await _emailAppService.Delete(idEmail);
                return Ok("Email deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(AccommodationEmailTemplate email)
        {
            try
            {
                //AccommodationEmailTemplate email = await _emailAppService.List(idEmail);

                if (ModelState.IsValid)
                {
                    await _emailAppService.Save(email);
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
        public async Task<IActionResult> Create(AccommodationEmailTemplate email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _emailAppService.Create(email);
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
