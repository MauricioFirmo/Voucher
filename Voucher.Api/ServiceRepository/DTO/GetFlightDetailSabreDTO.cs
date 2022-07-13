using Voucher.Domain;
using SabreFlightDetailRQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.DTO
{
    public class GetFlightDetailSabreDTO
    {
        public string ShareCode { get; set; }
        public ACS_FlightDetailRSACS ACS_FlightDetailRSACS { get; set; }
        public List<PassengerRemarks> PassengerList { get; set; }
    }
}
