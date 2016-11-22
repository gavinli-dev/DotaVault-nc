using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessLogic.Models
{
    public class Role
    {
        [BsonElement("hard_carry")]
        public Byte HardCarry;

        [BsonElement("semi_carry")]
        public Byte SemiCarry;

        [BsonElement("ganker")]
        public Byte Ganker;

        [BsonElement("roamer")]
        public Byte Roamer;

        [BsonElement("offlaner")]
        public Byte Offlaner;
    }
}
