﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.Requests
{
    public class GetFlightDetailSabreRequest
    {
        public string Airline { get; set; }
        public string Flight { get; set; }
        public string Origin { get; set; }
        public string DepartureDate { get; set; }
    }
}
