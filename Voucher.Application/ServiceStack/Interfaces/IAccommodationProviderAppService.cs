using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IAccommodationProviderAppService
    {
        Task<AccommodationProvider> Insert(AccommodationProviderRequest request);
        Task<AccommodationProviderReponse> Get(long Id);
        Task<IEnumerable<AccommodationProviderReponse>> GetList();
        Task<AccommodationProvider> Delete(long Id);
        Task<AccommodationProvider> Update(AccommodationProviderRequest request);
    }
}
