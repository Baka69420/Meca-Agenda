using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Branches
{
    public int BranchId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();

    public virtual ICollection<Bills> Bills { get; set; } = new List<Bills>();

    public virtual ICollection<BranchSchedules> BranchSchedules { get; set; } = new List<BranchSchedules>();

    public virtual ICollection<ScheduleExceptions> ScheduleExceptions { get; set; } = new List<ScheduleExceptions>();

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
