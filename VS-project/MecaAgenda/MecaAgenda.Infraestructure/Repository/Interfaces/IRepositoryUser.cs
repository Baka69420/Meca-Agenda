using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryUser
    {
        Task<int> AddAsync(Users user);
        Task DeleteAsync(int userId);
        Task<ICollection<Users>> FindByNameAsync(string userName);
        Task<Users> GetAsync(int id);
        Task<ICollection<Users>> GetByRole(string role);
        Task<ICollection<Users>> ListAsync();
        Task UpdateAsync(Users user);
    }
}
