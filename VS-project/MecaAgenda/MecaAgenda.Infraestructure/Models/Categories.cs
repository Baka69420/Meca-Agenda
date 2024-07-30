using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Categories
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}
