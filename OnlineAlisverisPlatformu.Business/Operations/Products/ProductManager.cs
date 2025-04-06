using Microsoft.EntityFrameworkCore;
using OnlineAlisverisPlatformu.Business.Operations.Products.Dtos;
using OnlineAlisverisPlatformu.Business.Types;
using OnlineAlisverisPlatformu.Data.Entities;
using OnlineAlisverisPlatformu.Data.Repositories;
using OnlineAlisverisPlatformu.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Business.Operations.Products
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IRepository<OrderProductEntity> _orderProductRepository;
        private readonly IRepository<OrderEntity> _orderRepository;

        public ProductManager(IUnitOfWork unitOfWork, IRepository<ProductEntity> productRepository, IRepository<OrderProductEntity> orderProductRepository , IRepository<OrderEntity> orderRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;


        }
        //public async Task<ServiceMessage> AddProduct(AddProductDto product)
        //{
        //    var hasProduct = _productRepository.GetAll(x => x.ProductName.ToLower() == product.ProductName.ToLower()).Any();
        //    if (hasProduct)
        //    {
        //        return new ServiceMessage
        //        {
        //            IsSucceed = false,
        //            Message = "Product already exists"
        //        };
        //    }
        //    await _unitOfWork.BeginTransaction();
        //    var productEntity = new ProductEntity()
        //    {
        //        ProductName = product.ProductName,
        //        Price = product.Price,
        //        StockQuantity = product.StockQuantity,




        //    };
        //    _productRepository.Add(productEntity);

        //    try
        //    {
        //        await _unitOfWork.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {

        //        throw new Exception("There is some mistake while adding Product");

        //    }

        //    foreach (var orderId in product.OrderProductId)
        //    {
        //        var orderProduct = new OrderProductEntity()
        //        {


        //            OrderId = orderId,

        //        };
        //        _orderProductRepository.Add(orderProduct);
        //    }
        //    try
        //    {
        //        await _unitOfWork.SaveChangesAsync();
        //        await _unitOfWork.CommitTransaction();

        //    }
        //    catch (Exception)
        //    {
        //        await _unitOfWork.RollbackTransaction();
        //        throw new Exception("There is some mistake while adding Hotel Features");
        //    }
        //    return new ServiceMessage
        //    {
        //        IsSucceed = true,
        //    };


        //} this codeblock didn't work because of the orderproductid is not in the product entity. I have added a new property to the product entity and it worked.



        public async Task<ServiceMessage> AddProduct(AddProductDto product)
        {
            var hasProduct = _productRepository.GetAll(x => x.ProductName.ToLower() == product.ProductName.ToLower()).Any();
            if (hasProduct)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Product already exists"
                };
            }

            await _unitOfWork.BeginTransaction();
            var productEntity = new ProductEntity()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
            };

            _productRepository.Add(productEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();

                // Eğer OrderProductId varsa
                if (product.OrderProductId != null && product.OrderProductId.Any())
                {
                    foreach (var orderId in product.OrderProductId)
                    {
                        var orderProduct = new OrderProductEntity()
                        {
                            OrderId = orderId,
                            ProductId = productEntity.Id  // Ürün ile ilişkilendirilen ID
                        };
                        _orderProductRepository.Add(orderProduct);
                    }
                }

                await _unitOfWork.SaveChangesAsync(); // İkinci kez SaveChangesAsync burada yapılabilir
                await _unitOfWork.CommitTransaction();

                return new ServiceMessage
                {
                    IsSucceed = true,
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                throw new Exception($"There is some mistake while adding Product: {ex.Message}", ex);
            }
        }

        public async Task<ServiceMessage> DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Product not found"
                };
            }
            _productRepository.Delete(product);
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Product deleted successfully"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the product: {ex.Message}", ex);
            }


        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _productRepository.GetAll(x => x.Id == id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    StockQuantity = x.StockQuantity,
                })
                .FirstOrDefaultAsync();  // Koleksiyondan tek bir öğe almak için
            return product;
        }


        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _productRepository.GetAll()
              .Select(x => new ProductDto
              {
                  Id = x.Id,
                  ProductName = x.ProductName,
                  Price = x.Price,
                  StockQuantity = x.StockQuantity,
                 



              }).ToListAsync();
            return products;
        }

        public async Task<ServiceMessage> UpdateProduct(int id, UpdateProductDto product)
        {
           var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Product not found"
                };
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            _productRepository.Update(existingProduct);
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Product updated successfully"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the product: {ex.Message}", ex);
            }
            
        }

        public async Task<ServiceMessage> UpdateProductPrice(int id, decimal newPrice)
        {
            var product =  _productRepository.GetById(id);
            if (product == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Product not found"
                };
            }
            product.Price = newPrice;
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Product price updated successfully"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the product price: {ex.Message}", ex);
            }



        }

        public async Task<ServiceMessage> UpdateProductStock(int id, int newStock)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Product not found"
                };
            }
            product.StockQuantity = newStock;
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Product stock updated successfully"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the product stock: {ex.Message}", ex);
            }

        }
    }
}
