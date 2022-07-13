using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IFlightAppService
    {
        Task<Flight> Insert(Flight request);
        Task<Flight> InsertRange(List<Flight> request);
        Task<Flight> Get(long Id);
        Task<IEnumerable<Flight>> GetList();
        Task<Flight> Delete(long Id);
        Task<Flight> Update(Flight request);
        Flight GetListData(string Flight, string Origin, DateTime DepartureDate);
    }
}
