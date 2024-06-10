using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record ScheduleExceptionDTO
    {
        public int ExceptionId { get; set; }

        public int? BranchId { get; set; }

        public DateOnly? Date { get; set; }

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public string? ServicesAffected { get; set; }

        public virtual BranchDTO? Branch { get; set; }
    }
}
