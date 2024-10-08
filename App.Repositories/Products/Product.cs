﻿namespace App.Repositories.Products;
public record Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; } = default!;
}


