using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Jira.Entidades
{
    public class DadosAcesso
    {
        public DadosAcesso(string token, string baseUrl)
        {
            Token = token;
            BaseUrl = baseUrl;
        }

        public string Token { get; private set; }
        public string BaseUrl { get; private set; }

    }
}
