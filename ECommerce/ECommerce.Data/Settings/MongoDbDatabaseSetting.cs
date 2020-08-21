using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.MongoDb.Settings
{
    public class MongoDbDatabaseSetting : IDatabaseSetting
    {
        //public string ProductCollectionName { get; set; }
        //public string PriceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
