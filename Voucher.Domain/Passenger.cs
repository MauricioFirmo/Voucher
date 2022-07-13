using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class Passenger
    {
        public string Id { get; set; } //MD5 de FirstName/MiddleName/LastName/RecordLocator
        public long FlightId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string RecordLocator { get; set; }
        public string? TicketNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Flight Flight { get; set; }
    }
}
