using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class FlightRepository
    {
        private readonly VoucherContext _voucherContext;

        public FlightRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<Flight> Delete(long Id)
        {
            try
            {
                Flight entity = await Get(Id);
                _voucherContext.Flights.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flight> Get(long Id)
        {
            try
            {
                return await _voucherContext.Flights.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Flight>> GetList()
        {
            try
            {
                return await _voucherContext.Flights.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flight> GetFlight(string FlightNumber)
        {
            try
            {
                return await _voucherContext.Flights.Where(f => f.FlightNumber == FlightNumber).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Flight>> GetFlightPerPeriod(string FlightNumber, DateTime FirstDate, DateTime LastDate)
        {
            try
            {
                IEnumerable<Flight> flights = await _voucherContext.Flights.Where(f => f.FlightNumber == FlightNumber &&
                                                                                       f.STD >= FirstDate &&
                                                                                       f.STD <= LastDate).ToListAsync();

                return flights;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flight> Insert(Flight request)
        {
            try
            {
                await _voucherContext.Flights.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flight> InsertRange(List<Flight> request)
        {
            try
            {
                await _voucherContext.Flights.AddRangeAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flight> Update(Flight request)
        {
            try
            {
                var update = _voucherContext.Flights.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Flight GetListData(string Flight, string Origin, DateTime DepartureDate)
        {
            try
            {
                return _voucherContext.Flights.Where
                    (p => p.FlightNumber == Flight
                       && p.STD.Date == DepartureDate.Date
                       && p.DepartureStation == Origin
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
