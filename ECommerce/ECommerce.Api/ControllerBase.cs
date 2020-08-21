using ECommerce.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api
{
    public abstract class ControllerBase : Controller
    {
        public ControllerBase()
        {

        }

        public RerponseModel ResponseModel { get; set; }
    }
}
