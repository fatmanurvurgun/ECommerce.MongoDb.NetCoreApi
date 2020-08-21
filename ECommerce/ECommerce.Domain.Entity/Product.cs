using ECommerce.Domain.Entity.BaseModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Entities;

namespace ECommerce.Domain.Entity
{
    public class Product : MongoDbEntity 
    {
        public Product()
        {
            this.IsActive = true;
            this.IsDeleted = false;
        }
        [BsonRequired]
        public string Name { get; set; }
        public double SKU { get; set; }
        public double Barcode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Prices { get; set; }
        [BsonIgnore]
        public List<Price> PriceList { get; set; }

    }
}
