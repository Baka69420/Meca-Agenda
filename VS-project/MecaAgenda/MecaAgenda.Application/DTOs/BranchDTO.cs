using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record BranchDTO
    {
        public int BranchId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public virtual List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();

        public virtual List<BillDTO> Bills { get; set; } = new List<BillDTO>();

        public virtual List<BranchScheduleDTO> BranchSchedules { get; set; } = new List<BranchScheduleDTO>();

        public virtual List<ScheduleExceptionDTO> ScheduleExceptions { get; set; } = new List<ScheduleExceptionDTO>();

        public virtual List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
