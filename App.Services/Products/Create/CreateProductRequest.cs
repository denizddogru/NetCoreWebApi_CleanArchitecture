namespace App.Services.Products.Create;
public record CreateProductRequest(string Name, decimal Price, int Stock);

// We can declare this record like defining a class, we just used primary constructor above.