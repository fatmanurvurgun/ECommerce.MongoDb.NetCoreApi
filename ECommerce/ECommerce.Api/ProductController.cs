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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _productService.GetAllProduct();
            return Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id) || Convert.ToInt32(id) < 0)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = "Id Is Not Valid",
                    ResultType = Core.EnumDefinitions.OperationResultType.Error
                };
                return Ok(base.ResponseModel);
            }

            var serviceResult = _productService.GetProduct(id);

            if (!serviceResult.IsSuccess)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = serviceResult.Data,
                    Message = serviceResult.Message,
                    ResultType = serviceResult.ResultType
                };
                return Ok(serviceResult);
            }
            return Ok(serviceResult);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = "ValidationError",
                    ResultType = Core.EnumDefinitions.OperationResultType.Error
                };
                return Ok(base.ResponseModel);
            }

            var serviceResult = _productService.AddProduct(product);
            //TODO Tesleri yapılacak
            if (!serviceResult.IsSuccess)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = serviceResult.Data,
                    Message = string.Format("Operation Is Not Completed, {0}", serviceResult.Message),
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
            if (string.IsNullOrEmpty(id) || Convert.ToInt32(id) < 0)
            {
                base.ResponseModel = new RerponseModel
                {
                    Data = null,
                    Message = "Id Is Not Valid.Please Check Your Id",
                    ResultType = Core.EnumDefinitions.OperationResultType.Error
                };
                return Ok(base.ResponseModel);
            }

            var serviceResult = _productService.DeleteProduct(id);

            base.ResponseModel = new RerponseModel
            {
                Data = serviceResult.Data,
                ResultType = serviceResult.ResultType,
                Message = serviceResult.ResultType == Core.EnumDefinitions.OperationResultType.Success ? "Record Deleted Successfully" : string.Format("Warning... {0}", serviceResult.Message)
            };
            return Ok(serviceResult);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
