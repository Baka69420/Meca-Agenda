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
    public record ProductDTO
    {
        [Display(Name = "Product ID")]
        [ValidateNever]
        public int ProductId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        [DisplayName("Description")]
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; } = null!;

        [DisplayName("Category ID")]
        [Required(ErrorMessage = "{0} is required")]
        public int CategoryId { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal Price { get; set; }

        [DisplayName("Brand")]
        [Required(ErrorMessage = "{0} is required")]
        public string Brand { get; set; } = null!;

        [DisplayName("Stock")]
        [Required(ErrorMessage = "{0} is required")]
        public int StockQuantity { get; set; }

        [ValidateNever]
        public virtual List<BillItemDTO> BillItems { get; set; } = null!;

        [DisplayName("Category")]
        [ValidateNever]
        public virtual CategoryDTO Category { get; set; } = null!;
    }
}
