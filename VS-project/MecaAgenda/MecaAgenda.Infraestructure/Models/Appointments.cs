using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class Appointments
{
    public int AppointmentId { get; set; }

    public int? ClientId { get; set; }

    public int? BranchId { get; set; }

    public int? ServiceId { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? Status { get; set; }

    public decimal? Price { get; set; }

    public string? PaymentMethod { get; set; }

    public bool? Paid { get; set; }

    public virtual Branches? Branch { get; set; }

    public virtual Users? Client { get; set; }

    public virtual Services? Service { get; set; }
}
