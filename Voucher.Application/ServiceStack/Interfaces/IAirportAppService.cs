using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IAirportAppService
    {
        //Task<IEnumerable<Airports>> List();
        //Task<Airports> List(int idAirport);
        Task<Result> Delete(long idAirport);
        Task<Result> Save(Airports airport);
        Task<Result> Create(Airports airport);
        Task<List<Airports>> GetList();
    }
}
