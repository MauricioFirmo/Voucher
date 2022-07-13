using Voucher.Domain;
using Voucher.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class FoodProviderRepository
    {
        private readonly VoucherContext _voucherContext;
        public FoodProviderRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<FoodProvider> Insert(FoodProvider request)
        {
            try
            {
                await _voucherContext.FoodProviders.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodProvider> Delete(long Id)
        {
            try
            {
                FoodProvider entity = await Get(Id);
                _voucherContext.FoodProviders.Remove(entity);
                await _voucherContext.SaveChangesAsync();
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
                return await _voucherContext.FoodProviders.FindAsync(Id);
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
                return await _voucherContext.FoodProviders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FoodProvider> Update(FoodProvider request)
        {
            try
            {
                var update = _voucherContext.FoodProviders.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
