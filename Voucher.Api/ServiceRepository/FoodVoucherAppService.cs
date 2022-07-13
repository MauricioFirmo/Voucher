using Voucher.Api.ServiceRepository.Extensions;
using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository
{
    public class FoodVoucherAppService : IFoodVoucherAppService
    {
        private readonly ISabreDataRepository _sabreDataRepository;
        private readonly FoodVoucherRepository _foodVoucherRepository;
        private const string DISCRIMINATOR = "FoodVoucher";

        public FoodVoucherAppService(FoodVoucherRepository foodVoucherRepository, ISabreDataRepository sabreDataRepository)
        {
            _foodVoucherRepository = foodVoucherRepository;
            _sabreDataRepository = sabreDataRepository;
        }

        public async Task<FoodVoucher> Insert(FoodVoucherRequest request)
        {
            try
            {
                FoodVoucher entity = new FoodVoucher
                {
                    CanceledBy = request.CanceledBy,
                    CanceledDate = request.CanceledDate,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Discriminator = DISCRIMINATOR,
                    FlightId = request.FlightId,
                    FreeText = request.FreeText,
                    Id = request.Id,
                    IsActive = request.IsActive,
                    PrintedDate = request.PrintedDate,
                    PseudoCityCode = request.PseudoCityCode,
                    ServiceProviderId = request.ServiceProviderId,
                    ValidUntil = request.ValidUntil,
                    PassengerId = request.PassengerId,
                    Status = request.Status,
                    Reason = request.Reason
                };

                await _foodVoucherRepository.Insert(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodVoucher> Get(long Id)
        {
            try
            {
                return await _foodVoucherRepository.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FoodVoucher>> GetList()
        {
            try
            {
                return await _foodVoucherRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodVoucher> Delete(long Id)
        {
            try
            {
                return await _foodVoucherRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result> InsertRange(List<FoodVoucherRequest> modelList)
        {
            List<FoodVoucherRequest> requestList = new List<FoodVoucherRequest>();
            foreach (var item in modelList)
            {
                var result = await this.Insert(item);
                FoodVoucherRequest requestItem = new FoodVoucherRequest();
                requestItem = item;
                requestItem.Id = result.Id;
                requestList.Add(requestItem);
            }
            _sabreDataRepository.UpdadeRemarksSabreRange(requestList, true);

            return new Result
            {

            };
        }

        public async Task<FoodVoucher> Update(FoodVoucherRequest request)
        {
            try
            {
                FoodVoucher entity = new FoodVoucher
                {
                    CanceledBy = request.CanceledBy,
                    CanceledDate = request.CanceledDate,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Discriminator = DISCRIMINATOR,
                    FlightId = request.FlightId,
                    FreeText = request.FreeText,
                    Id = request.Id,
                    IsActive = request.IsActive,
                    PrintedDate = request.PrintedDate,
                    PseudoCityCode = request.PseudoCityCode,
                    ServiceProviderId = request.ServiceProviderId,
                    ValidUntil = request.ValidUntil,
                    PassengerId = request.PassengerId,
                    Status = request.Status,
                    Reason = request.Reason
                };

                return await _foodVoucherRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
