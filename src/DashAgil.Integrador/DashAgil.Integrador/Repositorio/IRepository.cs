using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
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
