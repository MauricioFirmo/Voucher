using Voucher.Domain;
using Voucher.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Repository.Data
{
    public class VoucherIssuanceRestrictionRepository : GenericRepository<VoucherIssuanceRestriction>
    {
        public VoucherIssuanceRestrictionRepository(VoucherContext context):base(context)
        {
        }
    }
}
