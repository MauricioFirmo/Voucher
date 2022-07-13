using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class AccommodationEmailTemplate
    {
        public long Id { get; set; }
        public EmailLanguage Language { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
