using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.DTO
{
    public class ServiceResult
    {

        public bool resultSabre { get; set; }
        public bool resultDatabase { get; set; }
        public List<string> listError { get; set; }
    }
}
