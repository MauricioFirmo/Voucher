using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class ADAuthentication
    {
        public bool isAuthenticated { get; set; }
        public string[] groups { get; set; }
        public string error { get; set; }
    }
}
