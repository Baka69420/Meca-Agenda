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
        Task<ICollection<UserDTO>> FindByNameAsync(string userName);
        Task<UserDTO> GetAsync(int id);
        Task<ICollection<UserDTO>> GetByRole(string role);
        Task<ICollection<UserDTO>> ListAsync();
        Task UpdateAsync(UserDTO userDTO);
    }
}
