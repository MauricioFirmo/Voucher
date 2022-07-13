using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Voucher.Api.Controllers
{

    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccommodationVacancyController : ControllerBase
    {
        private readonly IAccommodationVacancyAppService _AccVacancyDAL;
        
        public AccommodationVacancyController(IAccommodationVacancyAppService AccVacancyDAL)
        {
            _AccVacancyDAL = AccVacancyDAL;
        }

        [HttpGet]
        public async Task<AccommodationVacancy> Get(long idAccProvider, DateTime DateTime)
        {
            object[] compositeKey = new object[] { idAccProvider, DateTime };

            return await _AccVacancyDAL.Get(compositeKey);
        }

        [HttpGet]
        public async Task<List<AccommodationVacancy>> GetListByProvider(long idAccProvider)
        {
            return  await _AccVacancyDAL.GetListByProvider(idAccProvider);
        }

        [HttpGet]
        public async Task<IEnumerable<AccommodationVacancy>> GetListOrderbyProvider()
        {
            try
            {
                return await _AccVacancyDAL.GetListOrderbyProvider();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<AccommodationVacancy>> List()
        {
            return await _AccVacancyDAL.GetList();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long idAccProvider, DateTime DateTime)
        {
            try
            {
                object[] compositeKey = new object[] { idAccProvider, DateTime };
                await _AccVacancyDAL.Delete(compositeKey);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Save(long AccommodationProviderId, DateTime DateTime, int Vacancies)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AccommodationVacancy accVacancy = new AccommodationVacancy
                    {
                        AccommodationProviderId = AccommodationProviderId,
                        DateTime = DateTime,
                        Vacancies = Vacancies
                    };

                    await _AccVacancyDAL.Update(accVacancy);
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
        public async Task<IActionResult> Create(long AccommodationProviderId, DateTime DateTime, int Vacancies )
        {
            try
            {
                AccommodationVacancy accVacancy = new AccommodationVacancy
                {
                    AccommodationProviderId = AccommodationProviderId,
                    DateTime = DateTime,
                    Vacancies = Vacancies
                };

                if (ModelState.IsValid)
                {
                    await _AccVacancyDAL.Insert(accVacancy);
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
