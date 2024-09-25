using App.Repositories.Products;
using System.Net;

namespace App.Services.Products;

// Primary Constructor example ( private readonly IProductRepository _productRepository 
//                              ctor { _productRepository = productRepository; } instead of doing this we have declared a primary constructor


// Automatically creates a private readonly field. productRepository becomes accessible as this.productRepository inside the class


public class ProductService(IProductRepository productRepository) : IProductService
{

    public async Task<ServiceResult<List<Product>>> GetTopPriceOfProductsAsync(int count)
    {
        var products = await productRepository.GetTopPriceOfProductsAsync(count);
        return new ServiceResult<List<Product>>()
        {
            Data = products
        };
      
    }

    public async Task<ServiceResult<Product>> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if(product is null)
        {
            ServiceResult<Product>.Fail("Product not found", HttpStatusCode.NotFound);
        }

        return ServiceResult<Product>.Success(product!);
    }
}
