using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IAccommodationVacancyAppService
    {
        Task<AccommodationVacancy> Insert(AccommodationVacancy request);
        Task<AccommodationVacancy> Get(object[] compositeKey);
        Task<IEnumerable<AccommodationVacancy>> GetList();
        Task<IEnumerable<AccommodationVacancy>> GetListOrderbyProvider();
        Task<AccommodationVacancy> Delete(object[] compositeKey);
        Task<AccommodationVacancy> Update(AccommodationVacancy request);
        Task<List<AccommodationVacancy>> GetListByProvider(long idProvider);
    }
}
