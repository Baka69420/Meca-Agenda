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
    public class RepositoryBranchSchedule : IRepositoryBranchSchedule
    {
        private readonly MecaAgendaContext _context;

        public RepositoryBranchSchedule(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(BranchSchedules branchSchedule)
        {
            await _context.Set<BranchSchedules>().AddAsync(branchSchedule);
            await _context.SaveChangesAsync();
            return branchSchedule.ScheduleId;
        }

        public async Task DeleteAsync(int branchScheduleId)
        {
            var branchScheduleToDelete = await GetAsync(branchScheduleId);

            if (branchScheduleToDelete != null)
            {
                _context.Set<BranchSchedules>().Remove(branchScheduleToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Branch Schedule with ID {branchScheduleId} does not exist.");
            }
        }

        public async Task<BranchSchedules> GetAsync(int id)
        {
            var @object = await _context.Set<BranchSchedules>()
                .Where(x => x.ScheduleId == id)
                .OrderBy(x => x.ScheduleId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<BranchSchedules>> ListAsync(int? idBranch)
        {
            var collection = await _context.Set<BranchSchedules>()
                .OrderBy(x => x.ScheduleId)
                .AsNoTracking()
                .ToListAsync();

            if(idBranch.HasValue)
                collection = collection.Where(x => x.BranchId == idBranch.Value).ToList();

            return collection;
        }

        public async Task UpdateAsync(BranchSchedules branchSchedule)
        {
            var branchScheduleToUpdate = await GetAsync(branchSchedule.ScheduleId);

            if (branchScheduleToUpdate != null)
            {
                branchScheduleToUpdate.DayOfWeek = branchScheduleToUpdate.DayOfWeek;
                branchScheduleToUpdate.OpenTime = branchSchedule.OpenTime;
                branchScheduleToUpdate.CloseTime = branchSchedule.CloseTime;

                _context.Entry(branchScheduleToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Branch Schedule with ID {branchSchedule.ScheduleId} does not exist.");
            }
        }
    }
}
