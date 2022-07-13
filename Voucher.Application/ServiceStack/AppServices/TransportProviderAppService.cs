using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class TransportProviderAppService : ITransportProviderAppService
    {
        private readonly TransportProviderRepository _transportProviderRepository;
        private const string DISCRIMINATOR = "TransportProvider";

        public TransportProviderAppService(TransportProviderRepository transportProviderRepository)
        {
            _transportProviderRepository = transportProviderRepository;
        }

        public async Task<TransportProvider> Delete(long Id)
        {
            try
            {
                return await _transportProviderRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportProvider> Get(long Id)
        {
            try
            {
                return await _transportProviderRepository.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TransportProvider>> GetList()
        {
            try
            {
                return await _transportProviderRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportProvider> Insert(TransportProviderRequest request)
        {
            try
            {
                TransportProvider entity = new TransportProvider
                {
                    Active = request.Active,
                    Address = request.Address,
                    AirportIataCode = request.AirportIataCode,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Distance = request.Distance,
                    Email = request.Email,
                    FreeText = request.FreeText,
                    Id = request.Id,
                    LastModifiedBy = request.LastModifiedBy,
                    LastModifiedDate = request.LastModifiedDate,
                    Name = request.Name,
                    Phone = request.Phone,
                    Price = request.Price,
                    Priority = request.Priority,
                    TransportType = request.TransportType,
                    Discriminator = DISCRIMINATOR
                };

                return await _transportProviderRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportProvider> Update(TransportProviderRequest request)
        {
            try
            {
                TransportProvider entity = new TransportProvider
                {
                    Active = request.Active,
                    Address = request.Address,
                    AirportIataCode = request.AirportIataCode,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Distance = request.Distance,
                    Email = request.Email,
                    FreeText = request.FreeText,
                    Id = request.Id,
                    LastModifiedBy = request.LastModifiedBy,
                    LastModifiedDate = request.LastModifiedDate,
                    Name = request.Name,
                    Phone = request.Phone,
                    Price = request.Price,
                    Priority = request.Priority,
                    TransportType = request.TransportType,
                    Discriminator = DISCRIMINATOR
                };

                return await _transportProviderRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TransportProvider>> GetListByIataCode(string AirportIataCode, string Name)
        {
            try
            {
                IEnumerable<TransportProvider> result = await _transportProviderRepository.GetList();
                return result.Where(t => t.AirportIataCode == AirportIataCode && t.Name == Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
