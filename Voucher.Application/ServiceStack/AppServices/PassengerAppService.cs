using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class PassengerAppService : IPassengerAppService
    {
        private readonly PassengerRepository _passengerRepository;
        public PassengerAppService(PassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<Passenger> Delete(string Id)
        {
            try
            {
                return await _passengerRepository.Delete(Id);
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
                return await _passengerRepository.Get(Id);
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
                return await _passengerRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Passenger> GetList(long idFlight)
        {
            try
            {
                return _passengerRepository.GetList(idFlight);
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
                return await _passengerRepository.Insert(request);
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
                return await _passengerRepository.InsertRange(request);
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
                return await _passengerRepository.Update(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Passenger GetPassengers(long idFlight, string Ticket)
        {
            try
            {
                return _passengerRepository.GetPassenger(idFlight, Ticket);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //long idFlight, string Ticket

    }
}
