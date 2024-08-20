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
        Task<int> AddAsync(UserDTO userDTO);
        Task DeleteAsync(int userId);
        Task<UserDTO> GetAsync(int id);
        Task<UserDTO> GetByEmailAsync(string email);
        Task<ICollection<UserDTO>> ListAsync(string role, string name);
        Task UpdateAsync(UserDTO userDTO);
    }
}
