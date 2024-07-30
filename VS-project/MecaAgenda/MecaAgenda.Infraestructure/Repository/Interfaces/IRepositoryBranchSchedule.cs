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
        Task<ICollection<BranchSchedules>> ListAsync(int? idBranch);
        Task UpdateAsync(BranchSchedules branchSchedule);
    }
}
