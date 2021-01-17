using DashAgil.Integrador.Infra.Comum;
using System.Drawing;

namespace DashAgil.Integrador.Commands.Output
{
    public class IntegradorCommandResult : ICommandResult
    {
        public IntegradorCommandResult(bool sucess, string message, object data)
        {
            this.Success = sucess;
            this.Message = message;
            this.Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
