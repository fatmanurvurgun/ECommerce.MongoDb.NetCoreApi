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
    public class ProductService : IProductService
    {
        private readonly IMongoDbContext _context = null;
        protected IMongoCollection<Product> _productCollection;
        protected IMongoCollection<Price> _priceCollection;

        public ProductService(IMongoDbContext context)
        {
            _context = context;
            _productCollection = context.GetCollection<Product>(typeof(Product).Name);
            _priceCollection = context.GetCollection<Price>(typeof(Price).Name);
        }

        public ServiceResultModel<Product> AddProduct(Product product)
        {
            bool isAlreadyExist = _productCollection.Find<Product>(x => x.Name == product.Name && x.Barcode == product.Barcode).Any();
            if (isAlreadyExist)
            {
                return new ServiceResultModel<Product>
                {
                    Code = ServiceResultCode.Duplicate,
                    Data = null,
                    ResultType = OperationResultType.Warn,
                    Message = "This record already exists"
                };
            }
            _productCollection.InsertOne(product);
            return ServiceResultModel<Product>.OK(product);
        }

        public ServiceResultModel<Product> DeleteProduct(string id)
        {
            Product product = _productCollection.Find<Product>(x => x.Id == id).FirstOrDefault();
            _productCollection.DeleteOne(x => x.Id == product.Id);
            return ServiceResultModel<Product>.OK(product);
        }

        public ServiceResultModel<List<Product>> GetAllProduct()
        {
            List<Product> resultList = _productCollection.Find(x => true).ToList();
            foreach (Product item in resultList)
            {
                if (item.Prices != null)
                    item.PriceList = _priceCollection.Find<Price>(x => item.Prices.Contains(x.Id)).ToList();

            }
            return ServiceResultModel<List<Product>>.OK(resultList);
        }

        public ServiceResultModel<Product> GetProduct(string id)
        {
            Product product = _productCollection.Find<Product>(x => x.Id == id).FirstOrDefault();

            if (product == null)
            {
                return new ServiceResultModel<Product>
                {
                    Code = ServiceResultCode.NotFound,
                    Data = null,
                    Message = "This Record Is Not Found, Please Check Your Id!",
                    ResultType = OperationResultType.Warn
                };
            }

            if (product.Prices != null)
            {
                var tempList = new List<Price>();
                foreach (var priceId in product.Prices)
                {
                    Price price = _priceCollection.Find<Price>(x => x.Id == priceId).FirstOrDefault();

                    if (price != null)
                        tempList.Add(price);
                }
                product.PriceList = tempList;
            }
            return ServiceResultModel<Product>.OK(product);
        }


    }
}
