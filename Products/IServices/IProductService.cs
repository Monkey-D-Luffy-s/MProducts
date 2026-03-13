using Products.Models.Dto;

namespace Products.IServices
{
    public interface IProductService
    {
        Task<Response> GetAllProductsAsync();
        Task<Response> GetProductByIdAsync(int id);
        Task<Response> AddProductAsync(AddProductRequest product);
        Task<Response> UpdateProductAsync(UpdateProductRequest product);
        Task<Response> DeleteProductAsync(int id);
    }
}
