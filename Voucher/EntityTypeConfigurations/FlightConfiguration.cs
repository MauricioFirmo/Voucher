using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Voucher.EntityTypeConfigurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("FLIGHT");

            // ID
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();

            // ARRIVAL STATION
            builder.Property(f => f.ArrivalStation).HasMaxLength(200).IsRequired();

            // CARRIER CODE
            builder.Property(f => f.CarrierCode).HasMaxLength(100).IsRequired();

            // DEPARTURE STATION
            builder.Property(f => f.DepartureStation).HasMaxLength(200).IsRequired();

            // FLIGHT NUMBER
            builder.Property(f => f.FlightNumber).HasMaxLength(80).IsRequired();

            // STA
            builder.Property(f => f.STA).IsRequired();

            // STD
            builder.Property(f => f.STD).IsRequired();

        }
    }
}
