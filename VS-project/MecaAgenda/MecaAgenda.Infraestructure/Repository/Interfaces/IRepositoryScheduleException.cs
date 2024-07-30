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
        Task<ICollection<ScheduleExceptions>> ListAsync(int? idBranch, DateOnly? exceptionDate);
        Task UpdateAsync(ScheduleExceptions scheduleException);
    }
}
