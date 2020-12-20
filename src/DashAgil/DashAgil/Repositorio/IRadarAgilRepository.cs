using DashAgil.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Repositorio
{
    public interface IRadarAgilRepository
    {
        Task Inserir(RadarAgil radar);

        Task<List<RadarAgil>> Obter(string squadId);


    }
}
