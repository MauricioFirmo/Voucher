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
    public class FoodProviderAppService : IFoodProviderAppService
    {
        private readonly FoodProviderRepository _foodProviderRepository;
        private const string DISCRIMINATOR = "FoodProvider";

        public FoodProviderAppService(FoodProviderRepository foodProviderRepository)
        {
            _foodProviderRepository = foodProviderRepository;
        }

        public async Task<FoodProvider> Delete(long Id)
        {
            try
            {
                await _foodProviderRepository.Delete(Id);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodProvider> Get(long Id)
        {
            try
            {
                return await _foodProviderRepository.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FoodProvider>> GetList()
        {
            try
            {
                return await _foodProviderRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodProvider> Update(FoodProviderRequest request)
        {
            try
            {
                FoodProvider entity = new FoodProvider
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
                    MealType = request.MealType,
                    Name = request.Name,
                    Phone = request.Phone,
                    Price = request.Price,
                    Priority = request.Priority,
                    Discriminator = DISCRIMINATOR
                };

                await _foodProviderRepository.Update(entity);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodProvider> Insert(FoodProviderRequest request)
        {
            try
            {
                FoodProvider entity = new FoodProvider
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
                    MealType = request.MealType,
                    Name = request.Name,
                    Phone = request.Phone,
                    Price = request.Price,
                    Priority = request.Priority,
                    Discriminator = DISCRIMINATOR
                };

                return await _foodProviderRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FoodProvider>> GetListByIataCode(string AirportIataCode, string Name)
        {
            try
            {
                IEnumerable<FoodProvider> result = await _foodProviderRepository.GetList();
                return result.Where(f => f.AirportIataCode == AirportIataCode && f.Name == Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
