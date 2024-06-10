using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record AppointmentDTO
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

        public virtual BranchDTO? Branch { get; set; }

        public virtual UserDTO? Client { get; set; }

        public virtual ServiceDTO? Service { get; set; }
    }
}
