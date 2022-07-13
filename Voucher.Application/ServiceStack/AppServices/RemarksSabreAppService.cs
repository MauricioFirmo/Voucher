using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class RemarksSabreAppService : IRemarksSabreAppService
    {
        private readonly RemarksSabreRepository _repository;
        private readonly VoucherContext _context;

        public RemarksSabreAppService(RemarksSabreRepository repository, VoucherContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Result> Delete(long id)
        {
            await _repository.Delete(id);
            return new Result
            {

            };
        }

        public async Task<RemarksSabre> List(long id)
        {
            return await _repository.List(id);
        }

        public async Task<Result> Save(RemarksSabre model)
        {
            await _repository.Update(model);
            return new Result
            {

            };
        }

        public async Task<Result> InsertRange(List<RemarksSabre> model)
        {
            await _repository.Insert(model);
            return new Result
            {

            };
        }

        //public async Task<Result> Save(RemarksSabre model)
        //{
        //    await _repository.Update(model);
        //    return new Result
        //    {

        //    };
        //}
        public async Task<Result> Create(RemarksSabre model)
        {
            await _repository.Insert(model);
            return new Result
            {

            };
        }

        public List<RemarksSabre> List(long Flight, string idPassenger)
        {
            try
            {
                return _context.RemarksSabre.Where
                    (p => p.FlightId == Flight
                        && p.PassengerId == idPassenger
                    ).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RemarksSabre> ListData(long Flight, string Origin, DateTime Std)
        {
            try
            {
                return _context.RemarksSabre.Where
                    (
                        p => p.FlightId == Flight
                    ).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
