using Voucher.Domain;
using Voucher.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class AccommodationVacancyRepository : GenericRepository<AccommodationVacancy>
    {
        //private readonly VoucherContext _contexto;

        //public AccommodationVacancyRepository(VoucherContext contexto)
        //{
        //    _contexto = contexto;
        //}
        public AccommodationVacancyRepository(VoucherContext context) : base(context)
        {
        }
        //public async Task Insert(AccommodationVacancy entity)
        //{
        //    try
        //    {

        //        await _contexto.AccommodationVacancies.AddAsync(entity);
        //        await _contexto.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<IEnumerable<AccommodationVacancy>> List()
        //{
        //    try
        //    {
        //        return await _contexto.Set<AccommodationVacancy>().AddAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
