using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MecaAgenda.Web.Services.Implementations
{
    public class ServiceLogIn : IServiceLogIn
    {
        private readonly IPasswordHasher<UserDTO> _passwordHasher;
        private readonly IServiceUser _serviceUser;

        public ServiceLogIn(IPasswordHasher<UserDTO> passwordHasher, IServiceUser serviceUser)
        {
            _passwordHasher = passwordHasher;
            _serviceUser = serviceUser;
        }

        public async Task<UserDTO?> LogInUser(int userId, string password)
        {
            //Get user information
            var user = await _serviceUser.GetAsync(userId);

            // Return null if User was not found
            if (user == null) return null;

            // Check if stored hash equals the received password after being hashed
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            // Return user if password was correct, if not return null
            return result == PasswordVerificationResult.Success ? user : null;
        }

        public async Task<int> RegisterUser(UserDTO userDTO, string password)
        {
            // Convert password into hash and save hash into new user to store
            userDTO.PasswordHash = _passwordHasher.HashPassword(userDTO, password);

            // Save new user into DB
            return await _serviceUser.AddAsync(userDTO);
        }

        public async Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            // Get user information
            var user = await LogInUser(userId, oldPassword);

            // If no user is returned with old credentials return false
            if (user == null) return false;

            // If an user is returned, update password
            user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);

            // Update data in DB
            await _serviceUser.UpdateAsync(user);

            // return true if successful
            return true;
        }
    }
}
