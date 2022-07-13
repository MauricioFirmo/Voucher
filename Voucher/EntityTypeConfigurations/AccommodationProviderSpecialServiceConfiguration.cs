using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class AccommodationProviderSpecialServiceConfiguration : IEntityTypeConfiguration<AccommodationProviderSpecialService>
    {
        public void Configure(EntityTypeBuilder<AccommodationProviderSpecialService> builder)
        {
            builder.ToTable("ACCOMMODATION_PROVIDER_SPECIAL_SERVICE");

            // Key
            builder.HasKey(f => new { f.AccommodationProviderId, f.SpecialServiceId });

            // First Column
            builder.HasOne(f => f.AccommodationProvider)
                   .WithMany(f => f.AccommodationProviderSpecialServices)
                   .HasForeignKey(f => f.AccommodationProviderId);

            // Second Column
            builder.HasOne(f => f.SpecialService)
                   .WithMany(f => f.AccommodationProviderSpecialServices)
                   .HasForeignKey(f => f.SpecialServiceId);
        }
    }
}
