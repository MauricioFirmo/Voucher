using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class PassengerRemarks
    {
        public string PassengerId { get; set; }
        public long FlightId { get; set; }
        public string PassengeNumber { get; set; }
        public string Nome { get; set; }
        public string PNR { get; set; }
        public string Emitido { get; set; }
        public string FlightNumber { get; set; }
        public string Remarks { get; set; }
    }
}
