using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryScheduleException
    {
        Task<int> AddAsync(ScheduleExceptions scheduleException);
        Task DeleteAsync(int scheduleExceptionId);
        Task<ScheduleExceptions> GetAsync(int id);
        Task<ICollection<ScheduleExceptions>> GetByBranchAndDateAsync(int idBranch, DateOnly exceptionDate);
        Task<ICollection<ScheduleExceptions>> GetByBranchAsync(int idBranch);
        Task<ICollection<ScheduleExceptions>> GetByDateAsync(DateOnly exceptionDate);
        Task<ICollection<ScheduleExceptions>> ListAsync();
        Task UpdateAsync(ScheduleExceptions scheduleException);
    }
}
