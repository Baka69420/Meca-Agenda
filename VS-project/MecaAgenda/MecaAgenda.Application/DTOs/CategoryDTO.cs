using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record CategoryDTO
    {
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public virtual List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
