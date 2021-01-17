using DashAgil.Integrador.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface ISquadRepositorio
    {
        Task<long> Inserir(Squad squad);

        Task<Squad> ObterPorNome(string nome);

        Task<IEnumerable<Squad>> ObterPorProjetoId(long projetoId);
    }
}
