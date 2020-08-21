using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.MongoDb.Context
{
    public interface IMongoDbContext
    {
        IMongoDatabase db { get; }
        MongoClient mongoClient { get; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}