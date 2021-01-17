using DashAgil.Infra.Comum;

namespace DashAgil.Commands.Output
{
    public class DashAgilCommandResult : ICommandResult
    {
        public DashAgilCommandResult(bool sucess, string message, object data)
        {
            Success = sucess;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
