using DashAgil.Integrador.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IProjetoRepositorio
    {
        Task<long> Inserir(Projeto projeto);

        Task<List<Projeto>> ObterPorOrganizaçãoId(long organizacaoId);
    }
}
