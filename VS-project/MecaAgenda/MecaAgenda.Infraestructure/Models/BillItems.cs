using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class BillItems
{
    public int BillItemId { get; set; }

    public int BillId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal ProductPrice { get; set; }

    public decimal Price { get; set; }

    public virtual Bills Bill { get; set; } = null!;

    public virtual Products Product { get; set; } = null!;
}
