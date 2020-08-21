using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core
{
    public class EnumDefinitions
    {
        private EnumDefinitions()
        {
        }


        public enum ServiceResultCode
        {
            None = 0,
            EmailIsNotConfirmed= 5001,
            Duplicate = 5002,
            NotFound = 5003,
            ValidationError = 5004
        }

        public enum OperationResultType
        {
            None=0,
            Success = 1,
            Warn=2,
            Error=3
        }
    }
}
