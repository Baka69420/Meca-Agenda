using MecaAgenda.Application.DTOs;

namespace MecaAgenda.Web.Services.Interfaces
{
    public interface IServiceLogin
    {
        Task<UserDTO?> LoginUser(string email, string password);
        Task<int> RegisterUser(UserDTO userDTO);
        Task<bool> UpdatePassword (string email, string oldPassword, string newPassword);
    }
}
