﻿using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Domain.Voucher>
    {
        public void Configure(EntityTypeBuilder<Domain.Voucher> builder)
        {
            builder.ToTable("VOUCHER");

            // Id
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();

            // Discriminator
            builder.HasDiscriminator(s => s.Discriminator).HasValue<AccommodationVoucher>("AccommodationVoucher").HasValue<FoodVoucher>("FoodVoucher").HasValue<TransportVoucher>("TransportVoucher");
            builder.Property(s => s.Discriminator).HasMaxLength(100).IsRequired();

            // IsActive
            builder.Property(s => s.IsActive).IsRequired();

            // Free Text
            builder.Property(s => s.FreeText).HasMaxLength(2000);

            // Created By
            builder.Property(s => s.CreatedBy).HasMaxLength(100);

            // Canceled By
            builder.Property(s => s.CanceledBy).HasMaxLength(100);

            // Created Date
            builder.Property(s => s.CreatedDate).IsRequired();

            // Canceled Date
            builder.Property(s => s.CanceledDate);

            // Flight And FlightId
            builder.HasOne(f => f.Flight)
                   .WithMany()
                   .HasForeignKey(f => f.FlightId).IsRequired(false);

            // Printed Date
            builder.Property(s => s.PrintedDate).IsRequired();

            // Pseudo City Code
            builder.Property(s => s.PseudoCityCode).IsRequired();

            // ServiceProvider AndServiceProvider Id
            builder.HasOne(f => f.ServiceProvider)
                   .WithMany()
                   .HasForeignKey(f => f.ServiceProviderId).IsRequired(false);

            // ValidUntil
            builder.Property(s => s.ValidUntil).IsRequired();

            // Passenger And PassengerId
            builder.HasOne(f => f.Passenger)
                   .WithMany()
                   .HasForeignKey(f => f.PassengerId).IsRequired(false);

            // Reason 
            builder.Property(s => s.Reason).IsRequired();

            // Status
            builder.Property(s => s.Status).IsRequired();
        }
    }
}
