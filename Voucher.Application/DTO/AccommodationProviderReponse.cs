using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Application.DTO
{
    public class AccommodationProviderReponse : ServiceProvider
    {
        public string SapCode { get; set; }
        public decimal MealPrice { get; set; }
        public int MaxPaxPerSharedRoom { get; set; }
        public long? AccommodationEmailTemplateId { get; set; }
        public List<SpecialServiceResponse> SpecialServices { get; set; }
    }
}
