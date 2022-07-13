using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class TransportProviderConfiguration : IEntityTypeConfiguration<TransportProvider>
    {
        public void Configure(EntityTypeBuilder<TransportProvider> builder)
        {
            // Price
           
            builder.Property(f => f.Price).IsRequired();

            // Transport Type
            builder.Property(f => f.TransportType).IsRequired();
        }
    }
}
