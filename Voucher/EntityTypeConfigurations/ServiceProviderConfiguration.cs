using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.ToTable("SERVICE_PROVIDER");

            // Id
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();

            // Discriminator
            builder.HasDiscriminator(s => s.Discriminator).HasValue<AccommodationProvider>("AccommodationProvider").HasValue<FoodProvider>("FoodProvider").HasValue<TransportProvider>("TransportProvider");
            builder.Property(s => s.Discriminator).HasMaxLength(100).IsRequired();

            // Airport Iata Code
            builder.Property(s => s.AirportIataCode).HasMaxLength(3).IsRequired();

            // Name
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();

            // Phone
            builder.Property(s => s.Phone).HasMaxLength(20).IsRequired();

            // Email
            builder.Property(s => s.Email).HasMaxLength(150).IsRequired();

            // Address
            builder.Property(s => s.Address).HasMaxLength(300).IsRequired();

            // Active
            builder.Property(s => s.Active).IsRequired();

            // Priority
            builder.Property(s => s.Priority).IsRequired();

            // Distance
            builder.Property(s => s.Distance).IsRequired();

            // Free Text
            builder.Property(s => s.FreeText).HasMaxLength(2000);

            // Created By
            builder.Property(s => s.CreatedBy).HasMaxLength(100);

            // Created Date
            builder.Property(s => s.CreatedDate);

            // Last Modified By
            builder.Property(s => s.LastModifiedBy).HasMaxLength(100);

            // Last Modified Date
            builder.Property(s => s.LastModifiedDate);
        }
    }
}
