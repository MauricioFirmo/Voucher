using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.DTO
{
    public class CheckInInfoField
    {
        public string checkInNumberField { get; set; }
        public bool checkInNumberFieldSpecified { get; set; }
        public bool checkInStatusField { get; set; }
        public bool checkInStatusFieldSpecified { get; set; }
    }
}
