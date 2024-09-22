using TTS.Entity.DTOs.Market.Products;
using TTS.Entity.Entities.Market;

namespace TTS.Service.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsNonDeletedAsync();
        Task<List<ProductDto>> GetAllProductsWithUserNonDeletedAsync();
        Task<List<ProductDto>> GetAllProductsDeletedAsync();
        Task CreateProductAsync(ProductAddDto productAddDto);
        Task<Product> GetProductByGuidAsync(Guid id);
        Task<string> UpdateProductAsync(ProductUpdateDto productUpdateDto);
        Task<string> SafeDeleteProductAsync(Guid productId);
        Task<string> UndoDeleteProductAsync(Guid productId);
    }
}
