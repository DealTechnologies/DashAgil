using DashAgil.Infra.Comum;
using System.Net;

namespace DashAgil.Commands.Output
{
    public class DashAgilCommandResult : ICommandResult
    {
        public DashAgilCommandResult(bool sucess, string message, object data, HttpStatusCode? statusCode = null)
        {
            this.Success = sucess;
            this.Message = message;
            this.Data = data;
            this.StatusCode = statusCode;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
    }
}
