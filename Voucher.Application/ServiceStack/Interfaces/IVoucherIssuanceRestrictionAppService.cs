using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IVoucherIssuanceRestrictionAppService
    {
        Task<IEnumerable<VoucherIssuanceRestriction>> List();
        Task<VoucherIssuanceRestriction> List(long id);
        Task<Result> Delete(long id);
        Task<Result> Save(VoucherIssuanceRestriction email);
        Task<Result> SaveRange(List<VoucherIssuanceRestriction> email);
        Task<Result> Create(VoucherIssuanceRestriction email);
        Task<Result> Create(List<VoucherIssuanceRestriction> email);
        Task<List<VoucherIssuanceRestriction>> GetList(string Flight, DateTime Date, string DepartureAirport);
    }
}
