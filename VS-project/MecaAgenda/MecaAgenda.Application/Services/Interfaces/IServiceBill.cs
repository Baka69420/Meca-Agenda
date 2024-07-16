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
        Task<BillDTO> GetAsync(int id);
        Task<ICollection<BillDTO>> GetByBranchAndClientAsync(int idBranch, int idClient);
        Task<ICollection<BillDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly billDate);
        Task<ICollection<BillDTO>> GetByBranchAsync(int idBranch);
        Task<ICollection<BillDTO>> GetByClientAndDateAsync(int idClient, DateOnly billDate);
        Task<ICollection<BillDTO>> GetByClientAsync(int idClient);
        Task<ICollection<BillDTO>> GetByDateAsync(DateOnly billDate);
        Task<ICollection<BillDTO>> ListAsync();
        Task UpdateAsync(BillDTO billDTO);
        Task DeleteAsync(int billId);
    }
}
