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
                .OrderBy(x => x.AppointmentId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Appointments>> GetByBranchAndClientAsync(int idBranch, int idClient)
        {
            var collection = await _context.Set<Appointments>()
                .Where(x => x.BranchId == idBranch && x.ClientId == idClient)
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Appointments>> GetByBranchAndDateAsync(int idBranch, DateOnly appointmentDate)
        {
            var collection = await _context.Set<Appointments>()
                .Where(x => x.BranchId == idBranch && x.Date == appointmentDate)
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Appointments>> GetByBranchAsync(int idBranch)
        {
            var collection = await _context.Set<Appointments>()
                .Where(x => x.BranchId == idBranch)
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Appointments>> GetByClientAndDateAsync(int idClient, DateOnly appointmentDate)
        {
            var collection = await _context.Set<Appointments>()
                .Where(x => x.ClientId == idClient && x.Date == appointmentDate)
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Appointments>> GetByClientAsync(int idClient)
        {
            var collection = await _context.Set<Appointments>()
                .Where(x => x.ClientId == idClient)
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Appointments>> GetByDateAsync(DateOnly appointmentDate)
        {
            var collection = await _context.Set<Appointments>()
                .Where(x => x.Date == appointmentDate)
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Appointments>> ListAsync()
        {
            var collection = await _context.Set<Appointments>()
                .OrderBy(x => x.AppointmentId)
                .AsNoTracking()
                .ToListAsync();
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
                appointmentToUpdate.PaymentMethod = appointment.PaymentMethod;
                appointmentToUpdate.Paid = appointment.Paid;

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
