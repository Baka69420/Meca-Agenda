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
        Task<ICollection<Users>> ListAsync();
        Task<ICollection<Users>> GetByRole(string role);
        Task<ICollection<Users>> FindByNameAsync(string userName);
        Task<Users> GetAsync(int id);
    }
}
