using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record ProductDTO
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public decimal? Price { get; set; }

        public string? Brand { get; set; }

        public int? StockQuantity { get; set; }

        public virtual List<BillItemDTO> BillItems { get; set; } = new List<BillItemDTO>();

        public virtual CategoryDTO? Category { get; set; }
    }
}
