using Voucher.Domain;
using Voucher.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class AccommodationProviderRepository
    {
        private readonly VoucherContext _voucherContext;

        public AccommodationProviderRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<int> Insert(AccommodationProvider request)
        {
            try
            {
                await _voucherContext.AccommodationProviders.AddAsync(request);
                await _voucherContext.SaveChangesAsync();

                return (int)request.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationProvider> Delete(long Id)
        {
            try
            {
                AccommodationProvider entity = await Get(Id);
                _voucherContext.AccommodationProviders.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationProvider> Get(long Id)
        {
            try
            {
                return await _voucherContext.AccommodationProviders.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationProvider>> GetList()
        {
            try
            {
                return await _voucherContext.AccommodationProviders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(AccommodationProvider request)
        {
            try
            {
                var update = _voucherContext.AccommodationProviders.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return (int)request.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
