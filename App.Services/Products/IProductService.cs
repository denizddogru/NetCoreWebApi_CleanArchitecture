namespace App.Services.Products;
public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetTopPriceOfProductsAsync(int count);
    Task<ServiceResult<List<ProductDto>>> GetAllList();
    Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request);
    Task<ServiceResult> DeleteProductAsync(int id);
}
