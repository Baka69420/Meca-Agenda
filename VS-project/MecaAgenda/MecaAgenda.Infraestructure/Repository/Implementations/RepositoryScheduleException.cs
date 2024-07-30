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

        public async Task<int> AddAsync(ScheduleExceptions scheduleException)
        {
            await _context.Set<ScheduleExceptions>().AddAsync(scheduleException);
            await _context.SaveChangesAsync();
            return scheduleException.ExceptionId;
        }

        public async Task DeleteAsync(int scheduleExceptionId)
        {
            var scheduleExceptionToDelete = await GetAsync(scheduleExceptionId);

            if (scheduleExceptionToDelete != null)
            {
                _context.Set<ScheduleExceptions>().Remove(scheduleExceptionToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"ScheduleException with ID {scheduleExceptionId} does not exist.");
            }
        }

        public async Task<ScheduleExceptions> GetAsync(int id)
        {
            var @object = await _context.Set<ScheduleExceptions>()
                .Where(x => x.ExceptionId == id)
                .OrderBy(x => x.ExceptionId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<ScheduleExceptions>> ListAsync(int? idBranch, DateOnly? exceptionStartDate, DateOnly? exceptionEndDate)
        {
            var collection = await _context.Set<ScheduleExceptions>()
                .OrderBy(x => x.ExceptionId)
                .AsNoTracking()
                .ToListAsync();

            if (idBranch.HasValue)
                collection = collection.Where(x => x.BranchId == idBranch.Value).ToList();

            if (exceptionStartDate.HasValue && exceptionEndDate.HasValue)
                collection = collection.Where(x => exceptionStartDate.Value <= x.Date && x.Date <= exceptionEndDate.Value).ToList();

            return collection;
        }

        public async Task UpdateAsync(ScheduleExceptions scheduleException)
        {
            var scheduleExceptionToUpdate = await GetAsync(scheduleException.ExceptionId);

            if (scheduleExceptionToUpdate != null)
            {
                scheduleExceptionToUpdate.Date = scheduleException.Date;
                scheduleExceptionToUpdate.StartTime = scheduleException.StartTime;
                scheduleExceptionToUpdate.EndTime = scheduleException.EndTime;
                scheduleExceptionToUpdate.ServicesAffected = scheduleException.ServicesAffected;

                _context.Entry(scheduleException).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Schedule Exception with ID {scheduleException.ExceptionId} does not exist.");
            }
        }
    }
}
