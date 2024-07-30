using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceAppointment
    {
        Task<int> AddAsync(AppointmentDTO appointmentDTO);
        Task DeleteAsync(int appointmentId);
        Task<AppointmentDTO> GetAsync(int id);
        Task<ICollection<AppointmentDTO>> ListAsync(int? idBranch, int? idClient, DateOnly? appointmentDate);
        Task UpdateAsync(AppointmentDTO appointmentDTO);
    }
}
