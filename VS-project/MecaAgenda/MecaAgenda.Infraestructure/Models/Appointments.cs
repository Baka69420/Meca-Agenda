using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Appointments
{
    public int AppointmentId { get; set; }

    public int? ClientId { get; set; }

    public int? BranchId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime? AppointmentStart { get; set; }

    public DateTime? AppointmentEnd { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Bills> Bills { get; set; } = new List<Bills>();

    public virtual Branches? Branch { get; set; }

    public virtual Users? Client { get; set; }

    public virtual Services? Service { get; set; }
}
