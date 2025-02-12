﻿using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Data
{
    public class SpecialServiceRepository
    {
        private readonly VoucherContext _voucherContext;
        public SpecialServiceRepository(VoucherContext context)
        {
            _voucherContext = context;
        }

        public async Task<SpecialService> Delete(long Id)
        {
            try
            {
                SpecialService entity = await Get(Id);
                _voucherContext.SpecialServices.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SpecialService> Get(long Id)
        {
            try
            {
                return await _voucherContext.SpecialServices.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SpecialService>> GetList()
        {
            try
            {
                return await _voucherContext.SpecialServices.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SpecialService> Insert(SpecialService request)
        {
            try
            {
                await _voucherContext.SpecialServices.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SpecialService> Update(SpecialService request)
        {
            try
            {
                var update = _voucherContext.SpecialServices.Update(request);
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
