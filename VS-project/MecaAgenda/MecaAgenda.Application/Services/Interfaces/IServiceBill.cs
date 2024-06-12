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
        Task<ICollection<BillDTO>> ListAsync();
        Task<ICollection<BillDTO>> GetByBranchAsync(int idBranch);
        Task<ICollection<BillDTO>> GetByDateAsync(DateOnly billDate);
        Task<ICollection<BillDTO>> GetByClientAsync(int idClient);
        Task<ICollection<BillDTO>> GetByBranchAndClientAsync(int idBranch, int idClient);
        Task<ICollection<BillDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly billDate);
        Task<ICollection<BillDTO>> GetByClientAndDateAsync(int idClient, DateOnly billDate);
        Task<BillDTO> GetAsync(int id);
    }
}
