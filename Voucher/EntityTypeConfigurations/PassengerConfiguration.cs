using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Voucher.EntityTypeConfigurations
{
    class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("PASSENGER");

            // ID
            builder.HasKey(f => f.Id).Metadata.IsPrimaryKey();

            builder.Property(f => f.FlightId).IsRequired();

            // FIRST NAME
            builder.Property(f => f.FirstName).HasMaxLength(250).IsRequired();

            // MIDDLE NAME
            builder.Property(f => f.MiddleName).HasMaxLength(250);

            // LAST NAME
            builder.Property(f => f.LastName).HasMaxLength(250).IsRequired();

            // RECORD LOCATOR
            builder.Property(f => f.RecordLocator).HasMaxLength(50).IsRequired();

            // TICKET NUMBER
            builder.Property(f => f.TicketNumber).HasMaxLength(250);

            // DATE OF BIRTH
            builder.Property(f => f.DateOfBirth);

            //builder.HasOne(f => f.Flight)   
            //       .WithMany()
            //       .HasForeignKey(f => f.FlightId).IsRequired(false);//Avriguar essa
        }
    }
}
