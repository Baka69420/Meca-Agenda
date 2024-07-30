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
        Task<Users> GetAsync(int id);
        Task<ICollection<Users>> ListAsync(string role, string userName);
        Task UpdateAsync(Users user);
    }
}
