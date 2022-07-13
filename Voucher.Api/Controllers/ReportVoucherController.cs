using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportVoucherController : ControllerBase
    {
        private readonly IReportVoucherAppService _reportVoucherAppService;
        
        public ReportVoucherController(IReportVoucherAppService reportVoucherAppService)
        {
            _reportVoucherAppService = reportVoucherAppService;
        }


        [HttpGet]
        public async Task<IEnumerable<ReportVoucherResponse>> GetListReport(string AirportIataCode, DateTime FinalPeriod, DateTime FirstPeriod, string Flight, StatusType Status)
        {
            try
            {
                ReportVoucherRequest request = new ReportVoucherRequest
                {
                    AirportIataCode = AirportIataCode,
                    FinalPeriod = FinalPeriod,
                    FirstPeriod = FirstPeriod,
                    Flight = Flight,
                    Status = Status
                };

                return await _reportVoucherAppService.GetListReport(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
