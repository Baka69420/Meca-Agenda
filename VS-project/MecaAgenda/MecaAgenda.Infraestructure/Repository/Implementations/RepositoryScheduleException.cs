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
    public class RepositoryScheduleException : IRepositoryScheduleException
    {
        private readonly MecaAgendaContext _context;

        public RepositoryScheduleException(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<ScheduleExceptions> GetAsync(int id)
        {
            var @object = await _context.Set<ScheduleExceptions>()
                .Where(x => x.ExceptionId == id)
                .OrderBy(x => x.ExceptionId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<ScheduleExceptions>> GetByBranchAndDateAsync(int idBranch, DateOnly exceptionDate)
        {
            var collection = await _context.Set<ScheduleExceptions>()
                .Where(x => x.BranchId == idBranch && x.Date == exceptionDate)
                .OrderBy(x => x.ExceptionId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<ScheduleExceptions>> GetByBranchAsync(int idBranch)
        {
            var collection = await _context.Set<ScheduleExceptions>()
                .Where(x => x.BranchId == idBranch)
                .OrderBy(x => x.ExceptionId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<ScheduleExceptions>> GetByDateAsync(DateOnly exceptionDate)
        {
            var collection = await _context.Set<ScheduleExceptions>()
                .Where(x => x.Date == exceptionDate)
                .OrderBy(x => x.ExceptionId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<ScheduleExceptions>> ListAsync()
        {
            var collection = await _context.Set<ScheduleExceptions>()
                .OrderBy(x => x.ExceptionId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
