using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public interface IEntity
    {
        DateTime CreateDate { get; set; }
    }
}
