﻿namespace App.Repositories;
public record Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Stock { get; set; } = default!;
}


