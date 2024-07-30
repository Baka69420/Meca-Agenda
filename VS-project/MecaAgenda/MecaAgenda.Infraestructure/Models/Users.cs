using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Users
{
    public int UserId { get; set; }

    public int? BranchId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();

    public virtual ICollection<Bills> Bills { get; set; } = new List<Bills>();

    public virtual Branches? Branch { get; set; }
}
