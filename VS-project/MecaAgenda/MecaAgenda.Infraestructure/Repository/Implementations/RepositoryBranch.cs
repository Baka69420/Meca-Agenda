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

        public async Task<int> AddAsync(Branches branch)
        {
            await _context.Set<Branches>().AddAsync(branch);
            await _context.SaveChangesAsync();
            return branch.BranchId;
        }

        public async Task DeleteAsync(int branchId)
        {
            var branchToDelete = await GetAsync(branchId);

            if (branchToDelete != null)
            {
                _context.Set<Branches>().Remove(branchToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Branch with ID {branchId} does not exist.");
            }
        }

        public async Task<Branches> GetAsync(int id)
        {
            var @object = await _context.Set<Branches>()
                .Where(x => x.BranchId == id)
                .Include(x => x.BranchSchedules.OrderBy(y => y.DayOfWeek))
                .Include(x => x.ScheduleExceptions.OrderByDescending(y => y.Date))
                .OrderBy(x => x.BranchId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Branches>> ListAsync(string branchName)
        {
            var collection = await _context.Set<Branches>()
                .OrderBy(x => x.BranchId)
                .AsNoTracking()
                .ToListAsync();

            if (!string.IsNullOrEmpty(branchName))
                collection = collection.Where(x => x.Name!.Contains(branchName)).ToList();

            return collection;
        }

        public async Task UpdateAsync(Branches branch)
        {
            var branchToUpdate = await GetAsync(branch.BranchId);

            if (branchToUpdate != null)
            {
                branchToUpdate.Name = branch.Name;
                branchToUpdate.Description = branch.Description;
                branchToUpdate.Phone = branch.Phone;
                branchToUpdate.Address= branch.Address;
                branchToUpdate.Email = branch.Email;

                _context.Entry(branchToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Branch with ID {branch.BranchId} does not exist.");
            }
        }
    }
}
