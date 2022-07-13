using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class AccommodationEmailTemplateConfiguration : IEntityTypeConfiguration<AccommodationEmailTemplate>
    {
        public void Configure(EntityTypeBuilder<AccommodationEmailTemplate> builder)
        {
            builder.ToTable("ACCOMMODATION_EMAIL_TEMPLATE");

            // Id
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();

            // Language
            builder.Property(f => f.Language).IsRequired();

            // Subject
            builder.Property(f => f.Subject).HasMaxLength(250);

            // Body
            builder.Property(f => f.Body);
        }
    }
}
