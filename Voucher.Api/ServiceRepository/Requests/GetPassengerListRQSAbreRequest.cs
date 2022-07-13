using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.Requests
{
    public class GetPassengerListRQSAbreRequest
    {
        public string[] codeList { get; set; }
        public string strAirline { get; set; }
        public string strFilght { get; set; }
        public string departureDate { get; set; }
        public string strOrigin { get; set; }
        public bool hasFilter { get; set; }
        public string filterType { get; set; }
    }
}
