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

        public async Task<ICollection<Services>> FindByNameAsync(string serviceName)
        {
            var collection = await _context.Set<Services>()
                .Where(x => x.Name!.Contains(serviceName))
                .OrderBy(x => x.ServiceId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<Services> GetAsync(int id)
        {
            var @object = await _context.Set<Services>()
                .Where(x => x.ServiceId == id)
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
    }
}
