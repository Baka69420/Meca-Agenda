using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string Brand { get; set; } = null!;

    public int StockQuantity { get; set; }

    public virtual ICollection<BillItems> BillItems { get; set; } = new List<BillItems>();

    public virtual Categories Category { get; set; } = null!;
}
