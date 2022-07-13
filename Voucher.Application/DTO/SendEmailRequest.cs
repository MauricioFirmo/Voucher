using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Application.DTO
{
    public class SendEmailRequest
    {
        public string from { get; set; }
        public string fromName { get; set; }
        public string to { get; set; }
        public string toName { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string? password { get; set; }
        public string user { get; set; }
        public string mailServer { get; set; }
        public int port { get; set; }
    }
}
