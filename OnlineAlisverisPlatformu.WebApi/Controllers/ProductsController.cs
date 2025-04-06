using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAlisverisPlatformu.Business.Operations.Products;
using OnlineAlisverisPlatformu.Business.Operations.Products.Dtos;
using OnlineAlisverisPlatformu.WebApi.Models;
using OnlineAlisverisPlatformu.WebApi.Filters;

namespace OnlineAlisverisPlatformu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productService.GetProduct(id);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetProducts();


            return Ok(result);

        }




        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var addProductDto = new AddProductDto
            {
                ProductName = request.ProductName,
                Price = request.Price,
                StockQuantity = request.StockQuantity,


            };

            var result = await _productService.AddProduct(addProductDto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok();
            }
        }
        [HttpPatch("{id}/Price")]
        [Authorize(Roles = "Admin")]
        [TimeControlFilter]
        public async Task<IActionResult> UpdateProductPrice(int id, decimal newPrice)
        {
            var result = await _productService.UpdateProductPrice(id, newPrice);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            {
                return Ok();
            }
        }
        [HttpPatch("{id}/Stock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductStock(int id, int newStock)
        {
            var result = await _productService.UpdateProductStock(id, newStock);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            {
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            {
                return Ok();
            }
        }
        [HttpPut("{id}/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            var updateProductDto = new UpdateProductDto
            {
                Id = id,
                ProductName = request.ProductName,
                Price = request.Price,
                StockQuantity = request.StockQuantity,

            };
            var result = await _productService.UpdateProduct(id, updateProductDto);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            {
                return Ok();
            }
        }
    }
}
