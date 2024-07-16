using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly MecaAgendaContext _context;

        public RepositoryUser(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Users user)
        {
            await _context.Set<Users>().AddAsync(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task DeleteAsync(int userId)
        {
            var userToDelete = await GetAsync(userId);

            if (userToDelete != null)
            {
                _context.Set<Users>().Remove(userToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {userId} does not exist.");
            }
        }

        public async Task<ICollection<Users>> FindByNameAsync(string userName)
        {
            var collection = await _context.Set<Users>()
                .Where(x => x.Name!.Contains(userName))
                .OrderBy(x => x.UserId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<Users> GetAsync(int id)
        {
            var @object = await _context.Set<Users>()
                .Where(x => x.UserId == id)
                .OrderBy(x => x.UserId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Users>> GetByRole(string role)
        {
            var collection = await _context.Set<Users>()
                .Where(x => x.Role!.Equals(role))
                .OrderBy(x => x.UserId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Users>> ListAsync()
        {
            var collection = await _context.Set<Users>()
                .Include(x => x.Branch)
                .OrderBy(x => x.UserId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(Users user)
        {
            var userToUpdate = await GetAsync(user.UserId);

            if (userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Phone = user.Phone;
                userToUpdate.Email = user.Email;
                userToUpdate.Address = user.Address;
                userToUpdate.PasswordHash = user.PasswordHash;
                userToUpdate.Role = user.Role;
                userToUpdate.BranchId = user.BranchId;

                _context.Entry(userToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {user.UserId} does not exist.");
            }
        }
    }
}
