using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class FoodProviderConfiguration : IEntityTypeConfiguration<FoodProvider>
    {
        public void Configure(EntityTypeBuilder<FoodProvider> builder)
        {
            // Price
            builder.Property(f => f.Price);

            // MealType
            builder.Property(f => f.MealType);
        }
    }
}
