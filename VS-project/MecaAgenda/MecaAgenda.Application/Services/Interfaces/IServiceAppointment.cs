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
        Task<ICollection<AppointmentDTO>> GetByBranchAndClientAsync(int idBranch, int idClient);
        Task<ICollection<AppointmentDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly appointmentDate);
        Task<ICollection<AppointmentDTO>> GetByBranchAsync(int idBranch);
        Task<ICollection<AppointmentDTO>> GetByClientAndDateAsync(int idClient, DateOnly appointmentDate);
        Task<ICollection<AppointmentDTO>> GetByClientAsync(int idClient);
        Task<ICollection<AppointmentDTO>> GetByDateAsync(DateOnly appointmentDate);
        Task<ICollection<AppointmentDTO>> ListAsync();
        Task UpdateAsync(AppointmentDTO appointmentDTO);
    }
}
