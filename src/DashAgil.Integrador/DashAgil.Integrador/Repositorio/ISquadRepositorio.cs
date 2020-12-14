using DashAgil.Integrador.Entidades;


using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface ISquadRepositorio
    {
        Task<long> Inserir(Squad squad);

        Task<Squad> ObterPorNome(string nome);


    }
}
