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
    public class VoucherIssuanceRestrictionAppService : IVoucherIssuanceRestrictionAppService
    {
        private readonly VoucherIssuanceRestrictionRepository _repo;
        private readonly VoucherContext _context;
        public VoucherIssuanceRestrictionAppService(VoucherIssuanceRestrictionRepository repo, VoucherContext context)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<Result> Delete(long id)
        {
            await _repo.Delete(id);
            return new Result
            {

            };
        }
        public async Task<IEnumerable<VoucherIssuanceRestriction>> List()
        {
            return await _repo.List();
        }

        public async Task<VoucherIssuanceRestriction> List(long id)
        {
            return await _repo.List(id);
        }

        public async Task<Result> Save(VoucherIssuanceRestriction email)
        {
            await _repo.Update(email);
            return new Result
            {

            };
        }

        public async Task<Result> SaveRange(List<VoucherIssuanceRestriction> email)
        {
            await _repo.Update(email);
            return new Result
            {

            };
        }

        public async Task<Result> Create(VoucherIssuanceRestriction email)
        {
            await _repo.Insert(email);
            return new Result
            {

            };
        }
        public async Task<Result> Create(List<VoucherIssuanceRestriction> email)
        {
            await _repo.Insert(email);
            return new Result
            {

            };
        }

        public async Task<List<VoucherIssuanceRestriction>> GetList(string Flight, DateTime Date, string DepartureAirport)
        {
            try
            {
                return await _context.VoucherIssuanceRestrictions.Where(
                    p => p.FlightNumber == Flight
                    && p.STD.Date == Date.Date
                    && p.DepartureAirport == DepartureAirport
                    ).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
