using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryAppointment
    {
        Task<ICollection<Appointments>> ListAsync();
        Task<ICollection<Appointments>> GetByBranchAsync(int idBranch);
        Task<ICollection<Appointments>> GetByDateAsync(DateOnly appointmentDate);
        Task<ICollection<Appointments>> GetByClientAsync(int idClient);
        Task<ICollection<Appointments>> GetByBranchAndClientAsync(int idBranch, int idClient);
        Task<ICollection<Appointments>> GetByBranchAndDateAsync(int idBranch, DateOnly appointmentDate);
        Task<ICollection<Appointments>> GetByClientAndDateAsync(int idClient, DateOnly appointmentDate);
        Task<Appointments> GetAsync(int id);
    }
}
