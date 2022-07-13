using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Application.DTO
{
    public class ReportVoucherRequest
    {
        public string AirportIataCode { get; set;}
        public DateTime FirstPeriod { get; set; }
        public DateTime FinalPeriod { get; set; }
        public string Flight { get; set; }
        public StatusType Status { get; set; }
    }
}
