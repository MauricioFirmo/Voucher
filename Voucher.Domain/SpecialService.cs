using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class SpecialService
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<AccommodationProviderSpecialService> AccommodationProviderSpecialServices { get; set; }
    }
}
