using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Application.DTO
{
    public class ReportVoucherResponse
    {
        public string AirportIataCode { get; set; }
        public string Destino { get; set; }
        public DateTime FlightDate { get; set; }
        public string FlightNumber { get; set; }
        public long VoucherId { get; set; }
        public StatusType Satus { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string Discriminator { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string RecordLocator { get; set; }
        public string PassengerName { get; set; }
        public decimal TotalHotels { get; set; }
        public decimal TotalFood { get; set; }
        public decimal TotalTransport { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
