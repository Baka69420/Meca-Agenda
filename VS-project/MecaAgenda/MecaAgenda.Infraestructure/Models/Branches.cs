using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Branches
{
    public int BranchId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();

    public virtual ICollection<Bills> Bills { get; set; } = new List<Bills>();

    public virtual ICollection<BranchSchedules> BranchSchedules { get; set; } = new List<BranchSchedules>();

    public virtual ICollection<ScheduleExceptions> ScheduleExceptions { get; set; } = new List<ScheduleExceptions>();

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
