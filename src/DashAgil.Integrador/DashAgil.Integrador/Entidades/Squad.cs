using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Text;
>>>>>>> dev

namespace DashAgil.Integrador.Entidades
{
    public class Squad
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long ProjetoId { get; set; }
        public long? SubSquadId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Status { get; set; }


        public static Squad PreencherInsercao(string nome, long projetoId)
        {
            return new Squad()
            {
                Nome = nome,
                ProjetoId = projetoId,
                DataInicio = DateTime.Now,
                Descricao = nome
            };

        }
<<<<<<< HEAD
=======


>>>>>>> dev
    }
}
