using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class FlightAppService : IFlightAppService
    {
        private readonly FlightRepository _flightRepository;

        public FlightAppService(FlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Flight> Delete(long Id)
        {
            try
            {
                return await _flightRepository.Delete(Id);
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
                return await _flightRepository.Get(Id);
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
                return await _flightRepository.GetList();
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
                return await _flightRepository.Insert(request);
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
                return await _flightRepository.InsertRange(request);
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
                return await _flightRepository.Update(request);
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
                return  _flightRepository.GetListData(Flight, Origin, DepartureDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
