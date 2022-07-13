using Voucher.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IReportVoucherAppService
    {
        Task<IEnumerable<ReportVoucherResponse>> GetListReport(ReportVoucherRequest request);
    }
}
