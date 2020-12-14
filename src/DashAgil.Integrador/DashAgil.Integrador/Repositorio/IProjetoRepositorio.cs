using DashAgil.Integrador.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IProjetoRepositorio
    {
        Task<long> Inserir(Projeto projeto);

        Task<Projeto> ObterPorNome(string nome);

        Task<List<Projeto>> ObterPorOrganizaçãoId(long organizacaoId);

    }
}
