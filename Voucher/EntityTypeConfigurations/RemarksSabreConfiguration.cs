using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class RemarksSabreConfiguration : IEntityTypeConfiguration<RemarksSabre>
    {
        public void Configure(EntityTypeBuilder<RemarksSabre> builder)
        {
            builder.ToTable("REMARKS_SABRE");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();

            builder.Property(f => f.dtInsert).IsRequired();

            builder.Property(f => f.Remark).HasMaxLength(2000).IsRequired();

            builder.Property(f => f.Username).HasMaxLength(250).IsRequired();

            // Voucher And VoucherId
            builder.HasOne(f => f.Voucher)
                   .WithMany()
                   .HasForeignKey(f => f.VoucherId).IsRequired(false);

            // Flight And FlightId
            builder.HasOne(f => f.Flight)
                   .WithMany()
                   .HasForeignKey(f => f.FlightId).IsRequired(false);

            // Passenger And PassengerId
            builder.HasOne(f => f.Passenger)
                   .WithMany()
                   .HasForeignKey(f => f.PassengerId).IsRequired(false);
        }
    }
}
