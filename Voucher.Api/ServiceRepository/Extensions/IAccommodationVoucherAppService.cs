using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.Extensions
{
    public interface IAccommodationVoucherAppService
    {
        Task<AccommodationVoucher> Insert(AccommodationVoucherRequest request);
        Task<AccommodationVoucher> Get(long Id);
        Task<IEnumerable<AccommodationVoucher>> GetList();
        Task<AccommodationVoucher> Delete(long Id);
        Task<AccommodationVoucher> Update(AccommodationVoucherRequest request);
        Task<Result> InsertRange(List<AccommodationVoucherRequest> modelList);
        string AcomodationEmail(AccommodationVoucher voucher);
    }
}
