using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Models
{
    public class Hero
    {
        public enum HeroFaction
        {
            radiant,
            dire
        }

        public enum HeroPrimaryAttribute
        {
            agility,
            intelligence,
            strength
        }

        public enum HeroAttackType
        {
            melee,
            ranged
        }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("faction")]
        public HeroFaction Faction { get; set; }

        [BsonElement("primary_attribute")]
        public HeroPrimaryAttribute PrimaryAttribute { get; set; }

        [BsonElement("attack_type")]
        public HeroAttackType AttackType { get; set; }

        [BsonElement("role")]
        public Role Role { get; set; }

        [BsonElement("abilities")]
        public List<HeroAbility> Abilities { get; set; }
    }
}
