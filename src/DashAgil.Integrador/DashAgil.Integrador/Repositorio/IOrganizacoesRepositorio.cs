using DashAgil.Integrador.Entidades;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IOrganizacoesRepositorio
    {
        Task<long> Inserir(Organizacoes org);
        Task<Organizacoes> ObterPorID(long id);
        Task<Organizacoes> ObterPorNome(string nome);
    }
}
