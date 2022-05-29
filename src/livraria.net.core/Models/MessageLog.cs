using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace livraria.net.core.Models
{
    public class MessageLog
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Message { get; set; }

    }

}
