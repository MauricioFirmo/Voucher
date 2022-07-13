using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class FoodVoucherRepository
    {
        private readonly VoucherContext _voucherContext;
        
        public FoodVoucherRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<FoodVoucher> Insert(FoodVoucher request)
        {
            try
            {
                await _voucherContext.foodVouchers.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
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
                return await _voucherContext.foodVouchers.FindAsync(Id);
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
                return await _voucherContext.foodVouchers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FoodVoucher>> GetListByReport(string PassengerId, long FlightId, DateTime FirstPeriod, DateTime FinalPeriod)
        {
            try
            {
                return await _voucherContext.foodVouchers.Where(v => v.PassengerId == PassengerId &&
                                                                     v.FlightId == FlightId && 
                                                                     v.CreatedDate >= FirstPeriod &&
                                                                     v.CreatedDate <= FinalPeriod).ToListAsync();
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
                FoodVoucher entity = await Get(Id);
                _voucherContext.foodVouchers.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodVoucher> Update(FoodVoucher request)
        {
            try
            {
                var update = _voucherContext.foodVouchers.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<FoodVoucher> InsertRange(List<FoodVoucher> entity)
        {
            try
            {
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
