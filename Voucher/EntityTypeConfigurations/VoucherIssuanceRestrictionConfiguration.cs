using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class VoucherIssuanceRestrictionConfiguration : IEntityTypeConfiguration<VoucherIssuanceRestriction>
    {
        public void Configure(EntityTypeBuilder<VoucherIssuanceRestriction> builder)
        {
            builder.ToTable("VOUCHER_ISSUANCE_RESTRICTION");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();

            builder.Property(f => f.SabreId).HasMaxLength(100);

            builder.Property(f => f.FlightNumber).HasMaxLength(6);

            builder.Property(f => f.STD);

            builder.Property(f => f.STA);

            //builder.Property(f => f.International).IsRequired();

            builder.Property(f => f.DepartureAirport).HasMaxLength(3).IsRequired();

            builder.Property(f => f.ArrivalAirport).HasMaxLength(3).IsRequired();

            builder.Property(f => f.RestrictionType).IsRequired();

            builder.Property(f => f.USERNAME);

            builder.Property(f => f.AUTHORIZED);

            builder.Property(f => f.UPDATEDATE);


        }
    }
}
