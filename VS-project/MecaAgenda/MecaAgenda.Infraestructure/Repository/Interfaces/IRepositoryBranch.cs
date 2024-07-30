using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryBranch
    {
        Task<int> AddAsync(Branches branch);
        Task DeleteAsync(int branchId);
        Task<Branches> GetAsync(int id);
        Task<ICollection<Branches>> ListAsync(string branchName);
        Task UpdateAsync(Branches branch);
    }
}
