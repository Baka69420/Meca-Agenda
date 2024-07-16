using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryBill
    {
        Task<int> AddAsync(Bills bill);
        Task DeleteAsync(int billId);
        Task<Bills> GetAsync(int id);
        Task<ICollection<Bills>> GetByBranchAndClientAsync(int idBranch, int idClient);
        Task<ICollection<Bills>> GetByBranchAndDateAsync(int idBranch, DateOnly billDate);
        Task<ICollection<Bills>> GetByBranchAsync(int idBranch);
        Task<ICollection<Bills>> GetByClientAndDateAsync(int idClient, DateOnly billDate);
        Task<ICollection<Bills>> GetByClientAsync(int idClient);
        Task<ICollection<Bills>> GetByDateAsync(DateOnly billDate);
        Task<ICollection<Bills>> ListAsync();
        Task UpdateAsync(Bills bill);
    }
}
