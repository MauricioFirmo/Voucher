using Voucher.Domain;
using Voucher.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Voucher.Repository.Data
{
    public class RemarksSabreRepository : GenericRepository<RemarksSabre>
    {
        public RemarksSabreRepository(VoucherContext context):base(context)
        {
        }
    }
}
