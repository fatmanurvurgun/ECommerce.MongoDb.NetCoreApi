using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Domain.Entity.BaseModel
{
    public abstract class MongoDbEntity : IMongoEntity
    {
        public MongoDbEntity()
        {
            this.CreateDate = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; set; }
    }
}
