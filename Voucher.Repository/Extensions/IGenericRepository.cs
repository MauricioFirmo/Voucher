using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Repository.Extensions
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> List();
        Task<TEntity> List(long id);
        Task<TEntity> List(string nome);
        Task<TEntity> List(object[] compositeKey);
        Task Insert(TEntity entity);
        Task Insert(List<TEntity> entity);
        Task Update(TEntity entity);
        Task Update(IEnumerable<TEntity> entity);
        Task Delete(TEntity entity);
        Task Delete(long id);
        Task Delete(string nome);
        Task Delete(object[] compositeKey);
    }
}
