using System;
using System.Collections.Generic;

namespace MecaAgenda.Infraestructure.Models;

public partial class BranchSchedules
{
    public int ScheduleId { get; set; }

    public int? BranchId { get; set; }

    public byte? DayOfWeek { get; set; }

    public TimeOnly? OpenTime { get; set; }

    public TimeOnly? CloseTime { get; set; }

    public virtual Branches? Branch { get; set; }
}
