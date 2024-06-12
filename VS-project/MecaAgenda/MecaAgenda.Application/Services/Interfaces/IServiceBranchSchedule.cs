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
        Task<ICollection<BranchScheduleDTO>> ListAsync();
        Task<ICollection<BranchScheduleDTO>> GetByBranch(int idBranch);
        Task<BranchScheduleDTO> GetAsync(int id);
    }
}
