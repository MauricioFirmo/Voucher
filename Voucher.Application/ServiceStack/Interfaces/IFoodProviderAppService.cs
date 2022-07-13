using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IFoodProviderAppService
    {
        Task<FoodProvider> Insert(FoodProviderRequest request);
        Task<FoodProvider> Get(long Id);
        Task<IEnumerable<FoodProvider>> GetList();
        Task<IEnumerable<FoodProvider>> GetListByIataCode(string AirportIataCode, string Name);
        Task<FoodProvider> Delete(long Id);
        Task<FoodProvider> Update(FoodProviderRequest request);
    }
}
