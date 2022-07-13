using Voucher.Domain;
using Voucher.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Repository.Data
{
    public class EmailRepository : GenericRepository<AccommodationEmailTemplate>
    {
        public EmailRepository(VoucherContext context):base(context)
        {
        }
    }
}
