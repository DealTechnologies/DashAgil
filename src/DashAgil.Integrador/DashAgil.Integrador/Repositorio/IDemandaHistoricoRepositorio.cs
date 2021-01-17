using DashAgil.Integrador.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IDemandaHistoricoRepositorio
    {
        Task Inserir(DemandaHistorico demandaHistorico);
    }
}
