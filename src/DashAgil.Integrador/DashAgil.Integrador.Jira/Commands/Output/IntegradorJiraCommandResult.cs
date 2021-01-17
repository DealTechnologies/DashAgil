using DashAgil.Integrador.Infra.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Jira.Commands.Output
{
    public class IntegradorJiraCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public IntegradorJiraCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
