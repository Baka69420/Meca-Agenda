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
    public record BranchDTO
    {
        [Display(Name = "Branch ID")]
        [ValidateNever]
        public int BranchId { get; set; }

        [DisplayName("Branch Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        [DisplayName("Description")]
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; } = null!;

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "{0} is required")]
        public string Phone { get; set; } = null!;

        [DisplayName("Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; } = null!;

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; } = null!;

        [ValidateNever]
        public virtual List<AppointmentDTO> Appointments { get; set; } = null!;

        [ValidateNever]
        public virtual List<BillDTO> Bills { get; set; } = null!;

        [ValidateNever]
        public virtual List<BranchScheduleDTO> BranchSchedules { get; set; } = null!;

        [ValidateNever]
        public virtual List<ScheduleExceptionDTO> ScheduleExceptions { get; set; } = null!;

        [ValidateNever]
        public virtual List<UserDTO> Users { get; set; } = null!;
    }
}
