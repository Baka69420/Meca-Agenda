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
        Task<ICollection<ScheduleExceptionDTO>> ListAsync();
        Task<ICollection<ScheduleExceptionDTO>> GetByBranchAsync(int idBranch);
        Task<ICollection<ScheduleExceptionDTO>> GetByDateAsync(DateOnly exceptionDate);
        Task<ICollection<ScheduleExceptionDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly exceptionDate);
        Task<ScheduleExceptionDTO> GetAsync(int id);
    }
}
