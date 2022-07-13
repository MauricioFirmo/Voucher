using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class VoucherIssuanceRestriction
    {
        public long Id { get; set; }
        public string SabreId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime STD { get; set; }
        public DateTime STA { get; set; }
        //public bool International { get; set; } 
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public VoucherType RestrictionType { get; set; }
        public string USERNAME { get; set;}
        public bool? AUTHORIZED { get; set; }
        public DateTime UPDATEDATE { get; set; }

    }
}
