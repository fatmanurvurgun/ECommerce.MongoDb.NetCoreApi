using ECommerce.Domain.Entity.BaseModel;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Domain.Entity
{
    public class Price : MongoDbEntity
    {
        public Price()
        {
            this.IsActive = true;
            this.IsDeleted = false;
        }
        [BsonRequired]
        [Required]
        public double Cost { get; set; }
        public DateTime Time { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
