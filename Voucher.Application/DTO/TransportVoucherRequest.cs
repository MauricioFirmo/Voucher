using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Application.DTO
{
    public class TransportVoucherRequest
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public string CanceledBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime? CanceledDate { get; set; }
        public DateTime PrintedDate { get; set; }
        public long ServiceProviderId { get; set; }
        public string FreeText { get; set; }
        public long FlightId { get; set; }
        public bool IsActive { get; set; }
        public string PseudoCityCode { get; set; }
        public string PassengerId { get; set; }
        public StatusType Status { get; set; }
        public string Reason { get; set; }
        public DateTime? DateTransport { get; set; }
    }
}
