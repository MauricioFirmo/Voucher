using Voucher.Application.ServiceStack.AppServices;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IADAppService
    {
        Task<ADAuthentication> GetADAuthentication(string username, string password);
    }
}
