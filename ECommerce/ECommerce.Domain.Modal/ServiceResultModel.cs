using System;
using System.Collections.Generic;
using System.Text;
using static ECommerce.Core.EnumDefinitions;

namespace ECommerce.Domain.Modal
{
    public class ServiceResultModel<T> where T : class
    {
        #region Ctor
        public ServiceResultModel()
        {

        }

        public ServiceResultModel(T data)
        {

        }

        public ServiceResultModel(OperationResultType resultType, T data)
        {
            this.ResultType = resultType;
            this.Data = data;
        }
        #endregion

        #region Prop
        public ServiceResultCode Code { get; set; }
        public string Message { get; set; }
        public OperationResultType ResultType { get; set; }
        public T Data { get; set; }
        #endregion

        public bool IsSuccess
        {
            get
            {
                return this.ResultType == OperationResultType.Success && this.Data != null;
            }
        }

        public static ServiceResultModel<T> OK(T data) => new ServiceResultModel<T>(OperationResultType.Success, data);
    }
}
