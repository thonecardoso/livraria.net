using livraria.net.core.Contracts.Logger;
using livraria.net.infra.RabbitMq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace livraria.net.api.Logger
{

    public class Log : ILog
    {
        private readonly IMessageService _messageService;

        public Log(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<bool> Error(int id, string message, string operationType)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Information(int id, string message, string operationType)
        {
            
            return await _messageService.Enqueue(JsonConvert.SerializeObject(new { Id = id, Message = message, OperationType = operationType }, Formatting.None));
        }
    }
}
