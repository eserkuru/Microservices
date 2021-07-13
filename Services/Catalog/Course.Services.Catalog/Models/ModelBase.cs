using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Course.Services.Catalog.Models
{
    public class ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
