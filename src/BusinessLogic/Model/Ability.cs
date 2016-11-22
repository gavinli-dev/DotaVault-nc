using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Models
{
    public class Ability
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("hero_key")]
        public string HeroKey { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }
    }
}
