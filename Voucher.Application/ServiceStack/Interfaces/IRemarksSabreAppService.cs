using Voucher.Application.DTO;
using Voucher.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface IRemarksSabreAppService
    {
        List<RemarksSabre> ListData(long Flight, string Origin, DateTime Std);
        public List<RemarksSabre> List(long Flight, string idPassenger);
        Task<RemarksSabre> List(long id);
        Task<Result> Delete(long id);
        Task<Result> Create(RemarksSabre model);
        Task<Result> Save(RemarksSabre model);
        Task<Result> InsertRange(List<RemarksSabre> model);
    }
}
