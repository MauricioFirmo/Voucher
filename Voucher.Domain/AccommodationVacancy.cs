using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Voucher.Domain
{
    public class AccommodationVacancy
    {
        public AccommodationProvider AccommodationProvider { get; set; }
        public long AccommodationProviderId { get; set; }
        public DateTime DateTime { get; set; }
        public int Vacancies { get; set; }
    }
}










