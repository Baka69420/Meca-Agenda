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
    public record BranchScheduleDTO
    {
        [Display(Name = "Schedule ID")]
        [ValidateNever]
        public int ScheduleId { get; set; }

        [DisplayName("Branch ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int BranchId { get; set; }

        [DisplayName("Day of Week")]
        [Required(ErrorMessage = "{0} is required")]
        public byte DayOfWeek { get; set; }

        [DisplayName("Opening Time")]
        [Required(ErrorMessage = "{0} is required")]
        public TimeOnly OpenTime { get; set; }

        [DisplayName("Closing Time")]
        [Required(ErrorMessage = "{0} is required")]
        public TimeOnly CloseTime { get; set; }

        [DisplayName("Branch")]
        [ValidateNever]
        public virtual BranchDTO Branch { get; set; } = null!;
    }
}
