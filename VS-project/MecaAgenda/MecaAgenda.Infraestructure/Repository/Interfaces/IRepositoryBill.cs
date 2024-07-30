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
        Task<ICollection<Bills>> ListAsync(int? idBranch, int? idClient, DateOnly? billDate);
        Task UpdateAsync(Bills bill);
    }
}
