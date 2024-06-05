using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class ScheduleExceptions
{
    public int ExceptionId { get; set; }

    public int? BranchId { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? ServicesAffected { get; set; }

    public virtual Branches? Branch { get; set; }
}
