using ECommerce.Data.MongoDb.Context;
using ECommerce.Domain.Entity;
using ECommerce.Domain.Modal;
using ECommerce.Service.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using static ECommerce.Core.EnumDefinitions;

namespace ECommerce.Service.Services
{
    public class PriceService : IPriceService
    {
        private readonly IMongoDbContext _context = null;
        protected IMongoCollection<Price> _dbCollection;
        public PriceService(IMongoDbContext context)
        {
            _context = context;
            _dbCollection = context.GetCollection<Price>(typeof(Price).Name);
        }
        public ServiceResultModel<Price> AddPrice(Price price)
        {
            bool isAlreadyExist = _dbCollection.Find<Price>(x => x.Cost == price.Cost && x.Time == price.Time).Any();

            if (isAlreadyExist)
            {
                return new ServiceResultModel<Price>
                {
                    Code = ServiceResultCode.Duplicate,
                    Data = null,
                    Message = "This record already exits",
                    ResultType = OperationResultType.Warn
                };
            }
            _dbCollection.InsertOne(price);
            return ServiceResultModel<Price>.OK(price);

        }

        public ServiceResultModel<Price> DeletePrice(string id)
        {
            Price price = _dbCollection.Find<Price>(x => x.Id == id).FirstOrDefault();
            _dbCollection.DeleteOne(x => x.Id == id);
            return ServiceResultModel<Price>.OK(price);
        }

        public ServiceResultModel<List<Price>> GetAllPrice()
        {
            List<Price> prices = _dbCollection.Find<Price>(x => true).ToList();
            return ServiceResultModel<List<Price>>.OK(prices);
        }

        public ServiceResultModel<Price> GetPrice(string id)
        {
            Price price = _dbCollection.Find<Price>(x => x.Id == id).FirstOrDefault();

            if (price == null)
            {
                return new ServiceResultModel<Price>
                {
                    Code = ServiceResultCode.NotFound,
                    Data = null,
                    Message = "This record is not found, Please check your id!",
                    ResultType = OperationResultType.Warn
                };
            }

            return ServiceResultModel<Price>.OK(price);
        }
    }
}
