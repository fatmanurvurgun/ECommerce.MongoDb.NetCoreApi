using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ECommerce.Core.EnumDefinitions;

namespace ECommerce.Api.Models.Response
{
    public class RerponseModel
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public OperationResultType ResultType { get; set; }
    }
}
