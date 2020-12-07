using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Entidades.Devops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface IAzureDevopsRepository
    { 
        void SalvarProjetos(List<ProjetosDevops> projetos);
        void SalvarTiposWorkItens(List<TiposWorkItensDevops> tipos);
        void test();
    }
}
