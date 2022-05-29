using livraria.net.core.Contracts;
using livraria.net.core.Models;
using livraria.net.infra.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace livraria.net.api.Logger
{

    public class Log : ILog
    {
        private readonly LogDbContext _logDbContext;

        public Log(LogDbContext logDbContext)
        {
            _logDbContext = logDbContext;
        }

        public async Task Error(int id, string message, string operationType)
        {
            throw new System.NotImplementedException();
        }

        public async Task Information(int id, string message, string operationType)
        {
            var messageLog = new MessageLog
            {
                Message = JsonConvert.SerializeObject(
                    new { Id = id, Message = message, OperationType = operationType }, Formatting.None
                    )
            };
            await _logDbContext.Messages.InsertOneAsync(messageLog);
        }
    }
}
