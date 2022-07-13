using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class AirportAppService : IAirportAppService
    {
        private readonly VoucherContext _context;
        private readonly AirportRepository _airportRepository;
        public AirportAppService(AirportRepository airportRepository, VoucherContext context)
        {
            _airportRepository = airportRepository;
            _context = context;
        }


        //public async Task<IEnumerable<Airports>> List()
        //{
        //    return await _airportRepository.List();
        //}

        public async Task<List<Airports>> GetList()
        {
            try
            {
                return await _context.Airports.Where(a=>a.BASESATIVASOPERADASGOL == true).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public async List<Airports> List(int idAirport)
        //{
        //    return await _context.Airports.Where(a => a.BASESATIVASOPERADASGOL == true)
        //}

        public async Task<Result> Save(Airports airport)
        {
            await _airportRepository.Update(airport);
            return new Result
            {

            };
        }
        public async Task<Result> Create(Airports airport)
        {
            await _airportRepository.Insert(airport);
            return new Result
            {

            };
        }

        public async Task<Result> Delete(long idAirport)
        {
            await _airportRepository.Delete(idAirport);
            return new Result
            {

            };
        }
    }
}
