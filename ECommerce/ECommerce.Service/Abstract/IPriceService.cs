using ECommerce.Domain.Entity;
using ECommerce.Domain.Modal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Abstract
{
    public interface IPriceService : IServiceBase
    {
        ServiceResultModel<Price> AddPrice(Price price);
        ServiceResultModel<List<Price>> GetAllPrice();
        ServiceResultModel<Price> GetPrice(string id);
        ServiceResultModel<Price> DeletePrice(string id);
    }
}
