using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Api.Models.Response;
using ECommerce.Domain.Entity;
using ECommerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Api
{
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _priceService.GetAllPrice();
            return Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            int idNumber;
            if (string.IsNullOrEmpty(id) || int.TryParse(id, out idNumber) && idNumber < 0)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = "Id is not valid!",
                    ResultType = Core.EnumDefinitions.OperationResultType.Error
                };
                return Ok(base.ResponseModel);
            }
            var result = _priceService.GetPrice(id);

            if (!result.IsSuccess)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = result.Message,
                    ResultType = result.ResultType
                };
                return Ok(base.ResponseModel);
            }
            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post(Price price)
        {
            if (!ModelState.IsValid)
            //TODO ValidationStateHandler Yaz
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = "ValidationError",
                    ResultType = Core.EnumDefinitions.OperationResultType.Warn
                };
                return Ok(base.ResponseModel);
            }
            var serviceResult = _priceService.AddPrice(price);

            if (!serviceResult.IsSuccess)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = serviceResult.Data,
                    Message = string.Format("Operation is Not Completed, {0}", serviceResult.Message),
                    ResultType = serviceResult.ResultType
                };
            }
            else
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = serviceResult.Data,
                    ResultType = serviceResult.ResultType,
                    Message = "Success"
                };
            }
            return Ok(base.ResponseModel);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            int idNumber;
            if (string.IsNullOrEmpty(id) || int.TryParse(id, out idNumber) && idNumber < 0)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = "Id is not valid.Please Check Your Id!",
                    ResultType = Core.EnumDefinitions.OperationResultType.Error
                };
                return Ok(base.ResponseModel);
            }
            var serviceResult = _priceService.DeletePrice(id);

            base.ResponseModel = new RerponseModel
            {
                Data = serviceResult.Data,
                ResultType = serviceResult.ResultType,
                Message = serviceResult.ResultType == Core.EnumDefinitions.OperationResultType.Success ? "Record Deleted Successfully" : string.Format("Warning...{0}", serviceResult.Message)
            };
            return Ok(base.ResponseModel);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
