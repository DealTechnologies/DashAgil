using DashAgil.Infra.Comum;

namespace DashAgil.Commands.Output
{
    public class DemandaCommandResult : ICommandResult
    {
        public DemandaCommandResult(bool sucess, string message, object data)
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
