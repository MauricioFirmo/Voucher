using Voucher.Domain;
using Voucher.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher
{
    public class VoucherContext : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=voucher)));User Id=usr_voucher;Password=voucher123;");
        }

        public DbSet<TransportProvider> TransportProviders { get; set; }
        public DbSet<FoodProvider> FoodProviders { get; set; }
        public DbSet<AccommodationProvider> AccommodationProviders { get; set; }
        public DbSet<TransportVoucher> transportVouchers { get; set; }
        public DbSet<FoodVoucher> foodVouchers { get; set; }
        public DbSet<AccommodationVoucher> accommodationVouchers { get; set; }
        public DbSet<AccommodationEmailTemplate> EmailTemplates { get; set; }
        public DbSet<AccommodationVacancy> AccommodationVacancies { get; set; }
        public DbSet<SpecialService> SpecialServices { get; set; }
        public DbSet<AccommodationProviderSpecialService> AccommodationProviderSpecialServices { get; set; }
        public DbSet<VoucherIssuanceRestriction> VoucherIssuanceRestrictions { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<RemarksSabre> RemarksSabre { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Service Provider
            modelBuilder.ApplyConfiguration(new ServiceProviderConfiguration());

            // Transport Provider
            modelBuilder.ApplyConfiguration(new TransportProviderConfiguration());

            // Food Provider
            modelBuilder.ApplyConfiguration(new FoodProviderConfiguration());

            // Accommodation Provider
            modelBuilder.ApplyConfiguration(new AccommodationProviderConfiguration());

            // Voucher
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());

            // Transport Voucher
            modelBuilder.ApplyConfiguration(new TransportVoucherConfiguration());

            // Food Voucher
            modelBuilder.ApplyConfiguration(new FoodVoucherConfiguration());

            // Accommodation Voucher
            modelBuilder.ApplyConfiguration(new AccommodationVoucherConfiguration());

            // EmailTemplate
            modelBuilder.ApplyConfiguration(new AccommodationEmailTemplateConfiguration());

            // Vacancy
            modelBuilder.ApplyConfiguration(new AccommodationVacancyConfiguration());

            // Special Service
            modelBuilder.ApplyConfiguration(new SpecialServiceConfiguration());

            // Accommodation Special Services
            modelBuilder.ApplyConfiguration(new AccommodationProviderSpecialServiceConfiguration());

            // Voucher Issuance Restriction
            modelBuilder.ApplyConfiguration(new VoucherIssuanceRestrictionConfiguration());

            // Airports
            modelBuilder.ApplyConfiguration(new AirportsConfiguration());

            // RemarksSabre
            modelBuilder.ApplyConfiguration(new RemarksSabreConfiguration());

            // Passenger
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            // Flight
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
