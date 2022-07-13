using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class PassengerRepository
    {
        private readonly VoucherContext _voucherContext;
        public PassengerRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<Passenger> Delete(string Id)
        {
            try
            {
                Passenger entity = await Get(Id);
                _voucherContext.Passengers.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Passenger> Get(string Id)
        {
            try
            {
                return await _voucherContext.Passengers.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Passenger>> GetList()
        {
            try
            {
                return await _voucherContext.Passengers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Passenger>> GetPassengerByFlight(long FlightId)
        {
            try
            {
                return await _voucherContext.Passengers.Where(p => p.FlightId == FlightId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Passenger> Insert(Passenger request)
        {
            try
            {
                await _voucherContext.Passengers.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Passenger> InsertRange(List<Passenger> request)
        {
            try
            {
                await _voucherContext.Passengers.AddRangeAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Passenger> Update(Passenger request)
        {
            try
            {
                var update = _voucherContext.Passengers.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  List<Passenger> GetList(long idFlight)
        {
            try
            {
                return _voucherContext.Passengers.Where(p => p.FlightId == idFlight).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Passenger GetPassenger(long idFlight, string Ticket)
        {
            try
            {
                return _voucherContext.Passengers.Where
                    (p => p.TicketNumber == Ticket
                       && p.FlightId == idFlight
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
