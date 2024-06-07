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
    }
}
