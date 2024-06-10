using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record BranchScheduleDTO
    {
        public int ScheduleId { get; set; }

        public int? BranchId { get; set; }

        public byte? DayOfWeek { get; set; }

        public TimeOnly? OpenTime { get; set; }

        public TimeOnly? CloseTime { get; set; }

        public virtual BranchDTO? Branch { get; set; }
    }
}
