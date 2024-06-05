using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Brand { get; set; }

    public int? StockQuantity { get; set; }

    public virtual Categories? Category { get; set; }
}
