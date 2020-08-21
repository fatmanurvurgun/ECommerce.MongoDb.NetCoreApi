using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.MongoDb.Settings
{
    public interface IDatabaseSetting
    {
        //string ProductCollectionName { get; set; }
        //string PriceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
