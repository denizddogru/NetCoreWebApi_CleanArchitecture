using App.Repositories.Products;

namespace App.Services.Products;
public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetTopPriceOfProductsAsync(int count);
    Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);
}
