using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface ITransportProviderAppService
    {
        Task<TransportProvider> Insert(TransportProviderRequest request);
        Task<TransportProvider> Get(long Id);
        Task<IEnumerable<TransportProvider>> GetList();
        Task<IEnumerable<TransportProvider>> GetListByIataCode(string AirportIataCode, string Name);
        Task<TransportProvider> Delete(long Id);
        Task<TransportProvider> Update(TransportProviderRequest request);
    }
}
