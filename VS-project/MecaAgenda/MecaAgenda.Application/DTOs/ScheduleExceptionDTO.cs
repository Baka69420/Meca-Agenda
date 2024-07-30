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
    public record ScheduleExceptionDTO
    {
        [Display(Name = "Schedule Exception ID")]
        [ValidateNever]
        public int ExceptionId { get; set; }

        [DisplayName("Branch ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int BranchId { get; set; }

        [DisplayName("Reason")]
        [Required(ErrorMessage = "{0} is required")]
        public string Reason { get; set; } = null!;

        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateOnly Date { get; set; }

        [DisplayName("Exception Start")]
        [Required(ErrorMessage = "{0} is required")]
        public TimeOnly StartTime { get; set; }

        [DisplayName("Exception End")]
        [Required(ErrorMessage = "{0} is required")]
        public TimeOnly EndTime { get; set; }

        [DisplayName("Affected Services")]
        [Required(ErrorMessage = "{0} is required")]
        public string ServicesAffected { get; set; } = null!;

        [DisplayName("Branch")]
        [ValidateNever]
        public virtual BranchDTO Branch { get; set; } = null!;
    }
}
