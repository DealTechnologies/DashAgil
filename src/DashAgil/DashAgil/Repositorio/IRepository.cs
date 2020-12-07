using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IRepository<TEntity> where TEntity : class
    {
        long Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
    }
}
