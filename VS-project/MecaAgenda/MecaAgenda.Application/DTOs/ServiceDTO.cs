using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record ServiceDTO
    {
        public int ServiceId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? EstimatedTime { get; set; }

        public string? ToolsRequired { get; set; }

        public string? MaterialsNeeded { get; set; }

        public virtual List<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
    }
}
