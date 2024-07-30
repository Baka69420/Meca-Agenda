using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryAppointment : IRepositoryAppointment
    {
        private readonly MecaAgendaContext _context;

        public RepositoryAppointment(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Appointments appointment)
        {
            await _context.Set<Appointments>().AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment.AppointmentId;
        }

        public async Task DeleteAsync(int appointmentId)
        {
            var appointmentToDelete = await GetAsync(appointmentId);

            if (appointmentToDelete != null)
            {
                _context.Set<Appointments>().Remove(appointmentToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Appointment with ID {appointmentId} does not exist.");
            }
        }

        public async Task<Appointments> GetAsync(int id)
        {
            var @object = await _context.Set<Appointments>()
                .Where(x => x.AppointmentId == id)
                .Include(x => x.Client)
                .Include(x => x.Branch)
                .Include(x => x.Service)
                .OrderBy(x => x.AppointmentId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Appointments>> ListAsync(int? idBranch, int? idClient, DateOnly? appointmentStartDate, DateOnly? appointmentEndDate)
        {
            var collection = await _context.Set<Appointments>()
                .Include(x => x.Client)
                .Include(x => x.Branch)
                .Include(x => x.Service)
                .OrderByDescending(x => x.Date)
                .AsNoTracking()
                .ToListAsync();

            if (idBranch.HasValue)
                collection = collection.Where(x => x.BranchId == idBranch.Value).ToList();

            if (idClient.HasValue)
                collection = collection.Where(x => x.ClientId == idClient.Value).ToList();

            if (appointmentStartDate.HasValue && appointmentEndDate.HasValue)
                collection = collection.Where(x => appointmentStartDate.Value <= x.Date && x.Date <= appointmentEndDate.Value).ToList();

            return collection;
        }

        public async Task UpdateAsync(Appointments appointment)
        {
            var appointmentToUpdate = await GetAsync(appointment.AppointmentId);

            if (appointmentToUpdate != null)
            {
                appointmentToUpdate.ServiceId = appointment.ServiceId;
                appointmentToUpdate.Date = appointment.Date;
                appointmentToUpdate.StartTime = appointment.StartTime;
                appointmentToUpdate.EndTime = appointment.EndTime;
                appointmentToUpdate.Status = appointment.Status;
                appointmentToUpdate.Price = appointment.Price;

                _context.Entry(appointmentToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Appointment with ID {appointment.ServiceId} does not exist.");
            }
        }
    }
}
