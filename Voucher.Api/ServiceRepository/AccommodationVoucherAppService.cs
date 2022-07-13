using Voucher.Api.ServiceRepository.Extensions;
using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.AppServices;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository
{
    public class AccommodationVoucherAppService : IAccommodationVoucherAppService
    {
        private readonly ISabreDataRepository _sabreDataRepository;
        private readonly AccommodationVoucherRepository _accommodationVoucherRepository;
        private readonly VoucherContext _context;
        private const string DISCRIMINATOR = "AccommodationVoucher";

        public AccommodationVoucherAppService(AccommodationVoucherRepository accommodationVoucherRepository, VoucherContext context, ISabreDataRepository sabreDataRepository)
        {
            _accommodationVoucherRepository = accommodationVoucherRepository;
            _context = context;
            _sabreDataRepository = sabreDataRepository;
        }

        public async Task<AccommodationVoucher> Insert(AccommodationVoucherRequest request)
        {
            try
            {
                AccommodationVoucher entity = new AccommodationVoucher
                {
                    Id = request.Id,
                    CanceledBy = request.CanceledBy,
                    CanceledDate = request.CanceledDate,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Discriminator = DISCRIMINATOR,
                    FlightId = request.FlightId,
                    FreeText = request.FreeText,
                    IsActive = request.IsActive,
                    PrintedDate = request.PrintedDate,
                    PseudoCityCode = request.PseudoCityCode,
                    RoomId = request.RoomId,
                    RoomType = request.RoomType,
                    ServiceProviderId = request.ServiceProviderId,
                    ValidUntil = request.ValidUntil,
                    PassengerId = request.PassengerId,
                    Status = request.Status,
                    DailyAmount = request.DailyAmount,
                    Reason = request.Reason
                };

                await _accommodationVoucherRepository.Insert(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVoucher> Get(long Id)
        {
            try
            {
                return await _accommodationVoucherRepository.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> InsertRange(List<AccommodationVoucherRequest> modelList)
        {

            List<AccommodationVoucherRequest> requestList = new List<AccommodationVoucherRequest>();
            foreach (var item in modelList)
            {
                var result = await this.Insert(item);
                AccommodationVoucherRequest requestItem = new AccommodationVoucherRequest();
                requestItem = item;
                requestItem.Id = result.Id;
                requestList.Add(requestItem);
            }

            _sabreDataRepository.UpdadeRemarksSabreRange(requestList, true);
            return new Result
            {

            };
        }

        public async Task<IEnumerable<AccommodationVoucher>> GetList()
        {
            try
            {
                return await _accommodationVoucherRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVoucher> Delete(long Id)
        {
            try
            {
                return await _accommodationVoucherRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVoucher> Update(AccommodationVoucherRequest request)
        {
            try
            {
                AccommodationVoucher entity = new AccommodationVoucher
                {
                    Id = request.Id,
                    CanceledBy = request.CanceledBy,
                    CanceledDate = request.CanceledDate,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Discriminator = DISCRIMINATOR,
                    FlightId = request.FlightId,
                    FreeText = request.FreeText,
                    IsActive = request.IsActive,
                    PrintedDate = request.PrintedDate,
                    PseudoCityCode = request.PseudoCityCode,
                    RoomType = request.RoomType,
                    ServiceProviderId = request.ServiceProviderId,
                    ValidUntil = request.ValidUntil,
                    PassengerId = request.PassengerId,
                    Status = request.Status,
                    DailyAmount = request.DailyAmount,
                    Reason = request.Reason
                };

                await _accommodationVoucherRepository.Update(entity);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public string AcomodationEmail(AccommodationVoucher voucher)
        {
            
            string body = "";
            var hotelData = _context.AccommodationProviders.Find(voucher.ServiceProviderId);
            body = "Name:" + hotelData.Name + Environment.NewLine;
            body = body + "Adress:" + hotelData.Address + Environment.NewLine;
            body = body + "Phone:" + hotelData.Phone + Environment.NewLine;
            body = body + "Email:" + body + hotelData.Email + Environment.NewLine;
            body = body + " " + Environment.NewLine;
            body = body + "Airport:" + voucher.PseudoCityCode + Environment.NewLine;
            body = body + "Arrival:" + voucher.PseudoCityCode + Environment.NewLine;
            body = body + "Ref. Passenger AccomodationRequest" + Environment.NewLine; ;
            body = body + "Arrival:" + voucher.PseudoCityCode + Environment.NewLine;
            body = body + "We request accomodation for the following passenger(s) listed below:" + Environment.NewLine; ;

            return body;
        }
    }
}
