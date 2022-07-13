using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.DTO
{
    public class PassengerInfoList
    {
        public string TicketNumber { get; set; }
        public BoardingInfoField BoardingInfo { get; set; }
        public CheckInInfoField CheckInInfo { get; set; }
        public NameDetailsField NameDetails { get; set; }
        public PNRLocatorField PNRLocator { get; set; }
    }
}
