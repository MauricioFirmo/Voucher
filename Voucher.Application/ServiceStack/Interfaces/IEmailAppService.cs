using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IEmailAppService
    {
        Task<IEnumerable<AccommodationEmailTemplate>> List();
        Task<AccommodationEmailTemplate> List(int idEmail);
        Task<Result> Delete(long idEmail);
        Task<Result> Save(AccommodationEmailTemplate email);
        Task<Result> Create(AccommodationEmailTemplate email);
    }
}
