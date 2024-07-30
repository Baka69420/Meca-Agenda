using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceScheduleException
    {
        Task<int> AddAsync(ScheduleExceptionDTO scheduleExceptionDTO);
        Task DeleteAsync(int scheduleExceptionId);
        Task<ScheduleExceptionDTO> GetAsync(int id);
        Task<ICollection<ScheduleExceptionDTO>> ListAsync(int? idBranch, DateOnly? exceptionDate);
        Task UpdateAsync(ScheduleExceptionDTO scheduleExceptionDTO);
    }
}
