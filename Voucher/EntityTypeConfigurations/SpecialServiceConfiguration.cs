using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class SpecialServiceConfiguration : IEntityTypeConfiguration<SpecialService>
    {
        public void Configure(EntityTypeBuilder<SpecialService> builder)
        {
            builder.ToTable("SPECIAL_SERVICE");

            // ID
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();

            // NAME
            builder.Property(f => f.Name).HasMaxLength(50).IsRequired();
        }
    }
}
