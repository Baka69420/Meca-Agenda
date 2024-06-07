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
                .OrderBy(x => x.UserId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
