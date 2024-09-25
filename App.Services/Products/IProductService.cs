using App.Repositories.Products;

namespace App.Services.Products;
public interface IProductService
{
    Task<ServiceResult<List<Product>>> GetTopPriceOfProductsAsync(int count);
    Task<ServiceResult<Product>> GetProductByIdAsync(int id);
}
