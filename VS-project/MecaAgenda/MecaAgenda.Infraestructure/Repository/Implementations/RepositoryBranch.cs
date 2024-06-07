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
    public class RepositoryBranch : IRepositoryBranch
    {
        private readonly MecaAgendaContext _context;

        public RepositoryBranch(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Branches>> FindByNameAsync(string branchName)
        {
            var collection = await _context.Set<Branches>()
                .Where(x => x.Name!.Contains(branchName))
                .OrderBy(x => x.BranchId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<Branches> GetAsync(int id)
        {
            var @object = await _context.Set<Branches>()
                .Where(x => x.BranchId == id)
                .OrderBy(x => x.BranchId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Branches>> ListAsync()
        {
            var collection = await _context.Set<Branches>()
                .OrderBy(x => x.BranchId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
