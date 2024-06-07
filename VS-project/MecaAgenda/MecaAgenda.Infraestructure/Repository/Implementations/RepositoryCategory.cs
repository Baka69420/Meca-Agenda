using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryCategory : IRepositoryCategory
    {
        private readonly MecaAgendaContext _context;

        public RepositoryCategory(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Categories>> FindByNameAsync(string categoryName)
        {
            var collection = await _context.Set<Categories>()
                .Where(x => x.Name!.Contains(categoryName))
                .OrderBy(x => x.CategoryId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<Categories> GetAsync(int id)
        {
            var @object = await _context.Set<Categories>()
                .Where(x => x.CategoryId == id)
                .OrderBy(x => x.CategoryId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Categories>> ListAsync()
        {
            var collection = await _context.Set<Categories>()
                .OrderBy(x => x.CategoryId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
