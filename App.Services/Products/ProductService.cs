using App.Repositories;
using App.Repositories.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace App.Services.Products;

// Primary Constructor example ( private readonly IProductRepository _productRepository 
//                              ctor { _productRepository = productRepository; } instead of doing this we have declared a primary constructor


// Automatically creates a private readonly field. productRepository becomes accessible as this.productRepository inside the class


public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IValidator<CreateProductRequest> createProductRequestValidator, IMapper mapper) : IProductService
{

    public async Task<ServiceResult<List<ProductDto>>> GetTopPriceOfProductsAsync(int count)
    {
        var products = await productRepository.GetTopPriceOfProductsAsync(count);

        var productsAsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();

        return new ServiceResult<List<ProductDto>>()
        {
            Data = productsAsDto
        };
      
    }

    public async Task<ServiceResult<List<ProductDto>>> GetAllList()
    {
        var products = await productRepository.GetAll().ToListAsync();

        // Manual Mapping
        //var productAsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
        //return ServiceResult<List<ProductDto>>.Success(productAsDto);

        //  Auto Mapper

        var productsAsDto = mapper.Map<List<ProductDto>>(products);
        return ServiceResult<List<ProductDto>>.Success(productsAsDto);

    }

    public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {

        // Pagination yapısıs

        // 1 - 10 => ilk 10 kayıt skip(0).Take(10)
        // 2- 20 => 11-20 kayıt skip(10).Take(10)

        int skip = (pageNumber - 1) * pageSize;

        var products = await productRepository.GetAll().Skip(skip).Take(pageSize).ToListAsync();
        var productsAsDto = mapper.Map<List<ProductDto>>(products);
        return ServiceResult<List<ProductDto>>.Success(productsAsDto);
    }

    public async Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if(product is null)
        {
           return ServiceResult<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);
        }

        var productsAsDto = mapper.Map<ProductDto>(product);

        return ServiceResult<ProductDto>.Success(productsAsDto)!;
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
    {

        // throw new CriticalException => CriticalException Handler'ımıza takılır, 
        // throw new Exception => Global Exception'a takılır

        var product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id), $"api/products/{product.Id}");


    }

    public async Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        var product = await productRepository.GetByIdAsync(id);

        if(product is null)
        {
            return ServiceResult.Fail("Product not found.", HttpStatusCode.NotFound);
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);

        if(product is null)
        {
            return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
        }

        product.Stock = request.Quantity;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);


    }
         
    public async Task<ServiceResult> DeleteProductAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if(product is null)
        {
            return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
        }

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }



}
