using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Data.MongoDb.Settings;
using MongoDB.Driver;

namespace ECommerce.Data.MongoDb.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        IMongoDatabase IMongoDbContext.db { get { return _db; } }
        MongoClient IMongoDbContext.mongoClient { get { return _mongoClient; } }

        public MongoDbContext(IDatabaseSetting settings)
        {
            _mongoClient = new MongoClient(settings.ConnectionString);
            _db = _mongoClient.GetDatabase(settings.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
