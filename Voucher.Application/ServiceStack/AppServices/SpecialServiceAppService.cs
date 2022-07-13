using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class SpecialServiceAppService : ISpecialServiceAppService
    {
        private readonly SpecialServiceRepository _specialServiceRepository;

        public SpecialServiceAppService(SpecialServiceRepository specialServiceRepository)
        {
            _specialServiceRepository = specialServiceRepository;
        }

        public async Task<SpecialService> Delete(long Id)
        {
            try
            {
                return await _specialServiceRepository.Delete(Id);
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
                return await _specialServiceRepository.Get(Id);
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
                return await _specialServiceRepository.GetList();
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
                await _specialServiceRepository.Insert(request);
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
                await _specialServiceRepository.Update(request);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
