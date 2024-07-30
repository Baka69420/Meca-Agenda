using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record ServiceDTO
    {
        [Display(Name = "Service ID")]
        [ValidateNever]
        public int ServiceId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        [DisplayName("Description")]
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; } = null!;

        [DisplayName("Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

        [DisplayName("Estimated Time")]
        [Required(ErrorMessage = "{0} is required")]
        public int EstimatedTime { get; set; }

        [DisplayName("Required Tools")]
        [ValidateNever]
        public string ToolsRequired { get; set; } = null!;

        [DisplayName("Required Materials")]
        [ValidateNever]
        public string MaterialsNeeded { get; set; } = null!;

        [ValidateNever]
        public virtual List<AppointmentDTO> Appointments { get; set; } = null!;
    }
}
