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
        Task<int> AddAsync(Appointments appointment);
        Task DeleteAsync(int appointmentId);
        Task<Appointments> GetAsync(int id);
        Task<ICollection<Appointments>> ListAsync(int? idBranch, int? idClient, DateOnly? appointmentDate);
        Task UpdateAsync(Appointments appointment);
    }
}
