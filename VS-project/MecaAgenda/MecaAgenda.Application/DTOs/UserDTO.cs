using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record UserDTO
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

        public virtual List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();

        public virtual List<BillDTO> Bills { get; set; } = new List<BillDTO>();

        public virtual BranchDTO? Branch { get; set; }
    }
}
