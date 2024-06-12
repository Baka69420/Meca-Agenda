using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceBillItem
    {
        Task<ICollection<BillItemDTO>> ListAsync();
        Task<ICollection<BillItemDTO>> GetByBillAsync(int idBill);
        Task<BillItemDTO> GetAsync(int id);
    }
}
