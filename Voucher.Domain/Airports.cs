using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class Airports
    {
        public long ID { get; set; }
        public string? IATACODE { get; set; }
        public string? NAME { get; set; }
        public string? SHORTNAME { get; set; }
        public string? ICAOCODE { get; set; }
        public string? TIMEZONECODE { get; set; }
        public string? LATITUDE { get; set; }
        public string? LONGITUDE { get; set; }
        public string? COUNTRYCODE { get; set; }
        public bool BASESATIVASOPERADASGOL { get; set; }

    }
}
