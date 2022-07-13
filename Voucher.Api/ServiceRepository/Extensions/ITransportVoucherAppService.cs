using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.Extensions
{
    public interface ITransportVoucherAppService
    {
        Task<TransportVoucher> Insert(TransportVoucherRequest request);
        Task<TransportVoucher> Get(long Id);
        Task<IEnumerable<TransportVoucher>> GetList();
        Task<TransportVoucher> Delete(long Id);
        Task<TransportVoucher> Update(TransportVoucherRequest request);
        Task<Result> InsertRange(List<TransportVoucher> model);
    }
}
