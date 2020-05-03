using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DB.Models;
using CRM.DB.Storages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductStorage productStorage = new ProductStorage();

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return productStorage.ProductGetById(id);
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return productStorage.ProductsGetAll();
        }
    }
}