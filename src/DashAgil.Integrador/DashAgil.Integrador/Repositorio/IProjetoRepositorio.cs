using DashAgil.Integrador.Entidades;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IProjetoRepositorio
    {
        Task<long> Inserir(Projeto projeto);
<<<<<<< HEAD
        Task<Projeto> ObterPorNome(string nome);
=======

        Task<List<Projeto>> ObterPorOrganizaçãoId(long organizacaoId);
>>>>>>> dev
    }
}
