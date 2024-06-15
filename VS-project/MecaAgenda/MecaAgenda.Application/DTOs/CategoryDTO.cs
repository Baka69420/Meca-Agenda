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
    public record CategoryDTO
    {
        [Display(Name = "Category ID")]
        [ValidateNever]
        public int CategoryId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        [ValidateNever]
        public virtual List<ProductDTO> Products { get; set; } = null!;
    }
}
