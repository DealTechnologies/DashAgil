using DashAgil.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Entidades
{
    public class SendMail
    {
        public SendMail()
        {
            NomeRemetente = "Dash Ágil";
            Assunto = "Apresentação Dash Ágil";
            Conteudo = Email.email;
            Destinatarios = new List<string>();
            Destinatarios.Add("luciano93p@gmail.com");
        }

        public string NomeRemetente { get; set; }

        public string Assunto { get; set; }

        public string Conteudo { get; set; }

        public List<string> Destinatarios { get; set; }
        public List<string> AnexoPaths { get; set; }
    }
}
