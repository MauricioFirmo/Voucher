using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class AccommodationProviderSpecialService
    {
        public long AccommodationProviderId { get; set; }
        public AccommodationProvider AccommodationProvider { get; set; }
        public long SpecialServiceId { get; set; }
        public SpecialService SpecialService { get; set; }
    }
}
