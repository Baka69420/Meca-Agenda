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
    public record BillDTO
    {
        [Display(Name = "Bill ID")]
        [ValidateNever]
        public int BillId { get; set; }

        [DisplayName("Client ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int ClientId { get; set; }

        [DisplayName("Branch ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int BranchId { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateOnly Date { get; set; }

        [DisplayName("Total")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal TotalAmount { get; set; }

        [DisplayName("Payment Method")]
        [Required(ErrorMessage = "{0} is required")]
        public string PaymentMethod { get; set; } = null!;

        [DisplayName("Payment Status")]
        [Required(ErrorMessage = "{0} is required")]
        public bool Paid { get; set; }

        [ValidateNever]
        public virtual List<BillItemDTO> BillItems { get; set; } = null!;

        [DisplayName("Branch")]
        [ValidateNever]
        public virtual BranchDTO Branch { get; set; } = null!;

        [DisplayName("Client")]
        [ValidateNever]
        public virtual UserDTO Client { get; set; } = null!;
    }
}
