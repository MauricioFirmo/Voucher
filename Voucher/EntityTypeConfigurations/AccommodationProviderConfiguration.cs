using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class AccommodationProviderConfiguration : IEntityTypeConfiguration<AccommodationProvider>
    {
        public void Configure(EntityTypeBuilder<AccommodationProvider> builder)
        {
            // SapCode
            builder.Property(f => f.SapCode);

            // MealPrice
            builder.Property(f => f.MealPrice);

            // MaxPaxPerSahredRoom
            builder.Property(f => f.MaxPaxPerSharedRoom);

            // AccommodationEmailTemplateId and AccommodationTemplate
            builder.HasOne(f => f.AccommodationEmailTemplate)
                   .WithMany()
                   .HasForeignKey(f => f.AccommodationEmailTemplateId).IsRequired(false);

            // Vancancies
            builder.HasMany(f => f.Vacancies)
                   .WithOne(f => f.AccommodationProvider)
                   .HasForeignKey(f => f.AccommodationProviderId);
        }
    }
}
