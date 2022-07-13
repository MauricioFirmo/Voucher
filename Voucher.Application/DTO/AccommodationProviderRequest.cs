using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Application.DTO
{
    public class AccommodationProviderRequest
    {
        public long Id { get; set; }
        public string AirportIataCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public int Priority { get; set; }
        public double Distance { get; set; }
        public string FreeText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string SapCode { get; set; }
        public decimal MealPrice { get; set; }
        public int MaxPaxPerSharedRoom { get; set; }
        public long? AccommodationEmailTemplateId { get; set; }
        public List<AccommodationProviderSpecialService> AccommodationProviderSpecialServices { get; set; }
    }
}
