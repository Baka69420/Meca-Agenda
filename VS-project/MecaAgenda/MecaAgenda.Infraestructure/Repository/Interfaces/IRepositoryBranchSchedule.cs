using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryBranchSchedule
    {
        Task<int> AddAsync(BranchSchedules branchSchedule);
        Task DeleteAsync(int branchScheduleId);
        Task<BranchSchedules> GetAsync(int id);
        Task<ICollection<BranchSchedules>> GetByBranch(int idBranch);
        Task<ICollection<BranchSchedules>> ListAsync();
        Task UpdateAsync(BranchSchedules branchSchedule);
    }
}
