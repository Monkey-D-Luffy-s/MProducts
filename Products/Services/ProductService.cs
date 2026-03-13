using Products.IRepo;
using Products.IServices;
using Products.Models;
using Products.Models.Dto;

namespace Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Response> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllProductsAsync();
            if (products == null || !products.Any())
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No products found."
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = true,
                    Data = products
                };
            }

        }

        public async Task<Response> GetProductByIdAsync(int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = $"Product with ID {id} not found."
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = true,
                    Data = product
                };
            }
        }

        public async Task<Response> AddProductAsync(AddProductRequest product)
        {
            Product productToAdd = new Product
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                InStock = product.InStock
            };
            await _productRepo.AddProductAsync(productToAdd);
            return new Response
            {
                IsSuccess = true,
                Message = "Product added successfully."
            };
        }

        public async Task<Response> UpdateProductAsync(UpdateProductRequest product)
        {
            var existingProduct = await _productRepo.GetProductByIdAsync(product.ProductId);
            if (existingProduct == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = $"Product with ID {product.ProductId} not found."
                };
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.InStock = product.InStock;
            await _productRepo.UpdateProductAsync(existingProduct);
            return new Response
            {
                IsSuccess = true,
                Message = "Product updated successfully."
            };
        }

        public async Task<Response> DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepo.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = $"Product with ID {id} not found."
                };
            }
            await _productRepo.DeleteProductAsync(id);
            return new Response
            {
                IsSuccess = true,
                Message = "Product deleted successfully."
            };

        }
    }
}
