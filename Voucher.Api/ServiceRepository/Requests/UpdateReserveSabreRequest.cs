using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.Requests
{
    public class UpdateReserveSabreRequest
    {
        public string pnr { get; set; }
        public string comments { get; set; }

    }
}
