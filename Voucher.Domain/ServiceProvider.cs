using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public abstract class ServiceProvider
    {
        public long Id { get; set; }
        public string Discriminator { get; set; }
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
    }
}
