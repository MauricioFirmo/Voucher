using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class AccommodationVoucher : Voucher
    {
        public Guid RoomId { get; set; }
        public RoomType RoomType { get; set; }
        public long DailyAmount { get; set; }
    }
}
