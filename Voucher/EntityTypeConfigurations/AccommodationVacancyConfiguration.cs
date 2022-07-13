using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class AccommodationVacancyConfiguration : IEntityTypeConfiguration<AccommodationVacancy>
    {
        public void Configure(EntityTypeBuilder<AccommodationVacancy> builder)
        {
            builder.ToTable("ACCOMMODATION_VACANCY");

            // Chave primária composta
            builder.HasKey(f => new { f.AccommodationProviderId, f.DateTime });

            // Chave estrangeira
            builder.HasOne(f => f.AccommodationProvider)
                   .WithMany(f => f.Vacancies)
                   .HasForeignKey(f => f.AccommodationProviderId);

            // Vancancies
            builder.Property(f => f.Vacancies).IsRequired();


            //modelBuilder.Entity<Sales>().HasBaseType<Person>();
        }
    }
}
