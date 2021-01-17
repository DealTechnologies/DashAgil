using DashAgil.Integrador.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IProjetoIntegracaoRepositorio
    {
        Task Inserir(ProjetoIntegracao projetoIntegracao);
        Task<List<ProjetoIntegracao>> ObterPorUrl(string url);
    }
}
