using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public interface IMongoEntity : IEntity
    {
        string Id { get; set; }
    }
}
