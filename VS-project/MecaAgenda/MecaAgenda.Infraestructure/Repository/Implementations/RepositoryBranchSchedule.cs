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

        public async Task<BranchSchedules> GetAsync(int id)
        {
            var @object = await _context.Set<BranchSchedules>()
                .Where(x => x.ScheduleId == id)
                .OrderBy(x => x.ScheduleId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<BranchSchedules>> GetByBranch(int idBranch)
        {
            var collection = await _context.Set<BranchSchedules>()
                .Where(x => x.BranchId == idBranch)
                .OrderBy(x => x.ScheduleId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<BranchSchedules>> ListAsync()
        {
            var collection = await _context.Set<BranchSchedules>()
                .OrderBy(x => x.ScheduleId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
