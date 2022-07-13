using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class TransportVoucherConfiguration : IEntityTypeConfiguration<TransportVoucher>
    {
        public void Configure(EntityTypeBuilder<TransportVoucher> builder)
        {
            // Date Transport
            builder.Property(f => f.DateTransport);

            // Transport Status
            builder.Property(f => f.TransportStatus);
        }
    }
}
