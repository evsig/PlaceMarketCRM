using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.InputModels;
using CRM.API.Models.OutputModels;
using CRM.Core;
using CRM.DB.Models;
using CRM.Repository.Repositories;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet("mostly-sales")] 
        public async ValueTask<ActionResult<List<MostlySalesProductOutputModel>>> GetMostlySalesProduct()
        {
            var result = await _productRepository.GetMostlySalesProduct();
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Product not found");
                return Ok(_mapper.Map<List<MostlySalesProductOutputModel>>(result.RequestData));
            }
            return Problem($"Getting products failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("only-in-store")] 
        public async ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetProductOnlyInStorage()
        {
            ReportTypeEnum reportType = ReportTypeEnum.GetProductOnlyInStorage;
            var result = await _productRepository.GetProductWithCategoryReport(reportType);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Products that are only in store not found");
                return Ok(_mapper.Map<List<ProductWithCategoryOutputModel>>(result.RequestData));
            }
            return Problem($"Getting products failed {result.ExMessage}", statusCode: 520); ;
        }

        [HttpGet("never-sale")] 
        public async ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetProductNeverSale()
        {
            ReportTypeEnum reportType = ReportTypeEnum.GetProductNeverSale;
            var result = await _productRepository.GetProductWithCategoryReport(reportType);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Products that have never been sold not found");
                return Ok(_mapper.Map<List<ProductWithCategoryOutputModel>>(result.RequestData));
            }
            return Problem($"Getting products failed {result.ExMessage}", statusCode: 520); ;
        }

        [HttpGet("is-over")] 
        public async ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetProductOver()
        {
            ReportTypeEnum reportType = ReportTypeEnum.GetProductOver;
            var result = await _productRepository.GetProductWithCategoryReport(reportType);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Products that is over not found");
                return Ok(_mapper.Map<List<ProductWithCategoryOutputModel>>(result.RequestData));
            }
            return Problem($"Getting products failed {result.ExMessage}", statusCode: 520); ;
        }

        [HttpGet("categories-more-five-product")]
        public async ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetСategoriesMoreFiveProducts()
        {
            ReportTypeEnum reportType = ReportTypeEnum.CategoriesMoreFiveProducts;
            var result = await _productRepository.GetProductWithCategoryReport(reportType);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Categories with less than five products not found");
                return Ok(_mapper.Map<List<CountProductsOutputModel>>(result.RequestData));
            }
            return Problem($"Getting categories failed {result.ExMessage}", statusCode: 520); ;
        }
    }
}
