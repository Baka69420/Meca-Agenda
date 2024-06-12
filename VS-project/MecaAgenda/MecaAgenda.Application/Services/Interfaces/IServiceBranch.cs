using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceBranch
    {
        Task<ICollection<BranchDTO>> ListAsync();
        Task<ICollection<BranchDTO>> FindByNameAsync(string branchName);
        Task<BranchDTO> GetAsync(int id);
    }
}
