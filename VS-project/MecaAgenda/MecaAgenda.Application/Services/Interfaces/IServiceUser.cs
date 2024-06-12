using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceUser
    {
        Task<ICollection<UserDTO>> ListAsync();
        Task<ICollection<UserDTO>> GetByRole(string role);
        Task<ICollection<UserDTO>> FindByNameAsync(string userName);
        Task<UserDTO> GetAsync(int id);
    }
}
