using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class TransportVoucher : Voucher
    {
        public DateTime? DateTransport { get; set; }
        public TransportStatus TransportStatus { get; set; }
    }
}
