using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class Flight
    {
        public long Id { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime STD { get; set; }
        public DateTime STA { get; set; }
        public string FlightNumber { get; set; }
        public string CarrierCode { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<Voucher> Vouchers { get; set; }
    }
}
