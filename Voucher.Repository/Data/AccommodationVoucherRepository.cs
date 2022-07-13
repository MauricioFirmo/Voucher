using Voucher.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Voucher.Application.ServiceStack.AppServices
{
    public class AccommodationVoucherRepository
    {
        private readonly VoucherContext _voucherContext;



        public AccommodationVoucherRepository(VoucherContext voucherContext)
        {
            _voucherContext = voucherContext;
        }

        public async Task<AccommodationVoucher> Insert(AccommodationVoucher request)
        {
            try
            {
                await _voucherContext.accommodationVouchers.AddAsync(request);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVoucher> Get(long Id)
        {
            try
            {
                return await _voucherContext.accommodationVouchers.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationVoucher>> GetList()
        {
            try
            {
                return await _voucherContext.accommodationVouchers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationVoucher>> GetListByReport(string PassengerId, long FlightId, DateTime FirstPeriod, DateTime FinalPeriod)
        {
            try
            {
                return await _voucherContext.accommodationVouchers.Where(v => v.PassengerId == PassengerId &&
                                                                              v.FlightId == FlightId &&
                                                                              v.CreatedDate >= FirstPeriod &&
                                                                              v.CreatedDate <= FinalPeriod).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AccommodationVoucher> Delete(long Id)
        {
            try
            {
                AccommodationVoucher entity = await Get(Id);
                _voucherContext.accommodationVouchers.Remove(entity);
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationVoucher> Update(AccommodationVoucher request)
        {
            try
            {
                var update = _voucherContext.accommodationVouchers.Update(request);
                update.State = EntityState.Modified;
                await _voucherContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertRange(List<AccommodationVoucher> entity, string username)
        {
            try
            {
                await _voucherContext.accommodationVouchers.AddRangeAsync(entity);
                await _voucherContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public void GetEmailQuery()
        {
            try
            {
                //var innerJoin = from v in _voucherContext.accommodationVouchers
                //                join p in _voucherContext.AccommodationProviders
                //                on v.ServiceProviderId equals p.Id
                //                select new
                //                {
                //                    Nome = v.PassengerName,
                //                    Id = v.IdPassenger
                //                };

                //string teste;
                //teste = "";
                //foreach (var resultado in innerJoin)
                //{
                //    teste = resultado.Nome;
                //}



                    //return _voucherContext.accommodationVouchers.Where
                    //    (p => p.ServiceProviderId == 7).Include(p => p.ServiceProvider).ToList();
                    //return _voucherContext.accommodationVouchers.Include(p => p.ServiceProvider).ToList();
                    //return _voucherContext.accommodationVouchers.Where(p => p.Id == 7).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
