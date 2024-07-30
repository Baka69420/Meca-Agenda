using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Appointments
{
    public int AppointmentId { get; set; }

    public int? BillId { get; set; }

    public int ClientId { get; set; }

    public int BranchId { get; set; }

    public int ServiceId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Status { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Bills? Bill { get; set; }

    public virtual Branches Branch { get; set; } = null!;

    public virtual Users Client { get; set; } = null!;

    public virtual Services Service { get; set; } = null!;
}
