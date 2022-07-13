using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IPassengerAppService
    {
        Task<Passenger> Insert(Passenger request);
        Task<Passenger> InsertRange(List<Passenger> request);
        Task<Passenger> Get(string Id);
        Task<IEnumerable<Passenger>> GetList();
        Task<Passenger> Delete(string Id);
        Task<Passenger> Update(Passenger request);
        List<Passenger> GetList(long idAirport);
        Passenger GetPassengers(long idFlight, string Ticket);
    }
}
