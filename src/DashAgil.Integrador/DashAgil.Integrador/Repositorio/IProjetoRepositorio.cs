using DashAgil.Integrador.Entidades;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IProjetoRepositorio
    {
        Task<long> Inserir(Projeto projeto);
        Task<Projeto> ObterPorNome(string nome);
    }
}
