using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class FoodVoucherConfiguration : IEntityTypeConfiguration<FoodVoucher>
    {
        public void Configure(EntityTypeBuilder<FoodVoucher> builder)
        {
        }
    }
}
