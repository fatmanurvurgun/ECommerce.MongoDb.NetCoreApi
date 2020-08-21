using ECommerce.Domain.Entity;
using ECommerce.Domain.Modal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Abstract
{
    public interface IProductService : IServiceBase
    {
        ServiceResultModel<Product> AddProduct(Product product);
        ServiceResultModel<List<Product>> GetAllProduct();
        ServiceResultModel<Product> GetProduct(string id);
        ServiceResultModel<Product> DeleteProduct(string id);
    }
}
