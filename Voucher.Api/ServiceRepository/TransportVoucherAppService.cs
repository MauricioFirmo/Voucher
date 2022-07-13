using Voucher.Api.ServiceRepository.Extensions;
using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository
{
    public class TransportVoucherAppService : ITransportVoucherAppService
    {
        private readonly ISabreDataRepository _sabreDataRepository;
        private readonly TransportVoucherRepository _transportVoucherRepository;
        private const string DISCRIMINATOR = "TransportVoucher";

        public TransportVoucherAppService(TransportVoucherRepository transportVoucherRepository, ISabreDataRepository sabreDataRepository)
        {
            _transportVoucherRepository = transportVoucherRepository;
            _sabreDataRepository = sabreDataRepository;
        }

        public async Task<TransportVoucher> Insert(TransportVoucherRequest request)
        {
            try
            {
                TransportVoucher entity = new TransportVoucher
                {
                    CanceledBy = request.CanceledBy,
                    CanceledDate = request.CanceledDate,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    DateTransport = request.DateTransport,
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
                    Reason = request.Reason,
                    TransportStatus = TransportStatus.Going
                };

                await _transportVoucherRepository.Insert(entity);

                entity.Id = 0;
                entity.TransportStatus = TransportStatus.Return;

                return await _transportVoucherRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> InsertRange(List<TransportVoucher> modelList)
        {
            try
            {
                List<TransportVoucher> entityListGoing = modelList.Select(t =>
                {
                    t.Discriminator = DISCRIMINATOR;
                    t.TransportStatus = TransportStatus.Going;
                    return t;
                }).ToList();

                var listGoing = await _transportVoucherRepository.InsertRange(entityListGoing);


                List<TransportVoucher> entityListReturn = modelList.Select(tv =>
                {
                    tv.Id = 0;
                    tv.Discriminator = DISCRIMINATOR;
                    tv.TransportStatus = TransportStatus.Return;
                    return tv;
                }).ToList();

                var listReturn = await _transportVoucherRepository.InsertRange(entityListReturn);
                _sabreDataRepository.UpdadeRemarksSabreRange(entityListGoing, true);
                _sabreDataRepository.UpdadeRemarksSabreRange(entityListReturn, true);



                return new Result
                {

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<TransportVoucher> Get(long Id)
        {
            try
            {
                return await _transportVoucherRepository.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TransportVoucher>> GetList()
        {
            try
            {
                return await _transportVoucherRepository.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportVoucher> Delete(long Id)
        {
            try
            {
                return await _transportVoucherRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportVoucher> Update(TransportVoucherRequest request)
        {
            try
            {
                TransportVoucher entity = new TransportVoucher
                {
                    CanceledBy = request.CanceledBy,
                    CanceledDate = request.CanceledDate,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    DateTransport = request.DateTransport,
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
                    Reason = request.Reason,
                };

                return await _transportVoucherRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
