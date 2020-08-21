using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public interface IModel
    {
        DateTime CreateDate { get; set; }
        bool IsActive { get; set; }
    }
}
