using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface ISpecialServiceAppService
    {
        Task<SpecialService> Insert(SpecialService request);
        Task<SpecialService> Get(long Id);
        Task<IEnumerable<SpecialService>> GetList();
        Task<SpecialService> Delete(long Id);
        Task<SpecialService> Update(SpecialService request);
    }
}
