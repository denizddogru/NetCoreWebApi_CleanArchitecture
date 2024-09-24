namespace App.Repositories.Products;
public interface IProductRepository : IGenericRepository<Product>
{
    public Task<List<Product>> GetTopPriceOfProductsAsync(int count);
}
