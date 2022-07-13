using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.EntityTypeConfigurations
{
    public class AirportsConfiguration : IEntityTypeConfiguration<Airports>
    {
        public void Configure(EntityTypeBuilder<Airports> builder)
        {
            builder.ToTable("AIRPORTS_LIST");

            // Id
            builder.HasKey(f => f.ID);
            builder.Property(f => f.ID).UseIdentityColumn();

            //// Language
            //builder.Property(f => f.Language).IsRequired();

            //// Subject
            //builder.Property(f => f.Subject).HasMaxLength(250);

            //// Body
            //builder.Property(f => f.Body);
        }

        //void IEntityTypeConfiguration<Airports>.Configure(EntityTypeBuilder<Airports> builder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
