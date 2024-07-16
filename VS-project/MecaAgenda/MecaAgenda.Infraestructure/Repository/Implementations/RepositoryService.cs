using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryService : IRepositoryService
    {
        private readonly MecaAgendaContext _context;

        public RepositoryService(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Services service)
        {
            await _context.Set<Services>().AddAsync(service);
            await _context.SaveChangesAsync();
            return service.ServiceId;
        }

        public async Task DeleteAsync(int serviceId)
        {
            var serviceToDelete = await GetAsync(serviceId);

            if (serviceToDelete != null)
            {
                _context.Set<Services>().Remove(serviceToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Service with ID {serviceId} does not exist.");
            }
        }

        public async Task<ICollection<Services>> FindByNameAsync(string serviceName)
        {
            var collection = await _context.Set<Services>()
                .Where(x => x.Name!.Contains(serviceName))
                .OrderBy(x => x.ServiceId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<Services> GetAsync(int serviceId)
        {
            var @object = await _context.Set<Services>()
                .Where(x => x.ServiceId == serviceId)
                .OrderBy(x => x.ServiceId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Services>> ListAsync()
        {
            var collection = await _context.Set<Services>()
                .OrderBy(x => x.ServiceId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(Services service)
        {
            var serviceToUpdate = await GetAsync(service.ServiceId);

            if (serviceToUpdate != null)
            {
                serviceToUpdate.Name = service.Name;
                serviceToUpdate.Description = service.Description;
                serviceToUpdate.Price = service.Price;
                serviceToUpdate.EstimatedTime = service.EstimatedTime;
                serviceToUpdate.ToolsRequired = service.ToolsRequired;
                serviceToUpdate.MaterialsNeeded = service.MaterialsNeeded;

                _context.Entry(serviceToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Service with ID {service.ServiceId} does not exist.");
            }
        }
    }
}
