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
        Task<int> AddAsync(BillItemDTO BillItemDTO);
        Task DeleteAsync(int billId);
        Task<BillItemDTO> GetAsync(int id);
        Task<ICollection<BillItemDTO>> GetByBillAsync(int idBill);
        Task<ICollection<BillItemDTO>> ListAsync();
        Task UpdateAsync(BillItemDTO BillItemDTO);
    }
}
