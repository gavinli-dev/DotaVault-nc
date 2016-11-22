using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Models
{
    public class HeroAbility
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("use_uploaded_icon")]
        public bool UseUploadedIcon { get; set; }

        [BsonElement("icon_name")]
        public string IconName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}
