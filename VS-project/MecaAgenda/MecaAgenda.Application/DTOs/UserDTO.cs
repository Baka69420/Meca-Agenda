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
    public record UserDTO
    {
        [Display(Name = "User ID")]
        [ValidateNever]
        public int UserId { get; set; }

        [DisplayName("Branch ID")]
        [ValidateNever]
        public int? BranchId { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "{0} is required")]
        public string Phone { get; set; } = null!;

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} is not valid")]
        public string Email { get; set; } = null!;

        [DisplayName("Address")]
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; } = null!;

        [DisplayName("Birth Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateOnly BirthDate { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(8, ErrorMessage = "{0} must contain at least 8 characters")]
        public string PasswordHash { get; set; } = null!;

        [DisplayName("Role")]
        [Required(ErrorMessage = "{0} is required")]
        public string Role { get; set; } = null!;

        [ValidateNever]
        public virtual List<AppointmentDTO> Appointments { get; set; } = null!;

        [ValidateNever]
        public virtual List<BillDTO> Bills { get; set; } = null!;

        [DisplayName("Branch")]
        [ValidateNever]
        public virtual BranchDTO Branch { get; set; } = null!;
    }
}
