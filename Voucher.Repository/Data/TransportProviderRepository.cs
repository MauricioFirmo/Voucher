using Voucher.Domain;
using Voucher.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class TransportProviderRepository
    {
        private readonly VoucherContext _voucherContext;

        public TransportProviderRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<TransportProvider> Insert(TransportProvider request)
        {
            try
            {
                await _voucherContext.TransportProviders.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportProvider> Delete(long Id)
        {
            try
            {
                TransportProvider entity = await Get(Id);
                _voucherContext.TransportProviders.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
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
                return await _voucherContext.TransportProviders.FindAsync(Id);
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
                return await _voucherContext.TransportProviders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TransportProvider> Update(TransportProvider request)
        {
            try
            {
                var update = _voucherContext.TransportProviders.Update(request);
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
