using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class TransportVoucherRepository
    {
        private readonly VoucherContext _voucherContext;

        public TransportVoucherRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<TransportVoucher> Insert(TransportVoucher request)
        {
            try
            {
                await _voucherContext.transportVouchers.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
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
                return await _voucherContext.transportVouchers.FindAsync(Id);
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
                return await _voucherContext.transportVouchers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TransportVoucher>> GetListByReport(string PassengerId, long FlightId, DateTime FirstPeriod, DateTime FinalPeriod)
        {
            try
            {
                return await _voucherContext.transportVouchers.Where(v => v.PassengerId == PassengerId &&
                                                                          v.FlightId == FlightId &&
                                                                          v.CreatedDate >= FirstPeriod &&
                                                                          v.CreatedDate <= FinalPeriod).ToListAsync();
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
                TransportVoucher entity = await Get(Id);
                _voucherContext.transportVouchers.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportVoucher> Update(TransportVoucher request)
        {
            try
            {
                var update = _voucherContext.transportVouchers.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task <List<TransportVoucher>> InsertRange(List<TransportVoucher> entity)
        {
            try
            {
                await _voucherContext.transportVouchers.AddRangeAsync(entity);
                await _voucherContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
