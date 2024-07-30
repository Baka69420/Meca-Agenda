using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceBill
    {
        Task<int> AddAsync(BillDTO billDTO);
        Task DeleteAsync(int billId);
        Task<BillDTO> GetAsync(int id);
        Task<ICollection<BillDTO>> ListAsync(int? idBranch, int? idClient, DateOnly? billDate);
        Task UpdateAsync(BillDTO billDTO);
    }
}
