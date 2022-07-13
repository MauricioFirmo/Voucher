using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.Extensions
{
    public interface IFoodVoucherAppService
    {
        Task<FoodVoucher> Insert(FoodVoucherRequest request);
        Task<FoodVoucher> Get(long Id);
        Task<IEnumerable<FoodVoucher>> GetList();
        Task<FoodVoucher> Delete(long Id);
        Task<FoodVoucher> Update(FoodVoucherRequest request);
        Task<Result> InsertRange(List<FoodVoucherRequest> modelList);
    }
}
