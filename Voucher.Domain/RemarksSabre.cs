using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Voucher.Domain
{
    public class RemarksSabre
    {
        public long Id { get; set; }
        public DateTime dtInsert { get; set; }
        public string Username { get; set; }
        public string Remark { get; set; }
        public long VoucherId { get; set; }
        public long FlightId { get; set; }
        public string PassengerId { get; set; }
        public Voucher Voucher { get; set; }
        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
    }
}
