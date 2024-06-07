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
        Task<ICollection<BranchSchedules>> ListAsync();
        Task<ICollection<BranchSchedules>> GetByBranch(int idBranch);
        Task<BranchSchedules> GetAsync(int id);
    }
}
