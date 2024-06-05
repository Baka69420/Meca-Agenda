using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Services
{
    public int ServiceId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? EstimatedTime { get; set; }

    public string? ToolsRequired { get; set; }

    public string? MaterialsNeeded { get; set; }

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();
}
