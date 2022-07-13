using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class AccommodationProviderSpecialServiceRepository
    {
        private readonly VoucherContext _voucherContext;

        public AccommodationProviderSpecialServiceRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<int> Insert(AccommodationProviderSpecialService entity)
        {
            try
            {
                await _voucherContext.AccommodationProviderSpecialServices.AddAsync(entity);
                return await _voucherContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationProviderSpecialService>> GetList()
        {
            try
            {
                return await _voucherContext.AccommodationProviderSpecialServices.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationProviderSpecialService> Get(long IdAccommodationProvider, long IdSpecialService)
        {
            try
            {
                return await _voucherContext.AccommodationProviderSpecialServices.FindAsync(IdAccommodationProvider, IdSpecialService);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationProviderSpecialService> Update(AccommodationProviderSpecialService request)
        {
            try
            {
                var update = _voucherContext.AccommodationProviderSpecialServices.Update(request);
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
