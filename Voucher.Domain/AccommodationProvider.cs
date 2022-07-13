using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Voucher.Domain
{
    public class AccommodationProvider : ServiceProvider
    {
        public string SapCode { get; set; }
        public decimal MealPrice { get; set; }
        public int MaxPaxPerSharedRoom { get; set; }
        public AccommodationEmailTemplate AccommodationEmailTemplate { get; set; }
        public long? AccommodationEmailTemplateId { get; set; }
        public List<AccommodationProviderSpecialService> AccommodationProviderSpecialServices { get; set; }
        
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<AccommodationVacancy> Vacancies { get; set; }
    }
}
