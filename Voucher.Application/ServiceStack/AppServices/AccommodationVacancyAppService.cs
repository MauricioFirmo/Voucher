using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using Voucher.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{


    public class AccommodationVacancyAppService : IAccommodationVacancyAppService

    {
        private readonly AccommodationVacancyRepository _accommodationVacancyRepository;
        private readonly AccommodationProviderRepository _accommodationProviderRepository;
        private readonly VoucherContext _context;

        public AccommodationVacancyAppService(AccommodationVacancyRepository accommodationVacancyRepository,
                                              VoucherContext context,
                                              AccommodationProviderRepository accommodationProviderRepository)
        {
            _accommodationVacancyRepository = accommodationVacancyRepository;
            _context = context;
            _accommodationProviderRepository = accommodationProviderRepository;
        }

        public async Task<AccommodationVacancy> Delete(object[] compositeKey)
        {
            try
            {
                await _accommodationVacancyRepository.Delete(compositeKey);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVacancy> Get(object[] compositeKey)
        {
            try
            {
                return await _accommodationVacancyRepository.List(compositeKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationVacancy>> GetList()
        {
            try
            {
                return await _accommodationVacancyRepository.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationVacancy>> GetListOrderbyProvider()
        {
            try
            {
                IEnumerable<AccommodationVacancy> vacancy = await _accommodationVacancyRepository.List();
                
                foreach (AccommodationVacancy item in vacancy)
                {
                    item.AccommodationProvider = await _accommodationProviderRepository.Get(item.AccommodationProviderId); 
                }

                return vacancy.OrderBy(v => v.AccommodationProvider.Priority);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVacancy> Insert(AccommodationVacancy request)
        {
            try
            {
                await _accommodationVacancyRepository.Insert(request);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVacancy> Update(AccommodationVacancy request)
        {
            try
            {
                await _accommodationVacancyRepository.Update(request);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<AccommodationVacancy>> GetListByProvider(long idProvider)
        {
            try
            {
                //Join para trazer a propriedade de navegação
                return await _context.AccommodationVacancies.Where
                    (p => p.AccommodationProviderId == idProvider).Include(p=>p.AccommodationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
