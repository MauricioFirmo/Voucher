using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.DTO
{
    public class GetPassengerListRQDTO
    {
        public string arrivalTimeField { get; set; }
        public string departureTimeField { get; set; }
        public string estimated_ArrivalDateField { get; set; }
        public string estimated_DepartureDateField { get; set; }
        public string scheduled_ArrivalDateField { get; set; }
        public string scheduled_DepartureDateField { get; set; }
        public string aircraftTypeField { get; set; }
        public string destinationField { get; set; }
        public string originField { get; set; }
        public List<PassengerInfoList> PassengerInfo { get; set; }
    }
}
