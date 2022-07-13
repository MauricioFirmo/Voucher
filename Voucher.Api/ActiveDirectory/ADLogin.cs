using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api
{
    public class ADLogin
    {
        private readonly ITrackingActiveDirectoryRepository _TrackingActiveDirectory;
        public ADLogin(ITrackingActiveDirectoryRepository TrackingActiveDirectory)
        {
            _TrackingActiveDirectory = TrackingActiveDirectory;
        }


    }
}
