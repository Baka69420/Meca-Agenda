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
    public record BillItemDTO
    {
        [Display(Name = "Bill Item ID")]
        [ValidateNever]
        public int BillItemId { get; set; }

        [DisplayName("Bill ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int BillId { get; set; }

        [DisplayName("Product ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int ProductId { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "{0} is required")]
        public int Quantity { get; set; }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal ProductPrice { get; set; }

        [DisplayName("Line Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

        [DisplayName("Bill")]
        [ValidateNever]
        public virtual BillDTO Bill { get; set; } = null!;

        [DisplayName("Product")]
        [ValidateNever]
        public virtual ProductDTO Product { get; set; } = null!;
    }
}
