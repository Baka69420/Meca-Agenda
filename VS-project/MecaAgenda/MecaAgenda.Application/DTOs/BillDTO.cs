using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.DTOs
{
    public record BillDTO
    {
        public int BillId { get; set; }

        public int? ClientId { get; set; }

        public int? BranchId { get; set; }

        public DateOnly? Date { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? PaymentMethod { get; set; }

        public bool? Paid { get; set; }

        public virtual List<BillItemDTO> BillItems { get; set; } = new List<BillItemDTO>();

        public virtual BranchDTO? Branch { get; set; }

        public virtual UserDTO? Client { get; set; }
    }
}
