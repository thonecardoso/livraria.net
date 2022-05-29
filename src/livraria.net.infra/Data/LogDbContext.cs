using livraria.net.core.Models;
using MongoDB.Driver;
using System;

namespace livraria.net.infra.Data
{
    public class LogDbContext : IDisposable
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _dataBase;

        public LogDbContext(string connectionString = null, string db = null)
        {
            _client = new MongoClient(connectionString);
            _dataBase = _client.GetDatabase(db);
        }

        public IMongoDatabase Database => _dataBase;
        public IMongoClient Client => _client;

        public IMongoCollection<MessageLog> Messages
        {
            get
            {
                return _dataBase.GetCollection<MessageLog>("Messages");
            }
        }

        public void Dispose()
        {
        }
    }
}
