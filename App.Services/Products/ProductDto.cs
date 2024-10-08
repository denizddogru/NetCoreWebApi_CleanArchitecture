namespace App.Services.Products;

//public record ProductDto
//{
//    public int Id { get; init; }
//    public string Name { get; init; }
//    public decimal Price { get; init; }
//    public int Stock {  get; init; }
//}


// Yukarıdaki class ile aynı. Init keyword', primary constructor'a sahip.
public record ProductDto(int Id, string Name, decimal Price, string Stock);
