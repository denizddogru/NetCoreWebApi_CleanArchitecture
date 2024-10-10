using System.Threading.Tasks;
using App.Services.Products.Create;
using App.Services.Products.Update;

namespace App.Services.Products;
public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetTopPriceOfProductsAsync(int count);
    Task<ServiceResult<List<ProductDto>>> GetAllList();
    Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
    Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request);

    Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request);
    Task<ServiceResult> DeleteProductAsync(int id);
}
