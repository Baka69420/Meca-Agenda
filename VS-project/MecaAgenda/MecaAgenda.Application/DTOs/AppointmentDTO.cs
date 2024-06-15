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
    public record AppointmentDTO
    {
        [Display(Name = "Appointment ID")]
        [ValidateNever]
        public int AppointmentId { get; set; }
        
        [DisplayName("Client ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int ClientId { get; set; }

        [DisplayName("Branch ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int BranchId { get; set; }

        [DisplayName("Service ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int ServiceId { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateOnly Date { get; set; }

        [DisplayName("Appointment Start")]
        [Required(ErrorMessage = "{0} is required")]
        public TimeOnly StartTime { get; set; }

        [DisplayName("Appointment End")]
        [Required(ErrorMessage = "{0} is required")]
        public TimeOnly EndTime { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "{0} is required")]
        public string Status { get; set; } = null!;

        [DisplayName("Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

        [DisplayName("Payment Method")]
        [Required(ErrorMessage = "{0} is required")]
        public string PaymentMethod { get; set; } = null!;

        [DisplayName("Payment Status")]
        [Required(ErrorMessage = "{0} is required")]
        public bool Paid { get; set; }

        [DisplayName("Branch")]
        [ValidateNever]
        public virtual BranchDTO Branch { get; set; } = null!;

        [DisplayName("Client")]
        [ValidateNever]
        public virtual UserDTO Client { get; set; } = null!;

        [DisplayName("Service")]
        [ValidateNever]
        public virtual ServiceDTO Service { get; set; } = null!;
    }
}
