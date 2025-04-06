using OnlineAlisverisPlatformu.Business.Operations.Products.Dtos;
using OnlineAlisverisPlatformu.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Business.Operations.Products
{
    public interface IProductService
    {
        Task<ServiceMessage> AddProduct(AddProductDto product);
        Task<ProductDto> GetProduct(int id);
        Task<List<ProductDto>> GetProducts();
        Task<ServiceMessage> UpdateProductPrice(int id, decimal newPrice);
        Task<ServiceMessage> UpdateProductStock(int id, int newStock);
        Task<ServiceMessage> DeleteProduct(int id);
        Task<ServiceMessage> UpdateProduct(int id, UpdateProductDto product);
    }
}
