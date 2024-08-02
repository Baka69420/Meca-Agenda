using MecaAgenda.Application.DTOs;

namespace MecaAgenda.Web.Services.Interfaces
{
    public interface IServiceLogIn
    {
        Task<UserDTO?> LogInUser(int userId, string password);
        Task<int> RegisterUser(UserDTO userDTO, string password);
        Task<bool> UpdatePassword (int userId, string oldPassword, string newPassword);
    }
}
