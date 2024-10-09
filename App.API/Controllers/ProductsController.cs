using App.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : CustomBaseController
{

    [HttpGet]
    public async Task<IActionResult> GetAllList()
    {

        return CreateActionResult(await productService.GetAllList());
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize) => CreateActionResult(await productService.GetPagedAllListAsync(pageNumber, pageSize));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id) => CreateActionResult(await productService.GetProductByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productService.CreateProductAsync(request));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductRequest request) => CreateActionResult(await productService.UpdateProductAsync(id, request));


    [HttpPatch("stock")]
    public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) => CreateActionResult(await productService.UpdateStockAsync(request));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteProductAsync(id));
}
