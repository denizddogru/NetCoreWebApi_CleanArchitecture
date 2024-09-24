using App.Repositories.Products;

namespace App.Services.Products;

// Primary Constructor example ( private readonly IProductRepository _productRepository 
//                              ctor { _productRepository = productRepository; } instead of doing this we have declared a primary constructor


// Automatically creates a private readonly field. productRepository becomes accessible as this.productRepository inside the class


public class ProductService(IProductRepository productRepository) : IProductService
{


}
