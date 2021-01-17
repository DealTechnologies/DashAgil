using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface ICRUD<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetByID(string id);
        void Delete(string id);
        void Update(T entity);
        void Insert(T entity);
    }
}
