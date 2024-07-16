using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceBranchSchedule
    {
        Task<int> AddAsync(BranchScheduleDTO branchScheduleDTO);
        Task DeleteAsync(int branchScheduleId);
        Task<BranchScheduleDTO> GetAsync(int id);
        Task<ICollection<BranchScheduleDTO>> GetByBranch(int idBranch);
        Task<ICollection<BranchScheduleDTO>> ListAsync();
        Task UpdateAsync(BranchScheduleDTO branchScheduleDTO);
    }
}
