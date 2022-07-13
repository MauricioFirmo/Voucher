using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class TransportProvider : ServiceProvider
    {
        public decimal Price { get; set; }
        public TransportType TransportType { get; set; }
    }
}
