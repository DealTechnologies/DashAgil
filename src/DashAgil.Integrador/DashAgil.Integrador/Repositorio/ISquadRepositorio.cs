using DashAgil.Integrador.Entidades;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface ISquadRepositorio
    {
        Task<long> Inserir(Squad squad);

        Task<Squad> ObterPorNome(string nome);


    }
}
