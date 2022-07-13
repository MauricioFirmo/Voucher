using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class AccommodationVoucherConfiguration : IEntityTypeConfiguration<AccommodationVoucher>
    {
        public void Configure(EntityTypeBuilder<AccommodationVoucher> builder)
        {
            // RoomId
            builder.Property(f => f.RoomId);

            // RoomType
            builder.Property(f => f.RoomType);

            // DailyAmount
            builder.Property(f => f.DailyAmount);
        }
    }
}
