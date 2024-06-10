using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record BillItemDTO
    {
        public int BillItemId { get; set; }

        public int? BillId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? ProductPrice { get; set; }

        public decimal? Price { get; set; }

        public virtual BillDTO? Bill { get; set; }

        public virtual ProductDTO? Product { get; set; }
    }
}
