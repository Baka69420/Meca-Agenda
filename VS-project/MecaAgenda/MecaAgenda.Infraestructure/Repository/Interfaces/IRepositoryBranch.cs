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
        Task<ICollection<Branches>> ListAsync();
        Task<ICollection<Branches>> FindByNameAsync(string branchName);
        Task<Branches> GetAsync(int id);
    }
}
