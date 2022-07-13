using Voucher.Domain;
using Voucher.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Repository.Data
{
    public class AirportRepository : GenericRepository<Airports>
    {
        public AirportRepository (VoucherContext context):base(context)
        {
        }
    }
}
