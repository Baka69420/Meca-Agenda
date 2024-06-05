using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Users
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }

    public int? BranchId { get; set; }

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();

    public virtual Branches? Branch { get; set; }
}
