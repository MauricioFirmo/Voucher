using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api
{
    public interface ITrackingActiveDirectoryRepository
    {
        bool LoginColaborador(string username, string password, string culture);
    }
}
